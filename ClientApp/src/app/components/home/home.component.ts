import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { FakeShopApiService } from 'src/app/services/fakeShopApi/fake-shop-api.service';
import { Item } from 'src/app/interfaces/Item';
import { FormControl } from '@angular/forms';
import { Observable, map, startWith } from 'rxjs';
import { RequestData } from '../../interfaces/RequestData';

import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material';
import { JwtHelperService } from '@auth0/angular-jwt';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  public itemsQuantity: number = 0;
  public filteredShopItems: Item[] = [];

  lastSearch: string = '';
  requestData: RequestData = {
    category: 'all',
    page: 0,
    title: '',
  };
  categoryControl = new FormControl('all');
  priceControl = new FormControl(null);


  dataSource!: MatTableDataSource<any>;
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  searchControl = new FormControl<string>('');
  options: string[] = [];
  filteredOptions: Observable<string[]> | undefined;

  async handleCategory(value: string): Promise<void> {
    this.lastSearch = '';
    this.requestData.category = value;
    const count: number = await this.fakeShop.getCount(this.requestData);
    if (count > 0) {
      this.filteredShopItems = (await this.fakeShop.getItems(
        this.requestData
      )) as Item[];
    }
    this.itemsQuantity = count;
    this.requestData.title = '';
    this.paginator.firstPage();
  }
  async onPaginateChange(event: PageEvent) {
    this.requestData.page = event.pageIndex * 6;
    const count: number = await this.fakeShop.getCount(this.requestData);
    if (count > 0) {
      this.filteredShopItems = (await this.fakeShop.getItems(
        this.requestData
      )) as Item[];
    }
    this.itemsQuantity = count;
  }
  async handleSearch(): Promise<void> {
    this.lastSearch = this.searchControl.value!;
    this.requestData.title = this.searchControl.value!;
    const count: number = await this.fakeShop.getCount(this.requestData);
    if (count > 0) {
      this.filteredShopItems = (await this.fakeShop.getItems(
        this.requestData
      )) as Item[];
    }
    this.itemsQuantity = count;
    this.requestData.title = '';
    this.searchControl.reset();
    this.paginator.firstPage();
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.options.filter((option) =>
      option.toLowerCase().includes(filterValue)
    );
  }
  isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem('jwt');
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    return false;
  };
  logOut = () => {
    localStorage.removeItem('jwt');
  };

  constructor(
    public fakeShop: FakeShopApiService,
    private jwtHelper: JwtHelperService
  ) {}

  async ngOnInit(): Promise<void> {
    const count: number = await this.fakeShop.getCount(this.requestData);
    if (count > 0) {
      this.filteredShopItems = (await this.fakeShop.getItems(
        this.requestData
      )) as Item[];
    }
    this.itemsQuantity = count;

    this.options = [...this.filteredShopItems].map((el) => {
      return el.title.toString();
    });

    this.filteredOptions = this.searchControl.valueChanges.pipe(
      startWith(''),
      map((value) => this._filter(value || ''))
    );
  }
}

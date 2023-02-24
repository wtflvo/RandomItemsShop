import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, lastValueFrom } from 'rxjs';
import { Item } from 'src/app/interfaces/Item';
import { getBaseUrl } from '../../../main';
import { RequestData } from '../../interfaces/RequestData';

@Injectable({
  providedIn: 'root',
})
export class FakeShopApiService {
  public baseUrl = getBaseUrl();

  constructor(private http: HttpClient) {}

  async getItems(reqData: RequestData): Promise<any> {
    let apiData: Observable<Object> = this.http.post(
      this.baseUrl + 'getitems',
      reqData
    );

    return await lastValueFrom(apiData);
  }
  async getCount(reqData: RequestData): Promise<any> {
    let apiData: Observable<Object> = this.http.post(
      this.baseUrl + 'getcount',
      reqData
    );

    return await lastValueFrom(apiData);
  }
}

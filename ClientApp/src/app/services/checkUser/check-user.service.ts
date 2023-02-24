import {  Injectable } from '@angular/core';
import {
  HttpClient,
  
  HttpHeaders,
  
} from '@angular/common/http';
import { __await } from 'tslib';


import { getBaseUrl } from 'src/main';
import { AuthenticatedResponse } from '../../interfaces/AuthenticatedResponse';
import { LoginUser } from 'src/app/interfaces/LoginUser';

@Injectable({
  providedIn: 'root',
})
export class CheckUserService {
  constructor(private http: HttpClient) {}

  checkUser(user: LoginUser) {
    const baseUrl = getBaseUrl();
    console.log(user, 'user');

    return this.http.post<AuthenticatedResponse>(baseUrl + 'login', user, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    });
  }
}

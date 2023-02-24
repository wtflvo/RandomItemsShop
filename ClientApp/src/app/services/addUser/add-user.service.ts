import { Injectable } from '@angular/core';


import { HttpClient, } from '@angular/common/http';
import { __await } from 'tslib';

import { getBaseUrl } from '../../../main';
import { User } from 'src/app/interfaces/User';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AddUserService {
  constructor(private http: HttpClient) {}

  sendUser(user: User) {
    
    const baseUrl = getBaseUrl();
    
    return this.http.post(baseUrl + 'registration', user, {
      responseType: 'text' as 'text'
    })
  }
}



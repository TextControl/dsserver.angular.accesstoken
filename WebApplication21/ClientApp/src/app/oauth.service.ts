import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Resolve } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class OauthService implements Resolve<any> {

  public _http: HttpClient;
  public _baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
  }

  resolve() {
    return this._http.get<any>(this._baseUrl + 'oauth/accesstoken');
  }
}


import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import * as jwt_decode from 'jwt-decode';

import { environment } from 'src/environments/environment';

@Injectable({providedIn: 'root'})
export class AuthService{
    token: string;
    token_key: string;
    path: string;
    constructor(private http: HttpClient, private router: Router, private jwtHelper: JwtHelperService) {
      this.token = localStorage.getItem(environment.token_key);
      this.path = environment.path;
      this.token_key = environment.token_key;
    }
  
    registerUser(userData) {
      return this.http.post(this.path + '/users/register', userData);
    }
  
    loginUser(userData) {
      return this.http.post(this.path + '/users/login', userData);
    }

    isTokenExpired(token: string): boolean {
        if (!token) {
          return false;
        }
        return this.jwtHelper.isTokenExpired(token);
    }
  
    isAuthenticated(): boolean {
        if (!this.token) {
          return false;
        } else if (this.isTokenExpired(this.token)) {
          return false;
        } else {
          return true;
        }
      }
  
    getUserInfo() {
      const webToken = jwt_decode(this.token);
      return webToken;
    }
  
    logout() {
        this.removeToken();
        this.router.navigate(['/']);
    }
  
    private removeToken() {
      localStorage.removeItem(this.token_key);
      this.token = null;
    }
}
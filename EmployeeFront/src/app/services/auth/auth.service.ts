import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginResult } from 'src/app/models/Login/LoginResult';
import { Response } from 'src/app/models/ServiceResponse/Response';
import { UserParams } from 'src/app/models/User/UserParams';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  private ApiUrl = `${environment.ApiUrl}/login`

  constructor(private http : HttpClient) { }

  login(loginParams: UserParams): Observable<Response<LoginResult>> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    return this.http.post<Response<LoginResult>>(this.ApiUrl, loginParams, { headers: headers });
  }

  getToken() : string {
    const token = localStorage.getItem("authToken");
    if(token === null) {
      return "Invalid token";
    }
    return token;
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Response } from 'src/app/models/ServiceResponse/Response';
import { UserParams } from 'src/app/models/User/UserParams';
import { UserResult } from 'src/app/models/User/UserResult';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private ApiUrl = `${environment.ApiUrl}/user/create`;

  constructor(private http: HttpClient) {}

  register(userParams: UserParams): Observable<Response<UserResult>> {
    return this.http.post<Response<UserResult>>(this.ApiUrl, userParams);
  }

  getToken(): string {
    const token = localStorage.getItem('authToken');
    if (token !== null) {
      return token;
    } else {
      return 'Invalid token';
    }
  }
}

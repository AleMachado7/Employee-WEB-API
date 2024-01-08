import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Response } from 'src/app/models/ServiceResponse/Response';
import { UserParams } from 'src/app/models/User/UserParams';
import { UserResult } from 'src/app/models/User/UserResult';
import { environment } from 'src/environments/environment';
import { AuthService } from '../auth/auth.service';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private ApiUrl = `${environment.ApiUrl}/user`;

  constructor(private http: HttpClient, private authService: AuthService) {}

  register(userParams: UserParams): Observable<Response<UserResult>> {
    return this.http.post<Response<UserResult>>(
      this.ApiUrl + `/create`,
      userParams
    );
  }

  getToken(): string {
    const token = localStorage.getItem('authToken');
    if (token !== null) {
      return token;
    } else {
      return 'Invalid token';
    }
  }

  getCurrentUser(): Observable<Response<UserResult>> {
    const token = this.authService.getToken();
    const headers = new HttpHeaders().set('Authorization', 'bearer ' + token);

    return this.http.get<Response<UserResult>>(this.ApiUrl + `/currentUser`, {
      headers: headers,
    });
  }

  getUsers(): Observable<Response<UserResult[]>> {
    const token = this.authService.getToken();
    const headers = new HttpHeaders().set('Authorization', 'bearer ' + token);

    return this.http.get<Response<UserResult[]>>(this.ApiUrl, {
      headers: headers,
    });
  }
}

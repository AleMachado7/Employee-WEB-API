import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response } from '../../models/ServiceResponse/Response';
import { Employee } from '../../models/Employee/Employee';
import { Observable } from 'rxjs';
import { AuthService } from '../auth/auth.service';
import { EmployeeParams } from 'src/app/models/Employee/EmployeeParams';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  private ApiUrl = `${environment.ApiUrl}/employee`;

  constructor(private http: HttpClient, private authService: AuthService) {}

  getEmployees(): Observable<Response<Employee[]>> {
    const token = this.authService.getToken();
    const headers = new HttpHeaders().set('Authorization', 'bearer ' + token);

    return this.http.get<Response<Employee[]>>(this.ApiUrl, {
      headers: headers,
    });
  }

  createEmployee(employee: EmployeeParams): Observable<Response<Employee>> {
    const token = this.authService.getToken();
    const headers = new HttpHeaders().set('Authorization', 'bearer ' + token);

    return this.http.post<Response<Employee>>(this.ApiUrl, employee, {
      headers: headers,
    });
  }

  editEmployee(
    id: string,
    employeeParams: EmployeeParams
  ): Observable<Response<Employee>> {
    const token = this.authService.getToken();
    const headers = new HttpHeaders().set('Authorization', 'bearer ' + token);

    return this.http.put<Response<Employee>>(
      this.ApiUrl + `/${id} `,
      employeeParams,
      {
        headers: headers,
      }
    );
  }

  getEmployee(id: string): Observable<Response<Employee>> {
    const token = this.authService.getToken();
    const headers = new HttpHeaders().set('Authorization', 'bearer ' + token);

    return this.http.get<Response<Employee>>(this.ApiUrl + `/${id}`, {
      headers: headers,
    });
  }

  inactivateEmployee(id: string): Observable<Response<Employee>> {
    const token = this.authService.getToken();
    const headers = new HttpHeaders().set('Authorization', 'bearer ' + token);

    return this.http.put<Response<Employee>>(
      this.ApiUrl + `/inactivate/${id} `,
      null,
      {
        headers: headers,
      }
    );
  }

  deleteEmployee(id: string): Observable<Response<Employee>> {
    const token = this.authService.getToken();
    const headers = new HttpHeaders().set('Authorization', 'bearer ' + token);

    return this.http.delete<Response<Employee>>(this.ApiUrl + `/${id} `, {
      headers: headers,
    });
  }
}

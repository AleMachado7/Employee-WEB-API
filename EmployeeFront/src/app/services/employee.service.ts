import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Response } from '../models/Response';
import { Employee } from '../models/Employee';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private ApiUrl = `${environment.ApiUrl}/Employee`

  constructor( private http: HttpClient ) { }

  getEmployees() : Observable<Response<Employee[]>> {
    return this.http.get<Response<Employee[]>>(this.ApiUrl)
  }
}

import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';

import { environment } from '../../../../environments/environment';
import { Employee } from '../../../shared/models/employee'
import { Observable } from 'rxjs';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable()
export class EmployeeService {

  constructor(private http: HttpClient) { }

  public getEmployees(): Observable<any[]> {
    return this.http.get<any[]>(environment.urlServerAddress + 'employees/');
  }

  public addEmployee(employee: Employee): Observable<Employee> {
    return this.http.post<Employee>(environment.urlServerAddress + 'employees', employee, httpOptions);
  }
}

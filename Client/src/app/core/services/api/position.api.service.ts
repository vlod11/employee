import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';

import { environment } from '../../../../environments/environment';
import { Employee } from '../../../shared/models/employee';
import { Position } from '../../../shared/models/position';
import { Observable } from 'rxjs';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable()
export class PositionService {

  constructor(private http: HttpClient) { }

  public getPositions(): Observable<Position[]> {
    return this.http.get<Position[]>(environment.urlServerAddress + 'positions/');
  }

  public addPosition(position: Position): Observable<Position> {
    return this.http.post<Position>(environment.urlServerAddress + 'positions', position, httpOptions);
  }
}

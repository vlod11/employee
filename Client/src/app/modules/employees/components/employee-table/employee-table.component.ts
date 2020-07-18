import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from 'src/app/shared/models/employee';

@Component({
  selector: 'app-employee-table',
  templateUrl: './employee-table.component.html',
  styleUrls: ['./employee-table.component.scss']
})
export class EmployeeTableComponent implements OnInit {
  public displayedColumns: string[] = ['id', 'name', 'salary', 'lastJobTitle', 'hiredAtUtc', 'leftAtUtc'];
  @Input() public employees$: Observable<Employee[]>;
  constructor() { }

  ngOnInit() {
  }
}

import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/shared/models/employee';
import { Position } from 'src/app/shared/models/position';
import { MatDialog } from '@angular/material';
import { AddPositionPopupComponent } from '../add-position-popup/add-position-popup.component';
import { Router } from '@angular/router';
import { PositionService } from 'src/app/core/services/api/position.api.service';
import { EmployeeService } from 'src/app/core/services/api/employee.api.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AddEmployeePopupComponent } from '../add-employee-popup/add-employee-popup.component';

@Component({
  selector: 'app-employee-root',
  templateUrl: './employee-root.component.html',
  styleUrls: ['./employee-root.component.scss']
})
export class EmployeeRootComponent implements OnInit {
  public employees$: Observable<Employee[]>;
  public positions$: Observable<Position[]>;

  constructor(public dialog: MatDialog,
              private positionService: PositionService,
              public router: Router,
              public employeeService: EmployeeService) {
    this.positions$ = this.positionService.getPositions();
  }

  ngOnInit() {
    this.getEmployeesList();
  }

  public addPosition(): void {
    const dialogRef = this.dialog.open(AddPositionPopupComponent, {
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.positionService.addPosition(
          result as Position).subscribe(
            () => {
            },
            error => {
              // TODO: send error to some global place
            });
      }
    });
  }

  public getEmployeesList()
  {
    this.employees$ = this.employeeService.getEmployees()
      .pipe(map((entries: any[]) => entries.map((e) => Employee.assemble(e))));
  }

  public addEmployee(): void {
    const dialogRef = this.dialog.open(AddEmployeePopupComponent, {
      data: { positions: this.positions$ }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.employeeService.addEmployee(
          result as Employee).subscribe(
            () => {
              this.getEmployeesList();
            },
            error => {
              // TODO: send error to some global place
            });
      }
    });
  }
}

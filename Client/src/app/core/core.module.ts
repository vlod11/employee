import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EmployeeService } from './services/api/employee.api.service';
import { PositionService } from './services/api/position.api.service';

@NgModule({
  declarations: [],
  imports: [
    BrowserAnimationsModule,
  ],
  providers: [
    EmployeeService,
    PositionService
  ]
})
export class CoreModule { }

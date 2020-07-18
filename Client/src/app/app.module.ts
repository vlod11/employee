import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeRootComponent } from './modules/employees/components/employee-root/employee-root.component';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { AddEmployeePopupComponent } from './modules/employees/components/add-employee-popup/add-employee-popup.component';
import { AddPositionPopupComponent } from './modules/employees/components/add-position-popup/add-position-popup.component';
import { HttpClientModule } from '@angular/common/http';
import { EmployeeTableComponent } from './modules/employees/components/employee-table/employee-table.component';


@NgModule({
  declarations: [
    AppComponent,
    EmployeeRootComponent,
    EmployeeTableComponent,
    AddEmployeePopupComponent,
    AddPositionPopupComponent
  ],
  entryComponents: [
    AddPositionPopupComponent,
    AddEmployeePopupComponent
  ],
  imports: [
    SharedModule,
    CoreModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

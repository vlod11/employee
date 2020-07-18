import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeRootComponent } from './modules/employees/components/employee-root/employee-root.component';

const routes: Routes = [
  {
    path: 'employees',
    component: EmployeeRootComponent
  },
  {
    path: '**',
    redirectTo: 'employees',
    pathMatch: 'full'
  }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

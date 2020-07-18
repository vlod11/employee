import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EmployeeRootComponent } from './components/employee-root/employee-root.component';

const routes: Routes = [
  {
    path: 'employees',
    component: EmployeeRootComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfileRoutingModule { }

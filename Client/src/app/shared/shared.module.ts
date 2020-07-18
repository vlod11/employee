import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import * as fromMaterial from './material-imports';
import { TranslateModule } from '@ngx-translate/core';


@NgModule({
  declarations: [
  ],
  entryComponents: [
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    fromMaterial.MatTableModule,
    fromMaterial.MatButtonModule,
    fromMaterial.MatDialogModule,
    fromMaterial.MatFormFieldModule,
    fromMaterial.MatInputModule,
    fromMaterial.MatNativeDateModule,
    TranslateModule
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,

    fromMaterial.MatTableModule,
    fromMaterial.MatButtonModule,
    fromMaterial.MatDialogModule,
    fromMaterial.MatFormFieldModule,
    fromMaterial.MatInputModule,
    fromMaterial.MatSelectModule,
    fromMaterial.MatOptionModule,
    fromMaterial.MatDatepickerModule,
    fromMaterial.MatNativeDateModule,
    TranslateModule
  ]
})
export class SharedModule { }

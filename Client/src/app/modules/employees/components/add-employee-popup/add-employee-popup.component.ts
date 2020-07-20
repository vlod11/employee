import { Component, OnInit, Inject, ChangeDetectionStrategy } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { DialogData } from './dialog-data';

@Component({
  selector: 'app-add-employee-popup',
  templateUrl: './add-employee-popup.component.html',
  styleUrls: ['./add-employee-popup.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AddEmployeePopupComponent implements OnInit {
  public positionAddForm = new FormGroup({
    nameInput: new FormControl('', Validators.required),
    surnameInput: new FormControl('', Validators.required),
    salaryInput: new FormControl('', Validators.required),
    hiredAtInput: new FormControl('', Validators.required),
    positionInput: new FormControl('', Validators.required),
    leftAtInput: new FormControl(''),
  });

  constructor(
    public dialogRef: MatDialogRef<AddEmployeePopupComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) { }

  ngOnInit() {
  }

  onCreateClick() {
    if (!this.positionAddForm.valid) {
      this.validateAllFormFields(this.positionAddForm);
    }

    const leftAtInputValue = this.positionAddForm.controls['leftAtInput'].value ? this.positionAddForm.controls['leftAtInput'].value : null;

    this.dialogRef.close({
      salary: this.positionAddForm.controls['salaryInput'].value,
      positionId: this.positionAddForm.controls['positionInput'].value,
      name: this.positionAddForm.controls['nameInput'].value,
      surname: this.positionAddForm.controls['surnameInput'].value,
      hiredAt: this.positionAddForm.controls['hiredAtInput'].value,
      leftAt: leftAtInputValue,
    });
  }

onCloseClick(): void {
    this.dialogRef.close();
  }

  validateAllFormFields(formGroup: FormGroup) {
  Object.keys(formGroup.controls).forEach(field => {
    const control = formGroup.get(field);
    if (control instanceof FormControl) {
      control.markAsTouched({ onlySelf: true });
    } else if (control instanceof FormGroup) {
      this.validateAllFormFields(control);
    }
  });
}
}
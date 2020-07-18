import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-position-popup',
  templateUrl: './add-position-popup.component.html',
  styleUrls: ['./add-position-popup.component.scss']
})
export class AddPositionPopupComponent implements OnInit {
  public positionAddForm = new FormGroup({
    titleInput: new FormControl('', Validators.required),
  });

  constructor(
    public dialogRef: MatDialogRef<AddPositionPopupComponent>) { }

  ngOnInit() {
  }

  onCreateClick() {
    const titleInput = this.positionAddForm.controls['titleInput'];

    if (titleInput.invalid) {
      return;
    }

    this.dialogRef.close({
      title: titleInput.value
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
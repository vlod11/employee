import { MatSnackBar, MatSnackBarConfig } from '@angular/material';
import { Injectable } from '@angular/core';
import { take } from 'rxjs/operators';
import { TranslateService } from '@ngx-translate/core';

@Injectable()
export class PopupService {

    private config: MatSnackBarConfig = {
        duration: 7000,
        horizontalPosition: 'right',
        verticalPosition: 'bottom'
    };

    constructor(private snackBar: MatSnackBar,
        private translateService: TranslateService) { }

    public showError(message: string) {
        if (message) {
            this.translateService.get(message).pipe(take(1)).toPromise()
            .then(translation => {
                this.snackBar.open(translation, 'Error', this.config);
            });
        }
        else {
            console.error(message);
            throw ('message is empty');
        }
    }

    public showMessage(message: string) {
        if (message) {
            this.translateService.get(message).pipe(take(1)).toPromise()
                .then(translation => {
                    this.snackBar.open(translation, 'Ok', this.config);
                });
        }
        else {
            console.error(message);
            throw ('message is empty');
        }
    }
}
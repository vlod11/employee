import { Observable } from 'rxjs';

export interface IDialogData {
    positions$: Observable<Position[]>;
  }
import { Observable } from 'rxjs';

export interface DialogData {
    positions$: Observable<Position[]>;
  }
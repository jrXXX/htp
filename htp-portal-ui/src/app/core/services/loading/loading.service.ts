import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { concatMap, tap } from 'rxjs/operators';

@Injectable()
export class LoadingService {
  private loadingSubject$ = new BehaviorSubject<boolean>(false);
  loading$: Observable<boolean> = this.loadingSubject$.asObservable();

  showLoadingUndHideLoading<T>(obs$: Observable<T>): Observable<T> {
    return of(null).pipe(
      tap(() => this.showLoadingComponent()),
      concatMap(() => obs$),
      tap(() => this.hideLoadingComponent())
    );
  }

  showLoadingComponent() {
    this.loadingSubject$.next(true);
  }

  hideLoadingComponent() {
    this.loadingSubject$.next(false);
  }
}

import { Observable, of } from 'rxjs';
import { Injectable } from '@angular/core';
import { NGXLogger } from 'ngx-logger';

@Injectable({ providedIn: 'root' })
export abstract class BaseRepository {

    constructor(private logger: NGXLogger) { }
    protected handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {

          this.logger.error(`${operation} failed: ${error.message}`);

          return of(result as T);
        };
    }
}

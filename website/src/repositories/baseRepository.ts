import { Observable, of } from 'rxjs';

export abstract class BaseRepository {

    protected handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {

          console.error(error); // log to console instead

        //   this.log(`${operation} failed: ${error.message}`);

          // Let the app keep running by returning an empty result.
          return of(result as T);
        };
    }
}

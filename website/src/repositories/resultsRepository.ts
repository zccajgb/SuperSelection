import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseRepository } from './baseRepository';
import { Injectable } from '@angular/core';
import { NGXLogger } from 'ngx-logger';
import { CalculationViewModel } from 'src/models/view-models/calculation-view-model';

@Injectable({ providedIn: 'root' })
export class ResultsRepository extends BaseRepository {

    url = 'https://localhost:44369/Results';

    constructor(private http: HttpClient, logger: NGXLogger) {
        super(logger);
    }

    getCalculationsForUser(): Observable<CalculationViewModel[]> {
        return this.http.get<CalculationViewModel[]>(this.url + '/GetResultsByUserID')
        .pipe(
            catchError(this.handleError<CalculationViewModel[]>('getCalculationsForUser'))
        );
    }

    getCalculationByID(id: string): Observable<CalculationViewModel> {
        return this.http.get<CalculationViewModel>(this.url + '/GetResultByID/' + id)
        .pipe(
            catchError(this.handleError<CalculationViewModel>('GetResultsByID'))
        );
    }
}

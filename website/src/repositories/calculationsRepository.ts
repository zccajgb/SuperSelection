import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from 'src/models/user';
import { catchError } from 'rxjs/operators';
import { BaseRepository } from './baseRepository';
import { Injectable } from '@angular/core';
import { Calculation } from 'src/models/calculation';
import { NGXLogger } from 'ngx-logger';

@Injectable({ providedIn: 'root' })
export class CalculationsRepository extends BaseRepository {

    url = 'https://localhost:44369/Calculations';

    constructor(private http: HttpClient, logger: NGXLogger) {
        super(logger);
    }

    submitSelectivityCalculation(calculation: Calculation): Observable<Calculation> {
        return this.http.post<Calculation>('https://localhost:44369/Calculations/CreateSelectivityCalculation', calculation).pipe(
            catchError(this.handleError<Calculation>('submitCalculation'))
        );
    }
}

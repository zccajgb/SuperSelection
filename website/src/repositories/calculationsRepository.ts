import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from 'src/models/user';
import { catchError } from 'rxjs/operators';
import { BaseRepository } from './baseRepository';
import { Injectable } from '@angular/core';
import { Calculation } from 'src/models/calculation';

@Injectable({ providedIn: 'root' })
export class CalculationsRepository extends BaseRepository {

    url = 'https://localhost:44369/calculations';

    constructor(private http: HttpClient) {
        super();
    }

    getUsers(): Observable<User[]> {
        return this.http.get<User[]>(this.url);
    }

    submitCalculation(calculation: Calculation): Observable<Calculation> {
        return this.http.post<Calculation>(this.url, calculation);
    }
}

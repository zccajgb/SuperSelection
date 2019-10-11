import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from 'src/models/user';
import { catchError } from 'rxjs/operators';
import { BaseRepository } from './baseRepository';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class UserRepository extends BaseRepository {

    url = 'https://localhost:44369/users';

    constructor(private http: HttpClient, private httpHeaders: HttpHeaders) {
        super();
    }

    getUsers(): Observable<User[]> {
        return this.http.get<User[]>(this.url);
    }

    login(username: string, password: string): Observable<User> {
        return this.http.post<User>(this.url + '/Login', {username, password}).pipe(
            catchError(this.handleError<User>('login'))
        );
    }

    createNewUser(user: User): Observable<any> {
        return this.http.post<any>(this.url, user).pipe(
            catchError(this.handleError<any>('createNewUser'))
        );
    }
}

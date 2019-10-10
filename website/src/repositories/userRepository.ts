import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from 'src/models/user';
import { catchError } from 'rxjs/operators';
import { inherits } from 'util';
import { BaseRepository } from './baseRepository';

export class UserRepository extends BaseRepository {

    private userUrl = 'https://localhost:44369/users';

    constructor(private http: HttpClient, private httpHeaders: HttpHeaders) {
        super();
    }

    getUsers(): Observable<User[]> {
        return this.http.get<User[]>(this.userUrl);
    }

    login(username: string, password: string): Observable<string> {
        return this.http.post<string>(this.userUrl + '/Login', {username, password}).pipe(
            catchError(this.handleError<string>('login'))
        );
    }

    createNewUser(user: User): Observable<any> {
        return this.http.post<any>(this.userUrl, user).pipe(
            catchError(this.handleError<any>('createNewUser'))
        );
    }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { User } from 'src/models/user';
import { getInterpolationArgsLength } from '@angular/compiler/src/render3/view/util';
import { UserRepository } from 'src/repositories/userRepository';
import { NGXLogger } from 'ngx-logger';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<User>;
    public currentUser: Observable<User>;

    constructor(private http: HttpClient, private repo: UserRepository, private logger: NGXLogger) {
        this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): User {
        return this.currentUserSubject.value;
    }

    login(username: string, password: string) {
        return this.repo.login(username, password)
            .pipe(map(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                // tslint:disable-next-line: triple-equals
                if (user != null) {
                    localStorage.setItem('currentUser', JSON.stringify(user));
                    this.logger.info('user saved to local storage');
                    this.currentUserSubject.next(user);
                }
                return user;
            }));
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
        this.logger.info('user removed from local storage');
        this.currentUserSubject.next(null);
    }
}

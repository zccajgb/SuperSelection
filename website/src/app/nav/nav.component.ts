import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { AuthenticationService } from '../_services/authentication.service';
import { User } from 'src/models/user';
import { Title } from '@angular/platform-browser';
import { NGXLogger } from 'ngx-logger';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent {
  currentUser: User;

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(
    private breakpointObserver: BreakpointObserver,
    private router: Router,
    private authenticationService: AuthenticationService,
    private titleService: Title,
    private logger: NGXLogger
    ) {
      this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    }

  logout() {
      this.authenticationService.logout();
      this.logger.info('user sucessfully logged out');
      this.router.navigate(['/login']);
    }

  isAuthenticated(): boolean {
      return this.currentUser != null;
    }

  showSideNav(): boolean {
    return !this.isHandset$ || this.isAuthenticated();
  }
}

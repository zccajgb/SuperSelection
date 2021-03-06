import { Component, OnInit } from '@angular/core';
import { User } from 'src/models/user';
import { UserRepository } from 'src/repositories/userRepository';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { NGXLogger } from 'ngx-logger';

@Component({
  selector: 'app-create-new-account',
  templateUrl: './create-new-account.component.html',
  styleUrls: ['./create-new-account.component.scss']
})
export class CreateNewAccountComponent implements OnInit {

  user: User;
  loading = false;
  submitted = false;
  error = '';
  returnUrl = '/';

  constructor(private userRepo: UserRepository, private router: Router, private logger: NGXLogger) {
    this.user = new User();
   }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    this.submitted = true;
    this.loading = true;

    this.userRepo.createNewUser(this.user)
        .subscribe(
          data => {
            if (data == null) {
                this.error = 'Error: account already exists or invalid details';
                this.logger.error(this.error);
                this.loading = false;
            } else {
                this.logger.info('create new account sucessful');
                this.router.navigate([this.returnUrl]);
            }
        },
        error => {
            this.error = error;
            this.logger.error(this.error);
            this.loading = false;
        });
  }

}

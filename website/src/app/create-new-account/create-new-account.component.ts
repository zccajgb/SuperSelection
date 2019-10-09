import { Component, OnInit } from '@angular/core';
import { User } from 'src/models/user';

@Component({
  selector: 'app-create-new-account',
  templateUrl: './create-new-account.component.html',
  styleUrls: ['./create-new-account.component.scss']
})
export class CreateNewAccountComponent implements OnInit {

  user: User;

  constructor() {
    this.user = new User();
   }

  ngOnInit() {
  }

  onSubmit() {
  }

}

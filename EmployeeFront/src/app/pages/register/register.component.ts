import { Component } from '@angular/core';
import { UserParams } from 'src/app/models/User/UserParams';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  formTitle: string = 'Register';
  btnAction: string = 'New Account';

  constructor() {}

  register(user: UserParams) {

  }
}

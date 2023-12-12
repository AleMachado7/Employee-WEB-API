import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserParams } from 'src/app/models/User/UserParams';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  formTitle: string = 'Register';
  btnAction: string = 'New Account';

  constructor(private userService: UserService, private router: Router) {}

  register(user: UserParams) {
    this.userService.register(user).subscribe((data) => {
      if (data.success) {
        this.router.navigate(['login']);
      } else {
        alert(data.message);
      }
    });
  }
}

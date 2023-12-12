import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserParams } from 'src/app/models/User/UserParams';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  formTitle: string = 'Welcome';
  btnAction: string = 'Login';

  constructor(private authService: AuthService, private router: Router) {}

  login(user: UserParams) {
    this.authService.login(user).subscribe((response) => {
      if (response.success) {
        localStorage.setItem('authToken', response.data.token);
        this.router.navigate(['home']);
      }
    });
  }
}

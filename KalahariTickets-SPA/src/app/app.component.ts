import { Component } from '@angular/core';
import { AuthService } from './_services/auth.service';
import { AlertifyService } from './_services/alertify.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./styles.scss']
})
export class AppComponent {
  constructor(private authService: AuthService, private alertify: AlertifyService) { }
  title = 'KalahariTickets';
  model: any = {};
  lat = 51.678418;
  lng = 7.809007;

  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Logged in successfully');
    }, error => {
      this.alertify.error('Failed to Login');
    });
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
  }
}

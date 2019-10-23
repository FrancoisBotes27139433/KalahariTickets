import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-add-client',
  templateUrl: './add-client.component.html',
  styleUrls: ['./add-client.component.css']
})
export class AddClientComponent implements OnInit {
  model: any = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  registerClient() {
    this.authService.register(this.model).subscribe(() => {
      console.log('registration sucessfull');
    });
  }

  cancel() {
    console.log('cancelled');
  }
}

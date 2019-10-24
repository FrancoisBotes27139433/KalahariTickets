import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { TechnitionServiceService } from '../_services/TechnitionService.service';

@Component({
  selector: 'app-add-technition',
  templateUrl: './add-technition.component.html',
  styleUrls: ['./add-technition.component.css']
})
export class AddTechnitionComponent implements OnInit {
  model: any = {};

  constructor(private authService: AuthService, private alertify: AlertifyService, private techService: TechnitionServiceService) { }

  ngOnInit() {
  }

  addTechnition() {
    this.techService.addTechnition(this.model).subscribe(() => {
      this.alertify.success('Technition added sucessfull');
    });
  }

}

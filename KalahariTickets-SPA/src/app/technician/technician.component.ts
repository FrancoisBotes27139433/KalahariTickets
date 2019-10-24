import { Component, OnInit } from '@angular/core';
import { ClientService } from '../_services/client.service';
import { TicketService } from '../_services/ticket.service';
import { TechnitionServiceService } from '../_services/TechnitionService.service';
import { Technition } from '../_model/technitions';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-technician',
  templateUrl: './technician.component.html',
  styleUrls: ['./technician.component.scss']
})
export class TechnicianComponent implements OnInit {
  technitions: Technition[];

  constructor(private authService: AuthService,private clientService: ClientService, private ticketService: TicketService,private technitionService: TechnitionServiceService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadTecnitions();
  }

  loadTecnitions() {
    this.technitionService.getTechnitions().subscribe((technitions: Technition[]) => {
      this.technitions = technitions;
    });
  }

  deleteTechnition(id: number) {
    this.alertify.confirm('Are you sure you want to delete the Technition?' , () => {
      this.technitionService.deleteTechnition(this.authService.decodedToken.nameid, id).subscribe(() => {
        this.technitions.splice(this.technitions.findIndex(t => t.id === id), 1);
        this.alertify.success('Technition Deleted Succesfully');

    }, error => {
      this.alertify.error('Failed to delete the technition');
    });
  });

}}

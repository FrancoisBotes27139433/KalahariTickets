import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { TicketService } from '../_services/ticket.service';
import { ActivatedRoute } from '@angular/router';
import { Tickets } from '../_model/tickets';

@Component({
  selector: 'app-add-ticket',
  templateUrl: './add-ticket.component.html',
  styleUrls: ['./add-ticket.component.css']
})
export class AddTicketComponent implements OnInit {
  model: any = {};
  ticket: Tickets;

  constructor(private ticketService: TicketService, private route: ActivatedRoute, private authService: AuthService) { }

  ngOnInit() {
  }

  addTicket() {
    this.ticketService.addTicket(this.model, this.route.snapshot.params.id).subscribe((ticket: Tickets) => {
      this.ticket = ticket;
    });
  }
}

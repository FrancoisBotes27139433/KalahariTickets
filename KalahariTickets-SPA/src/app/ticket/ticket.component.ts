import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { TicketService } from '../_services/ticket.service';
import { Tickets } from '../_model/tickets';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.scss']
})
export class TicketComponent implements OnInit {
  ticket: Tickets[];

  constructor(private ticketService: TicketService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.loadTickets();
  }

  loadTickets() {
    this.ticketService.getTickets().subscribe((ticket: Tickets[]) => {
      this.ticket = ticket;
    });
  }
  // loadClients() {
  //   this.clientService.getClients().subscribe((clients: Client[]) => {
  //     this.clients = clients;
  //   });
  // }
}

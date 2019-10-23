import { Component, OnInit } from '@angular/core';
import { Client } from '../_model/client';
import { ClientService } from '../_services/client.service';
import { Tickets } from '../_model/tickets';
import { TicketService } from '../_services/ticket.service';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.scss']
})
export class ClientComponent implements OnInit {
  clients: Client[];

  constructor(private clientService: ClientService, private ticketService: TicketService) { }

  ngOnInit() {
    this.loadClients();
  }

  loadClients() {
    this.clientService.getClients().subscribe((clients: Client[]) => {
      this.clients = clients;
    });
  }

}

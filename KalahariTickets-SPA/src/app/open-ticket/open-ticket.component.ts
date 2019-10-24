import { Component, OnInit } from '@angular/core';
import { ClientService } from '../_services/client.service';
import { ActivatedRoute } from '@angular/router';
import { Client } from '../_model/client';

@Component({
  selector: 'app-open-ticket',
  templateUrl: './open-ticket.component.html',
  styleUrls: ['./open-ticket.component.css']
})
export class OpenTicketComponent implements OnInit {
  client: Client;

  constructor(private clientService: ClientService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.loadClient();
  }

  loadClient() {
    this.clientService.getClient(this.route.snapshot.params.id).subscribe((client: Client) => {
      this.client = client;
    });
  }

}

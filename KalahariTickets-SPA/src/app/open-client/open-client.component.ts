import { Component, OnInit } from '@angular/core';
import { ClientService } from '../_services/client.service';
import { Client } from '../_model/client';
import { ActivatedRoute } from '@angular/router';
import { Tickets } from '../_model/tickets';

@Component({
  selector: 'app-open-client',
  templateUrl: './open-client.component.html',
  styleUrls: ['./open-client.component.css']
})
export class OpenClientComponent implements OnInit {
  client: Client;
  ticket: Tickets[];
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

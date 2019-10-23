import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { TicketService } from '../_services/ticket.service';

@Component({
  selector: 'app-add-ticket',
  templateUrl: './add-ticket.component.html',
  styleUrls: ['./add-ticket.component.css']
})
export class AddTicketComponent implements OnInit {
  model: any = {};

  constructor(private ticketService: TicketService) { }

  ngOnInit() {
  }

  // addTicket(id) {
  //   this.ticketService.addticket(this.model , id).subscribe(() => {
  //     console.log('ticket added');
  //   });
  // }
}

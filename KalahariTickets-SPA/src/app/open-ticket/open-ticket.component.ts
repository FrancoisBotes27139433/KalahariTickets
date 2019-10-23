import { Component, OnInit } from '@angular/core';
import { MapComponent } from '../map/map.component'
import {ILatLng} from '../map/directions-map.directive';

@Component({
  selector: 'app-open-ticket',
  templateUrl: './open-ticket.component.html',
  styleUrls: ['./open-ticket.component.css']
})
export class OpenTicketComponent implements OnInit {

  constructor() { }

  destination: ILatLng = {
    latitude: -26.693931,
    longitude: 27.098831
  };
  displayDirections = true;
  zoom = 14;

  ngOnInit() {
  }

}

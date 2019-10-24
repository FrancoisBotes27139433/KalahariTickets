import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { MapComponent } from '../map/map.component'
import {ILatLng} from '../map/directions-map.directive';
import { GeocodeService } from '../_services/geocode.service'; 
import { Location } from '../_model/location'

@Component({
  selector: 'app-open-ticket',
  templateUrl: './open-ticket.component.html',
  styleUrls: ['./open-ticket.component.css']
})
export class OpenTicketComponent implements OnInit {

  constructor(private geocodeService: GeocodeService,
    private ref: ChangeDetectorRef,) { }

    address = 'London';
    location: Location;
    loading: boolean;

  destination: ILatLng = {
    latitude: -26.693931,
    longitude: 27.098831
  };
  displayDirections = true;
  zoom = 14;

  ngOnInit() {
    this.showLocation();
  }

  showLocation() {
    this.addressToCoordinates();
  }

  addressToCoordinates() {
    this.loading = true;
    this.geocodeService.geocodeAddress(this.address)
    .subscribe((location: Location) => {
        this.location = location;
        this.loading = false;
        this.ref.detectChanges(); 
        console.log(location);
      }      
    );     
  }

}

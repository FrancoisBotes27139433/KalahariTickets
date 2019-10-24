import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { NgModel } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { Location } from '../_model/location';
import { GeocodeService } from '../_services/geocode.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: [ './home.component.scss' ] 
})
export class HomeComponent implements OnInit {
  address = 'London';
  location: Location;
  loading: boolean;

  constructor(
    private geocodeService: GeocodeService,
    private ref: ChangeDetectorRef,
  ) {}
  
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
        
      }      
    );     
  }
}

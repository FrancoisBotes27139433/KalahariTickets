import {Component, OnInit} from '@angular/core';
import {ILatLng} from '../map/directions-map.directive';
import { getInterpolationArgsLength } from '@angular/compiler/src/render3/view/util';
import { Location } from '../_model/location';

@Component({
    selector: 'app-map',
    templateUrl: './map.component.html',
    styleUrls: ['./map.component.css']
})
export class MapComponent{
  constructor() {
  }
location: Location 

  destination: ILatLng = location= {
    latitude: -26.69,
    longitude: 27.09
  };
  displayDirections = true;
  zoom = 14;
  ngOnInit() {
      console.log(this.location)
    //const ob = this.geo.getLatLan("11 Hoffman St, Potchefstroom, 2520, South Africa");
    //console.log(ob.coords.latitude);
  }
  
}

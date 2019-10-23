import {Component, OnInit} from '@angular/core';
import {ILatLng} from '../map/directions-map.directive';

@Component({
    selector: 'app-map',
    templateUrl: './map.component.html',
    styleUrls: ['./map.component.css']
})
export class MapComponent{
  constructor() {
  }

  destination: ILatLng = {
    latitude: -26.693931,
    longitude: 27.098831
  };
  displayDirections = true;
  zoom = 14;
}

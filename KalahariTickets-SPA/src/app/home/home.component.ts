import { Component, OnInit } from '@angular/core';
import {} from 'googlemaps';
import { ViewChild } from '@angular/core';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']

})



export class HomeComponent implements OnInit {

  constructor() { }

  @ViewChild('map', { static: true}) mapElement: any;
  map: google.maps.Map;
  isTracking = false;

  currentLat: any;
  currentLong: any;

  marker: google.maps.Marker;


  ngOnInit(): void {
    // Setting up the maps
    const mapProperties = {
         zoom: 15,
         disableDoubleClickZoom: true,
         mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    this.map = new google.maps.Map(this.mapElement.nativeElement,    mapProperties);

    // Add marker to the maps
    google.maps.event.addListener(this.map, 'click', function(event) {
      placeMarker(this.map, event.latLng);
    });
    
    function placeMarker(map1, location) {
      var marker = new google.maps.Marker({
        position: location,
        map: map1
      });
      var infowindow = new google.maps.InfoWindow({
        content: 'Latitude: ' + location.lat() +
        '<br>Longitude: ' + location.lng()
      });
      infowindow.open(map1,marker);
    }
    this.trackMe();
 }

 placeMarker($event) {
  console.log($event.coords.lat);
  console.log($event.coords.lng);
}

 trackMe() {
  if (navigator.geolocation) {
    this.isTracking = true;
    navigator.geolocation.watchPosition((position) => {
      this.showTrackingPosition(position);

    });
  } else {
    alert('Geolocation is not supported by this browser.');
  }
}



showTrackingPosition(position: Position) {
  console.log(`tracking postion:  ${position.coords.latitude} - ${position.coords.longitude}`);
  this.currentLat = position.coords.latitude;
  this.currentLong = position.coords.longitude;
  console.log(this.currentLat);
  console.log(this.currentLong);
  const location = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
  this.map.panTo(location);

  if (!this.marker) {
    this.marker = new google.maps.Marker({
      position: location,
      map: this.map,
      title: 'Got you!'

    });
  } else {
    this.marker.setPosition(location);
    this.marker.setMap(this.map);
  }
}



}



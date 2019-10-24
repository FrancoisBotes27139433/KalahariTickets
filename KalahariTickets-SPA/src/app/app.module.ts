import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { AgmCoreModule } from '@agm/core';



import { JwtModule } from '@auth0/angular-jwt';

import { AppComponent } from './app.component';
import { ValueComponent } from './value/value.component';
import { LogComponent } from './log/log.component';
import { AuthService } from './_services/auth.service';
import { RouterModule, Routes } from '@angular/router';
import { ClientComponent } from './client/client.component';
import { TicketComponent } from './ticket/ticket.component';
import { TechnicianComponent } from './technician/technician.component';
import { AppRoutingModule} from './app-routing.module';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { MapComponent } from './map/map.component';
import { DirectionsMapDirective } from './map/directions-map.directive';
import { AddClientComponent } from './add-client/add-client.component';
import { OpenTicketComponent } from './open-ticket/open-ticket.component';
import { EditTicketComponent } from './edit-ticket/edit-ticket.component';
import { AddTicketComponent } from './add-ticket/add-ticket.component';
import { OpenClientComponent } from './open-client/open-client.component';

import { AddTechnitionComponent } from './add-technition/add-technition.component';
import { GeocodeService } from './_services/geocode.service';


export function tokenGetter() {
   return localStorage.getItem('token');
 }

@NgModule({
   declarations: [
      AppComponent,
      ValueComponent,
      LogComponent,
      ClientComponent,
      TicketComponent,
      TechnicianComponent,
      LoginComponent,
      HomeComponent,
      MapComponent,
      DirectionsMapDirective,
      AddClientComponent,
      OpenTicketComponent,
      EditTicketComponent,
      AddTicketComponent,
      OpenClientComponent,
      AddTechnitionComponent,
      OpenClientComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      RouterModule,
      AppRoutingModule,
      AgmCoreModule.forRoot({
         apiKey: 'AIzaSyAorO1PoQngwMQGg1qmA2q7qHCZmyC85qE'}),
         JwtModule.forRoot({
            config: {
              tokenGetter,
              whitelistedDomains: ['localhost:5000'],
              blacklistedRoutes: ['localhost:5000/api/auth']
            }
          })
      
   ],
   providers: [
      AuthService,
      GeocodeService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }


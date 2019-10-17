import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';

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




@NgModule({
   declarations: [
      AppComponent,
      ValueComponent,
      LogComponent,
      ClientComponent,
      TicketComponent,
      TechnicianComponent,
      LoginComponent,
      HomeComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      RouterModule,
      AppRoutingModule
   ],
   providers: [
      AuthService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }

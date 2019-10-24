import { Routes, RouterModule } from '@angular/router';
import { TicketComponent } from './ticket/ticket.component';
import { ClientComponent } from './client/client.component';
import { NgModule } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { TechnicianComponent } from './technician/technician.component';
import { HomeComponent } from './home/home.component';
import { AuthService } from './_services/auth.service';
import { MapComponent } from './map/map.component';
import { AddClientComponent } from './add-client/add-client.component';
import { OpenTicketComponent } from './open-ticket/open-ticket.component';
import { EditTicketComponent } from './edit-ticket/edit-ticket.component';
import { AddTicketComponent } from './add-ticket/add-ticket.component';
import { OpenClientComponent } from './open-client/open-client.component';
import { RegisterComponent } from './register/register.component';



const routes: Routes = [
  { path: 'ticket', component: TicketComponent},
    { path: 'client', component: ClientComponent},
    { path: 'tech', component: TechnicianComponent},
    { path: 'home', component: HomeComponent},
    { path: 'login', component: LoginComponent},
    { path: 'map', component: MapComponent},
    { path: 'openticket', component: OpenTicketComponent},
    { path: 'editticket', component: EditTicketComponent},
    { path: 'addticket/:id', component: AddTicketComponent},
    { path: 'client/:id', component: OpenClientComponent},
    { path: 'addclient', component: AddClientComponent},
    { path: 'register', component: RegisterComponent}
  ];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }





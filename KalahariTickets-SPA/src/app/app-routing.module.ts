import { Routes, RouterModule } from '@angular/router';
import { TicketComponent } from './ticket/ticket.component';
import { ClientComponent } from './client/client.component';
import { NgModule } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { TechnicianComponent } from './technician/technician.component';
import { HomeComponent } from './home/home.component';
import { AuthService } from './_services/auth.service';



const routes: Routes = [
  { path: 'ticket', component: TicketComponent},
    { path: 'client', component: ClientComponent},
    { path: 'tech', component: TechnicianComponent},
    { path: 'home', component: HomeComponent},
    { path: 'login', component: LoginComponent},
  ];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }





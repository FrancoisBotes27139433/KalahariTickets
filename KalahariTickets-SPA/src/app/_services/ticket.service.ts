import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Tickets } from '../_model/tickets';
import { Observable } from 'rxjs';
import { identifierModuleUrl } from '@angular/compiler';


@Injectable({
  providedIn: 'root'
})
export class TicketService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getTickets(): Observable<Tickets[]> {
    return this.http.get<Tickets[]>(this.baseUrl + 'allticket');
  }

  getTicket(id): Observable<Tickets> {
    return this.http.get<Tickets>(this.baseUrl + 'tickets/' + id);
  }

  addTicket(model: any, id: number) {
    console.log(model);
    return this.http.post(this.baseUrl + 'clients/' + id + '/tickets', model);
  }
}


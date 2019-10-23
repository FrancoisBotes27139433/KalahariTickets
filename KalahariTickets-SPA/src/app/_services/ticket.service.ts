import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Tickets } from '../_model/tickets';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getTickets(): Observable<Tickets[]> {
    return this.http.get<Tickets[]>(this.baseUrl + 'tickets', httpOptions);
  }

  getTicket(id): Observable<Tickets> {
    return this.http.get<Tickets>(this.baseUrl + 'tickets/' + id, httpOptions);
  }

}

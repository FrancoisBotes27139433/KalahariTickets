import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Client } from '../_model/client';
import { Tickets } from '../_model/tickets';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

  getClients(): Observable<Client[]> {
    return this.http.get<Client[]>(this.baseUrl + 'clients');
  }

  getClient(id): Observable<Client> {
    return this.http.get<Client>(this.baseUrl + 'clients/' + id);
  }

  getOpenTickets(id): Observable<Tickets[]> {
    return this.http.get<Tickets[]>(this.baseUrl + 'clients/' + id + 'GetOpenTickets');
  }
}

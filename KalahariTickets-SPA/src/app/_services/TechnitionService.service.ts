import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Technition} from '../_model/technitions';
import { Observable } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class TechnitionServiceService {
  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

getTechnitions(): Observable<Technition[]> {
  return this.http.get<Technition[]>(this.baseUrl + 'technition');
}

getTechnition(id): Observable<Technition[]> {
  return this.http.get<Technition[]>(this.baseUrl + 'technition/' + id);
}

 deleteTechnition(userId: number, id: number) {
   return this.http.delete(this.baseUrl + 'technition/' + userId + '/delete/ + id');
  }

  addTechnition(model: any) {
    return this.http.post(this.baseUrl + 'technition/AddTechnition' , model);
  }

}

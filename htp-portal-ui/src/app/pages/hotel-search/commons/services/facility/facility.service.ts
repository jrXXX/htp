import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Facility } from 'src/app/api';
import { environment } from 'src/environments/environment';
import { shareReplay } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
class FacilityService {
  private url = environment.backendUrl;

  constructor(private http: HttpClient) {}

  get facilities(): Observable<Facility[]> {
    return this.http.get<Facility[]>(`/api/getFacilities`);
  }
}

export default FacilityService;

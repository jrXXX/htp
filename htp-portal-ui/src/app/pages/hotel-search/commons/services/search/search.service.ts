import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SearchResponse } from 'src/app/api';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
}) 
class SearchService {
  private url = environment.backendUrl;

  constructor(private http: HttpClient) {}

  getSearchResults(searchRequest: string): Observable<SearchResponse[]> {

    if (environment.mock) {
      // cannot use POST here since mock server assumes CRUD call and returns 500
      return this.http.post<SearchResponse[]>(`${this.url}/hotelSearch`,
      JSON.parse(searchRequest));
    }
    if (environment.docker) {
      //  alert(JSON.stringify(environment) + " --- " + this.url)
      // cannot use POST here since mock server assumes CRUD call and returns 500
      return this.http.post<SearchResponse[]>(`${this.url}/hotelSearch`,
      JSON.parse(searchRequest));
    }
    return this.http.post<SearchResponse[]>(
      `/api/hotelSearch`,
      JSON.parse(searchRequest)
    );
  }
}

export default SearchService;

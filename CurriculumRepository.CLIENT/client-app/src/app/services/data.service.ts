import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class DataService {
    appUrl: string;
    apiUrl: string;
    httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json; charset=utf-8'
      })
    };
    constructor(private http: HttpClient) {
      this.appUrl = environment.host;
      this.apiUrl = 'api/Data/'
    }

    getTeachingSubjects() {
        return this.http.get(this.appUrl + this.apiUrl + 'teaching-subjects');
    }

    getTeachingAids() {
        return this.http.get(this.appUrl + this.apiUrl + 'teaching-aids');
    }

    getTeachingAidTypes() {
        return this.http.get(this.appUrl + this.apiUrl + 'teaching-aid-types');
    }

    getStrategyMethods() {
        return this.http.get(this.appUrl + this.apiUrl + 'strategy-methods');
    }

    getStrategyMethodTypes() {
        return this.http.get(this.appUrl + this.apiUrl + 'strategy-method-types');
    }

    getLaTypes() {
        return this.http.get(this.appUrl + this.apiUrl + 'la-types');
    }

    getLaPerformances() {
        return this.http.get(this.appUrl + this.apiUrl + 'la-performances');
    }

    getLaCollaborations() {
        return this.http.get(this.appUrl + this.apiUrl + 'la-collaborations');
    }

    getKeywords() {
        return this.http.get(this.appUrl + this.apiUrl + 'keywords');
    }
}
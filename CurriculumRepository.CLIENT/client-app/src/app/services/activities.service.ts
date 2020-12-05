import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { environment } from 'src/environments/environment';
import { UpdateLaBM } from '../models/activity/UpdateLaBM';
import { LaBM } from '../models/activity/LaBM';
import { Observable } from 'rxjs';
import { LaDTO } from '../models/activity/LaDTO';

@Injectable({ providedIn: 'root' })
export class ActivitiesService {
  appUrl: string;
  apiUrl: string;
  apiUrl2: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
    this.appUrl = environment.host;
    this.apiUrl = 'api/scenarios/'
    this.apiUrl2 = '/Activities/'
  }

  getActivity(scenarioId: number, activityId: number) : Observable<LaDTO>{
      return this.http.get<LaDTO>(this.appUrl + this.apiUrl + scenarioId + this.apiUrl2 + activityId)
  }

  getActivities(scenarioId: number, activityId: number) : Observable<LaDTO[]>{
      return this.http.get<LaDTO[]>(this.appUrl + this.apiUrl + scenarioId + this.apiUrl2 + activityId)
  }

  delete(scenarioId: number, activityId: number) {
      return this.http.delete(this.appUrl + this.apiUrl + scenarioId + this.apiUrl2 + activityId);
  }

  update(scenarioId: number, activityId: number, model: UpdateLaBM) {
      return this.http.patch(this.appUrl + this.apiUrl + scenarioId + this.apiUrl2 + activityId, model);
  }

  create(scenarioId: number, model: LaBM) {
      return this.http.post(this.appUrl + this.apiUrl + scenarioId + this.apiUrl2, model);
  }
}
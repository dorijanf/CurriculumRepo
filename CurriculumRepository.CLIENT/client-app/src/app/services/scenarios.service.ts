import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { environment } from 'src/environments/environment';
import { QueryParameters } from '../models/QueryParameters';
import { LsListDTO } from '../models/scenario/LsListDTO';
import { Observable } from 'rxjs';
import { LsBM } from '../models/scenario/LsBM';
import { LsDTO } from '../models/scenario/LsDTO';

@Injectable({ providedIn: 'root' })
export class ScenariosService {
    appUrl: string;
    apiUrl: string;
    httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json; charset=utf-8'
      })
    };
    constructor(private http: HttpClient) {
      this.appUrl = environment.host;
      this.apiUrl = 'api/Scenarios/'
    }

    getScenario(scenarioId: number) : Observable<LsDTO> {
        return this.http.get<LsDTO>(this.appUrl + this.apiUrl + scenarioId)
    }

    getScenarios(queryParameters: QueryParameters) : Observable<LsListDTO[]>{
        let queryString = this.appUrl + this.apiUrl +
        '?pagenumber=' + queryParameters.PageNumber +
        '&pageSize=' + queryParameters.PageSize + 
        '&orderBy=' + queryParameters.OrderBy;

        if(queryParameters.Lsname != undefined || queryParameters.Lsname != null) {
            queryString = queryString + '&lsname=' + queryParameters.Lsname;
        }

        if(queryParameters.Keyword != undefined || queryParameters.Keyword != null) {
            queryString = queryString + '&keyword=' + queryParameters.Keyword;
        }

        if(queryParameters.Lsgrade != undefined || queryParameters.Lsgrade != null) {
            queryString = queryString + '&grade=' + queryParameters.Lsgrade;
        }

        if(queryParameters.TeachingSubjectId != undefined || queryParameters.TeachingSubjectId != null){
            queryString = queryString + '&teachingSubjectId=' + queryParameters.TeachingSubjectId;
        }
        console.log(queryString);
        return this.http.get<LsListDTO[]>(queryString);
    }

    getUserScenarios(userId: string) : Observable<LsListDTO[]>{
        return this.http.get<LsListDTO[]>(this.appUrl + this.apiUrl + 'user/' + userId);
    }

    delete(scenarioId: number) : Observable<any> {
        return this.http.delete<any>(this.appUrl + this.apiUrl + scenarioId);
    }

    update(scenarioId: number, model: LsBM) {
        return this.http.patch(this.appUrl + this.apiUrl + scenarioId, model);
    }

    create(model: LsBM) : Observable<any> {
        return this.http.post<any>(this.appUrl + this.apiUrl, model);
    }

    getScenariosCount(queryParameters: QueryParameters) : Observable<any> {
        let queryString = this.appUrl + this.apiUrl + 'count?'
        '&pagenumber=' + queryParameters.PageNumber +
        '&pageSize=' + queryParameters.PageSize + 
        '&orderBy=' + queryParameters.OrderBy;

        if(queryParameters.Lsname != undefined || queryParameters.Lsname != null) {
            queryString = queryString + '&lsname=' + queryParameters.Lsname;
        }

        if(queryParameters.Keyword != undefined || queryParameters.Keyword != null) {
            queryString = queryString + '&keyword=' + queryParameters.Keyword;
        }

        if(queryParameters.Lsgrade != undefined || queryParameters.Lsgrade != null) {
            queryString = queryString + '&grade=' + queryParameters.Lsgrade;
        }

        if(queryParameters.TeachingSubjectId != undefined || queryParameters.TeachingSubjectId != null){
            queryString = queryString + '&teachingSubjectId=' + queryParameters.TeachingSubjectId;
        }
        return this.http.get<any>(queryString);
    }
}
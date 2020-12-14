import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { AuthenticateUserDTO } from 'src/app/models/account/AuthenticateUserDTO'
import { environment } from 'src/environments/environment';
import { RegisterUserBM } from '../models/account/RegisterUserBM';
import { UpdateUserBM } from '../models/account/UpdateUserBm';
import { BehaviorSubject, Observable } from 'rxjs';
import { UserDTO } from '../models/account/UserDTO';
import { AuthenticationResponseDTO } from '../models/account/AuthenticationResponseDTO';

@Injectable({ providedIn: 'root' })
export class AccountService {
  private currentUserSubject: BehaviorSubject<AuthenticationResponseDTO>;
  appUrl: string;
  apiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<AuthenticationResponseDTO>(JSON.parse(localStorage.getItem('currentUser')));
    this.appUrl = environment.host;
    this.apiUrl = 'api/Account/'
  }

  public get currentUserValue(): AuthenticationResponseDTO {
    return this.currentUserSubject.value;
  }

  public get currentUser(): Observable<AuthenticationResponseDTO> {
    return this.currentUserSubject.asObservable();
  }

  public isLoggedIn() {
    return this.currentUserSubject.subscribe() !== null || this.currentUserSubject.subscribe !== undefined ? true : false;
  }

  authenticate(model: AuthenticateUserDTO): Observable<AuthenticationResponseDTO> {
    return this.http.post<AuthenticationResponseDTO>(this.appUrl + this.apiUrl + 'authenticate', model)
      .pipe(map(user => {
        localStorage.setItem('currentUser', JSON.stringify(user))
        this.currentUserSubject.next(user);
        return user;
      }))
  }

  register(model: RegisterUserBM) {
    return this.http.post(this.appUrl + this.apiUrl + 'register', model);
  }

  getUser(id: string): Observable<UserDTO> {
    return this.http.get<UserDTO>(this.appUrl + this.apiUrl + id);
  }

  delete(id: string) {
    return this.http.delete(this.appUrl + this.apiUrl + id);
  }

  update(model: UpdateUserBM) {
    return this.http.patch(this.appUrl + this.apiUrl, model);
  }

  logout() {
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }
}
import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
    } from '@angular/common/http';
    import { Observable, throwError } from 'rxjs';
    import { retry, catchError } from 'rxjs/operators';
    import { Router } from '@angular/router';
    import { Injectable } from '@angular/core';
import { AccountService } from './app/services/account.service';
import { ResponseDTO } from './app/models/ResponseDTO';
    
    @Injectable()
    export class HttpErrorInterceptor implements HttpInterceptor {
    
      constructor(private router: Router, private accountService: AccountService){
    
      }
    
      intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      return next.handle(request)
        .pipe(
          retry(1),
          catchError((error: ResponseDTO) => {
            let errorMessage = '';
            if (error.StatusCode != null) {
              // client-side error
              errorMessage = `${error['error'].Message}`;
            } else {
              // server-side error
              errorMessage = `${error['error'].Message}`;
            }
            if(error.StatusCode == 404){
              this.router.navigate(['404']);
            }
    
            if(error.StatusCode === 401) {
              this.router.navigate(['404']);
              this.accountService.logout();
            }
            return throwError(errorMessage);
          })
        )
      }
    }
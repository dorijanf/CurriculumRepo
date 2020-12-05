import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
    HttpErrorResponse
    } from '@angular/common/http';
    import { Observable, throwError } from 'rxjs';
    import { retry, catchError } from 'rxjs/operators';
    import { Router } from '@angular/router';
    import { Injectable } from '@angular/core';
import { AccountService } from './app/services/account.service';
    
    @Injectable()
    export class HttpErrorInterceptor implements HttpInterceptor {
    
      constructor(private router: Router, private accountService: AccountService){
    
      }
    
      intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      return next.handle(request)
        .pipe(
          retry(1),
          catchError((error: HttpErrorResponse) => {
            let errorMessage = '';
            if (error.error instanceof ErrorEvent) {
              // client-side error
              errorMessage = `Error: ${error.error.message}`;
            } else {
              // server-side error
              errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
            }
            if(error.status == 404){
              this.router.navigate(['404']);
            }
    
            if(error.status === 401) {
              this.accountService.logout();
              this.router.navigate(['/']);
            }
            return throwError(errorMessage);
          })
        )
      }
    }
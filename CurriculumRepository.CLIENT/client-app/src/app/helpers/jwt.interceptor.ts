import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

import { AccountService } from '../services/account.service';
import { environment } from 'src/environments/environment';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private accountService: AccountService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add authorization header with jwt token if available
        let currentUser = this.accountService.currentUser;
        const isLoggedIn = this.accountService.currentUserValue !== null;
        if (isLoggedIn) {
            currentUser.subscribe(user => {
                request = request.clone({
                    setHeaders: {
                        Authorization: `Bearer ${user['token']}`
                    }
                });
            });
        }

        return next.handle(request);
    }
}
import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { UserTypeEnum } from 'src/enums/user-type-enum';
import { AccountService } from '../services/account.service';

@Injectable({ providedIn: 'root' })
export class AuthGuardAdministrator implements CanActivate {
    constructor(private router: Router,private authenticationService: AccountService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const currentUser = this.authenticationService.currentUserValue;
        if (currentUser && currentUser.UserTypeId == UserTypeEnum.Administrator) {
            // logged in so return true
            return true;
        }

        // not logged in so redirect to login page with the return url
        this.router.navigate(['/'], { queryParams: { returnUrl: state.url } });
        return false;
    }
}
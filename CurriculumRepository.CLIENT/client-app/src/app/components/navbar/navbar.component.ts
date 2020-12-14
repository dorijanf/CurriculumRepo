import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AuthenticationResponseDTO } from 'src/app/models/account/AuthenticationResponseDTO';
import { AccountService } from 'src/app/services/account.service';
import { UserTypeEnum } from 'src/enums/user-type-enum';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})

export class NavbarComponent implements OnInit, OnChanges {
  IsAdmin: UserTypeEnum.Administrator;
  currentUser: AuthenticationResponseDTO;
  navbarOpen = false;
  constructor(public authenticationService: AccountService, private router: Router) {
  }
  ngOnChanges(): void {
    this.setValue();
  }
  ngOnInit(): void {
    this.setValue();
  }

  toggleNavbar() {
    this.navbarOpen = !this.navbarOpen;
  }

  setValue() {
    if(this.authenticationService.isLoggedIn){
      this.authenticationService.currentUser.pipe(
        tap(user => {
          if (user) {
            this.currentUser = user;
          } else {
            this.currentUser = null;
          }
        })
      )
      .subscribe()
    }
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/']);
  }

}

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationResponseDTO } from 'src/app/models/account/AuthenticationResponseDTO';
import { AccountService } from 'src/app/services/account.service';
import { UserTypeEnum } from 'src/enums/user-type-enum';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})

export class NavbarComponent implements OnInit {
  IsAdmin: UserTypeEnum.Administrator;
  currentUser: AuthenticationResponseDTO;
  currentUserId: number;
  navbarOpen = false;
  constructor(public authenticationService: AccountService, private router: Router) {
    this.authenticationService.currentUser.subscribe(x => x = x);
    if(this.currentUser != undefined || this.currentUser != null){
      this.currentUserId = this.currentUser.Iduser;
    }
    console.log(this.currentUser);
  }
  ngOnInit(): void {
  }

  toggleNavbar() {
    this.navbarOpen = !this.navbarOpen;
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/']);
  }

}

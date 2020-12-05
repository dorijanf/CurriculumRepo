import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AccountService } from 'src/app/services/account.service';
import { AuthenticateUserDTO } from 'src/app/models/account/AuthenticateUserDTO';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';
  statusMessage: string;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private accountService: AccountService
  ) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
    if (this.router.url === '/login') {
      this.returnUrl = '/';
    }
    else {
      this.returnUrl = this.router.url;
    }
  }

  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    let authUser = <AuthenticateUserDTO>{
      Username: this.f.username.value,
      Password: this.f.password.value
    };
    this.loading = true;
    this.accountService.authenticate(authUser)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigateByUrl(this.returnUrl);
        },
        error => {
          this.error = error;
          this.loading = false;
        });
  }
}
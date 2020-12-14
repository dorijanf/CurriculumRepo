import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AccountService } from 'src/app/services/account.service';
import { RegisterUserBM } from 'src/app/models/account/RegisterUserBM';
import { ResponseDTO } from 'src/app/models/ResponseDTO';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  model: RegisterUserBM = new RegisterUserBM();
  loading = false;
  submitted = false;
  returnUrl: string;
  error: string;
  title: string = "Register";

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService
  ) {
  }

  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  onSubmit() {
    this.submitted = true;

    this.loading = true;
    this.accountService.register(this.model)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate(['/login']);
        },
        (error: string) => {
          this.error = error;
          this.loading = false;
        });
  }
}
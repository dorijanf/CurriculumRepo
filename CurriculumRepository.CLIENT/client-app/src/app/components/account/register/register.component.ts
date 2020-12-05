import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AccountService } from 'src/app/services/account.service';
import { RegisterUserBM } from 'src/app/models/account/RegisterUserBM';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';
  title: string = "Register";

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService
  ) {
  }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      Firstname: ['', Validators.required],
      Lastname: ['', Validators.required],
      Username: ['', Validators.required,
                     Validators.minLength(5),
                     Validators.maxLength(14)],
      Email: ['', Validators.required],
      Password: ['', Validators.required],
      RepeatPassword: ['', Validators.required],
      ProfilePicture: [null]
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get f() { return this.registerForm.controls; }

  onSubmit() {
    this.submitted = true;

    if (this.registerForm.invalid) {
      return;
    }

    this.f.username.value, this.f.email.value, this.f.password.value
    let registerUser = <RegisterUserBM>{
      Firstname: this.f.Firstname.value,
      Lastname: this.f.Lastname.value,
      Username: this.f.Username.value,
      Email: this.f.Email.value,
      Password: this.f.Password.value,
      ProfilePicture: this.f.ProfilePicture.value
    };
    this.loading = true;
    this.accountService.register(registerUser)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate(['/login']);
        },
        (error: any) => {
          this.error = error;
          this.loading = false;
        });
  }
}
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './components/account/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './components/account/register/register.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ActivitiesService } from './services/activities.service';
import { DataService } from './services/data.service';
import { ScenariosService } from './services/scenarios.service';
import { AccountService } from './services/account.service';
import { NotFound404Component } from './components/errors/not-found404/not-found404.component';
import { LearningScenarioComponent } from './components/learning-scenario/learning-scenario/learning-scenario.component';
import { LearningScenariosComponent } from './components/learning-scenario/learning-scenarios/learning-scenarios.component';
import { LearningScenarioCreateComponent } from './components/learning-scenario/learning-scenario-create/learning-scenario-create.component';
import { MyProfileComponent } from './components/account/my-profile/my-profile.component';
import { LearningActivityComponent } from './components/learning-activity/learning-activity/learning-activity.component';
import { LearningActivitiesComponent } from './components/learning-activity/learning-activities/learning-activities.component';
import { LearningActivityCreateComponent } from './components/learning-activity/learning-activity-create/learning-activity-create.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HomeComponent } from './components/home/home.component';
import { HttpErrorInterceptor } from 'src/http-error.interceptor';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { MustMatchDirective } from './helpers/must-match.directive';
import { NgSelectModule } from '@ng-select/ng-select';
import { PaginationService } from './services/pagination.service';
import { ConfirmationModalComponent } from './components/confirmation-modal/confirmation-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LoginComponent,
    RegisterComponent,
    NotFound404Component,
    LearningScenarioComponent,
    LearningScenariosComponent,
    LearningScenarioCreateComponent,
    MyProfileComponent,
    LearningActivityComponent,
    LearningActivitiesComponent,
    LearningActivityCreateComponent,
    HomeComponent,
    MustMatchDirective,
    ConfirmationModalComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    NgbModule,
    FontAwesomeModule,
    NgSelectModule
  ],
  providers: [
    AccountService,
    ActivitiesService,
    DataService,
    ScenariosService,
    PaginationService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    },
  ],
  bootstrap: [AppComponent],
  entryComponents: [ConfirmationModalComponent],
})
export class AppModule { }

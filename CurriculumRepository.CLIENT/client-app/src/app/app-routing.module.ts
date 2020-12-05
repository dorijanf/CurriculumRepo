import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EditProfileComponent } from './components/account/edit-profile/edit-profile.component';
import { LoginComponent } from './components/account/login/login.component';
import { MyProfileComponent } from './components/account/my-profile/my-profile.component';
import { RegisterComponent } from './components/account/register/register.component';
import { NotFound404Component } from './components/errors/not-found404/not-found404.component';
import { HomeComponent } from './components/home/home.component';
import { LearningActivitiesComponent } from './components/learning-activity/learning-activities/learning-activities.component';
import { LearningActivityComponent } from './components/learning-activity/learning-activity/learning-activity.component';
import { LearningScenarioCreateComponent } from './components/learning-scenario/learning-scenario-create/learning-scenario-create.component';
import { LearningScenarioComponent } from './components/learning-scenario/learning-scenario/learning-scenario.component';
import { LearningScenariosComponent } from './components/learning-scenario/learning-scenarios/learning-scenarios.component';
import { AuthGuardAdministrator } from './helpers/auth-guard-administrator.service';
import { AuthGuard } from './helpers/auth-guard.service';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full'},
  { path: 'register', component: RegisterComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent, pathMatch: 'full' },
  { path: 'profile/:userId', component: MyProfileComponent, pathMatch: 'full', canActivate: [AuthGuard]},
  { path: 'profile/edit/:userId', component: EditProfileComponent, pathMatch: 'full', canActivate: [AuthGuard]},
  { path: '404', component: NotFound404Component, pathMatch: 'full'},
  { path: 'scenarios', component: LearningScenariosComponent, pathMatch: 'full', canActivate: [AuthGuard]},
  { path: 'scenarios/:scenarioId', component: LearningScenarioComponent, pathMatch: 'full', canActivate: [AuthGuard]},
  { path: 'scenarios/create', component: LearningScenarioCreateComponent, pathMatch: 'full', canActivate: [AuthGuard]},
  { path: 'activities/:activityId', component: LearningActivityComponent, pathMatch: 'full', canActivate: [AuthGuard]},
  { path: 'activities', component: LearningActivitiesComponent, pathMatch: 'full', canActivate: [AuthGuard]},
  { path: 'activities/user/:userId', component: LearningActivitiesComponent, pathMatch: 'full', canActivate: [AuthGuard]},
  { path: 'activities/create/', component: LearningActivitiesComponent, pathMatch: 'full', canActivate: [AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

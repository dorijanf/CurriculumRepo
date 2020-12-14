import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { UserDTO } from 'src/app/models/account/UserDTO';
import { LsDTO } from 'src/app/models/scenario/LsDTO';
import { AccountService } from 'src/app/services/account.service';
import { ScenariosService } from 'src/app/services/scenarios.service';
import { faEdit, faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { tap } from 'rxjs/operators';
import { AuthenticationResponseDTO } from 'src/app/models/account/AuthenticationResponseDTO';

@Component({
  selector: 'app-learning-scenario',
  templateUrl: './learning-scenario.component.html',
  styleUrls: ['./learning-scenario.component.scss']
})
export class LearningScenarioComponent implements OnInit {
  faEdit = faEdit;
  faPlusCircle = faPlusCircle;
  model$: Observable<LsDTO>;
  user$: Observable<UserDTO>;
  scenarioId: number;
  currentUser: AuthenticationResponseDTO;
  
  constructor(private scenariosService: ScenariosService, private route: ActivatedRoute, private authenticationService: AccountService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.scenarioId = params['id'];
    })
    this.loadLs();
    this.setUserValue();
  }

  loadLs() {
    this.model$ = this.scenariosService.getScenario(this.scenarioId);
    this.scenariosService.getScenario(this.scenarioId).subscribe(x => {
      this.user$ = this.authenticationService.getUser(x['userId']);
    })
  }

  setUserValue() {
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
}


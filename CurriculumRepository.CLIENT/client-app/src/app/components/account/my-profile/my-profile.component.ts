import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Data } from '@angular/router';
import { faEdit } from '@fortawesome/free-solid-svg-icons';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { UserDTO } from 'src/app/models/account/UserDTO';
import { LsListDTO } from 'src/app/models/scenario/LsListDTO';
import { AccountService } from 'src/app/services/account.service';
import { DataService } from 'src/app/services/data.service';
import { ScenariosService } from 'src/app/services/scenarios.service';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.scss']
})
export class MyProfileComponent implements OnInit {
  faEdit = faEdit;
  userInfo$: Observable<UserDTO>;
  scenarios$: Observable<LsListDTO[]>;
  teachingSubjects$: any;
  userId: string;
  constructor(private route: ActivatedRoute, private accountService: AccountService, private scenariosService: ScenariosService, private dataService: DataService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.userId = params['id'];
    })
    this.loadUser();
    this.loadScenarios();
    this.loadDropdowns();
  }

  loadUser() {
    this.userInfo$ = this.accountService.getUser(this.userId);
  }

  loadScenarios() {
    this.scenarios$ = this.scenariosService.getUserScenarios(this.userId);
  }

  loadDropdowns() {
    this.teachingSubjects$ = this.dataService.getTeachingAids();
  }
}

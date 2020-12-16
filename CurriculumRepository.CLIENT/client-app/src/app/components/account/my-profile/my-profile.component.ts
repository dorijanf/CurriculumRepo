import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AuthenticationResponseDTO } from 'src/app/models/account/AuthenticationResponseDTO';
import { UserDTO } from 'src/app/models/account/UserDTO';
import { LsListDTO } from 'src/app/models/scenario/LsListDTO';
import { AccountService } from 'src/app/services/account.service';
import { DataService } from 'src/app/services/data.service';
import { ScenariosService } from 'src/app/services/scenarios.service';
import { ConfirmationModalComponent } from '../../confirmation-modal/confirmation-modal.component';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.scss']
})
export class MyProfileComponent implements OnInit {
  faEdit = faEdit;
  faTrash = faTrash;
  userInfo$: Observable<UserDTO>;
  scenarios$: Observable<LsListDTO[]>;
  teachingSubjects$: any;
  userId: string;
  currentUser: AuthenticationResponseDTO;
  constructor(private authenticationService: AccountService, 
    private modalService: NgbModal, 
    private route: ActivatedRoute, 
    private accountService: AccountService, 
    private scenariosService: ScenariosService, 
    private dataService: DataService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.userId = params['id'];
    })
    this.loadUser();
    this.setUserValue();
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

  setUserValue() {
    if (this.authenticationService.isLoggedIn) {
      this.authenticationService.currentUser.pipe(
        tap(user => {
          if (user) {
            console.log(user);
            this.currentUser = user;
          } else {
            this.currentUser = null;
          }
        })
      )
        .subscribe()
    }
  }

  public deleteScenario(entity: string, id: number) {
    const modalRef = this.modalService.open(ConfirmationModalComponent);
    modalRef.componentInstance.entity = entity;
    modalRef.componentInstance.scenarioId = id;
  }
}

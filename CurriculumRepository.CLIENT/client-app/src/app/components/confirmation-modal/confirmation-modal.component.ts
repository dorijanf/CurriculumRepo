import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { first } from 'rxjs/operators';
import { ActivitiesService } from 'src/app/services/activities.service';
import { ScenariosService } from 'src/app/services/scenarios.service';

@Component({
  selector: 'app-confirmation-modal',
  templateUrl: './confirmation-modal.component.html',
  styleUrls: ['./confirmation-modal.component.scss']
})

export class ConfirmationModalComponent implements OnInit {

  @Input() activityId;
  @Input() scenarioId;
  @Input() entity;
  constructor(public activeModal: NgbActiveModal, 
    private scenarioService: ScenariosService, 
    private activitiesService: ActivitiesService, 
    private router: Router) { }

  ngOnInit(): void {
  }

  confirm() {
    if (this.entity === "activity") {
      this.activeModal.close();
      this.deleteActivity(this.scenarioId, this.activityId);
    }
    else {
      this.activeModal.close();
      this.deleteScenario(this.scenarioId);
    }
  }

  deleteActivity(scenarioId: number, activityId: number) {
    this.activitiesService.delete(scenarioId, activityId)
      .pipe(first())
      .subscribe(
        data => {
          window.location.reload();
        },
        (error: string) => {
          console.log(error);
        }
      )
  }

  deleteScenario(activityId: number) {
    this.scenarioService.delete(activityId)
      .pipe(first())
      .subscribe(
        data => {
          window.location.reload();
        },
        (error: string) => {
          console.log(error);
        }
      )
  }

}

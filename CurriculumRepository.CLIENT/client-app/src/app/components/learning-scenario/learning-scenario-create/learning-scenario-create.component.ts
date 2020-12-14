import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { Ls } from 'src/app/models/scenario/Ls';
import { DataService } from 'src/app/services/data.service';
import { ScenariosService } from 'src/app/services/scenarios.service';
import { faInfo, faGraduationCap, faLink, faPlus, faTimes, faAngleUp, faAngleDown } from '@fortawesome/free-solid-svg-icons';
import { outcome } from 'src/app/models/scenario/outcome';
import { LsBM } from 'src/app/models/scenario/LsBM';
declare var $: any;

@Component({
  selector: 'app-learning-scenario-create',
  templateUrl: './learning-scenario-create.component.html',
  styleUrls: ['./learning-scenario-create.component.scss']
})
export class LearningScenarioCreateComponent implements OnInit {

  //** Models */
  model: Ls = new Ls();
  teachingSubjects: any;
  keywords: any;
  grades: number[];

  //** Configuration */
  loading = false;
  submitted = false;
  returnUrl: string;
  error: string;
  title: string = "Create Scenario";

  //** Outcome counters */
  loSubject: number = 0;
  loCt: number = 0;

  //** Font awesome icons */
  faInfo = faInfo;
  faPlus = faPlus;
  faGraduationCap = faGraduationCap;
  faLink = faLink;
  faAngleUp = faAngleUp;
  faAngleDown = faAngleDown;
  faTimes = faTimes;

  //** Error handling */
  lsGradeHasError = true;
  teachingSubjectHasError = true;

  constructor(private scenariosService: ScenariosService,
    private router: Router,
    private dataService: DataService) { }

  ngOnInit(): void {
    this.model.LearningOutcomeCts.push(new outcome());
    this.model.LearningOutcomeSubjects.push(new outcome());
    this.getDropdowns();
    this.jqueryFunctions();
  }

  validateTeachingSubject(value) {
    if (value === 0) {
      this.teachingSubjectHasError = true;
    } else {
      this.teachingSubjectHasError = false;
    }
  }

  validateLsGrade(value) {
    if (value === 0) {
      this.lsGradeHasError = true;
    } else {
      this.lsGradeHasError = false;
    }
  }

  onNext() {
    this.submitted = true;
  }

  onSubmit() {
    this.submitted = true;

    this.loading = true;

    let loSubjects: string[] = [];
    let loCts: string[] = [];
    let keywords: string[] = [];
    this.model.LearningOutcomeSubjects.forEach(x => loSubjects.push(x.value));
    this.model.LearningOutcomeCts.forEach(x => loCts.push(x.value));
    this.model.Keywords.forEach(x => {
      if(x['label'] != null || x['label'] != undefined){
        keywords.push(x['label']);
      }
      else {
        keywords.push(x);
      }
    })

    const model: LsBM = {
      Lsname: this.model.Lsname,
      Lsdescription: this.model.Lsdescription,
      LsTypeId: this.model.LsTypeId,
      Lsgrade: this.model.Lsgrade,
      TeachingSubjectId: this.model.TeachingSubjectId,
      LearningOutcomeSubjects: loSubjects,
      LearningOutcomeCts: loCts,
      CorrelationSubjectIds: this.model.CorrelationSubjectIds,
      Keywords: keywords
    }

    this.scenariosService.create(model)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate(['scenarios/', data['scenarioId']]);
        },
        (error: string) => {
          this.error = error;
          this.loading = false;
        });
  }

  getDropdowns() {
    this.dataService.getTeachingSubjects().subscribe(teachingSubject => {
      this.teachingSubjects = teachingSubject;
    })

    this.dataService.getKeywords().subscribe(keywords => {
      this.keywords = keywords;
    })

    this.grades = [1, 2, 3, 4, 5, 6, 7, 8];
  };

  removeLoSubject(index: number) {
    this.model.LearningOutcomeSubjects.splice(index, 1);
    this.loSubject -= 1;
  }

  removeLoCt(index: number) {
    this.model.LearningOutcomeCts.splice(index, 1);
    this.loCt -= 1;
  }

  addLoSubject() {
    if (this.loSubject < 10) {
      this.model.LearningOutcomeSubjects.push(new outcome());
      this.loSubject += 1;
    }
    else {
      console.log("Možete unijeti maksimalno 10 ishoda učenaja");
    }
  }

  addLoCt() {
    if (this.loCt < 10) {
      this.model.LearningOutcomeCts.push(new outcome());
      this.loCt += 1;
    }
    else {
      console.log("Možete unijeti maksimalno 10 ishoda učenaja");
    }
  }

  moveUpLoSubject(index: number) {
    this.swapLoSubject(index, index - 1);
  }

  moveUpLoCt(index: number) {
    this.swapLoCt(index, index - 1);
  }

  moveDownLoSubject(index: number) {
    this.swapLoSubject(index, index + 1);
  }

  moveDownLoCt(index: number) {
    this.swapLoCt(index, index + 1);
  }

  private swapLoCt(x: any, y: any) {
    var temp = this.model.LearningOutcomeCts[x];
    this.model.LearningOutcomeCts[x] = this.model.LearningOutcomeCts[y];
    this.model.LearningOutcomeCts[y] = temp;
  }

  private swapLoSubject(x: any, y: any) {
    var temp = this.model.LearningOutcomeSubjects[x];
    this.model.LearningOutcomeSubjects[x] = this.model.LearningOutcomeSubjects[y];
    this.model.LearningOutcomeSubjects[y] = temp;
  }

  jqueryFunctions() {
    function scroll_to_class(element_class, removed_height) {
      var scroll_to = $(element_class).offset().top - removed_height;
      if ($(window).scrollTop() != scroll_to) {
        $('html, body').stop().animate({ scrollTop: scroll_to }, 0);
      }
    }

    function bar_progress(progress_line_object, direction) {
      var number_of_steps = progress_line_object.data('number-of-steps');
      var now_value = progress_line_object.data('now-value');
      var new_value = 0;
      if (direction == 'right') {
        new_value = now_value + (100 / number_of_steps);
      }
      else if (direction == 'left') {
        new_value = now_value - (100 / number_of_steps);
      }
      progress_line_object.attr('style', 'width: ' + new_value + '%;').data('now-value', new_value);
    }

    $(document).ready(function () {
      /*
          Form
      */
      $('.f1 fieldset:first').fadeIn('slow');

      // next step
      $('.f1 .btn-next').on('click', function () {
        var parent_fieldset = $(this).parents('fieldset');
        var next_step = true;
        this.submitted = true;
        // navigation steps / progress steps
        var current_active_step = $(this).parents('.f1').find('.f1-step.active');
        var progress_line = $(this).parents('.f1').find('.f1-progress-line');

        // fields validation
        parent_fieldset.find('input[type="text"], input[type="password"], textarea, input[type="number"]').each(function () {
          if ($(this).val() == "") {
            next_step = false;
          }
        });

        parent_fieldset.find('select').each(function () {
          if ($(this).val() === "0: 0") {
            next_step = false;
          }
        });

        if (next_step && this.submitted) {
          parent_fieldset.fadeOut(400, function () {
            // change icons
            current_active_step.removeClass('active').addClass('activated').next().addClass('active');
            // progress bar
            bar_progress(progress_line, 'right');
            // show next step
            $(this).next().fadeIn();
            // scroll window to beginning of the form
            scroll_to_class($('.f1'), 20);
          });
        }

      });

      // previous step
      $('.f1 .btn-previous').on('click', function () {
        // navigation steps / progress steps
        var current_active_step = $(this).parents('.f1').find('.f1-step.active');
        var progress_line = $(this).parents('.f1').find('.f1-progress-line');

        $(this).parents('fieldset').fadeOut(400, function () {
          // change icons
          current_active_step.removeClass('active').prev().removeClass('activated').addClass('active');
          // progress bar
          bar_progress(progress_line, 'left');
          // show previous step
          $(this).prev().fadeIn();
          // scroll window to beginning of the form
          scroll_to_class($('.f1'), 20);
        });
      });
    });
  }
}

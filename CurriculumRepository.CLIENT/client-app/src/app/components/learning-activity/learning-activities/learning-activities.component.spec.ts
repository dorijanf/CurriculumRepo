import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LearningActivitiesComponent } from './learning-activities.component';

describe('LearningActivitiesComponent', () => {
  let component: LearningActivitiesComponent;
  let fixture: ComponentFixture<LearningActivitiesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LearningActivitiesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningActivitiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

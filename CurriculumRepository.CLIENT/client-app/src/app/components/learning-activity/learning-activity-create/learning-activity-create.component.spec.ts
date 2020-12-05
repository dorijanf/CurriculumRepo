import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LearningActivityCreateComponent } from './learning-activity-create.component';

describe('LearningActivityCreateComponent', () => {
  let component: LearningActivityCreateComponent;
  let fixture: ComponentFixture<LearningActivityCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LearningActivityCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningActivityCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

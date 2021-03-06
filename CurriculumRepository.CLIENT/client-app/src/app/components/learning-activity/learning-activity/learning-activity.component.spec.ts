import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LearningActivityComponent } from './learning-activity.component';

describe('LearningActivityComponent', () => {
  let component: LearningActivityComponent;
  let fixture: ComponentFixture<LearningActivityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LearningActivityComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningActivityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LearningScenarioComponent } from './learning-scenario.component';

describe('LearningScenarioComponent', () => {
  let component: LearningScenarioComponent;
  let fixture: ComponentFixture<LearningScenarioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LearningScenarioComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningScenarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

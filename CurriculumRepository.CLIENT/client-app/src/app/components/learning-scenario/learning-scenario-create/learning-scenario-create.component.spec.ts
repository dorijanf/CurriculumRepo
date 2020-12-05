import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LearningScenarioCreateComponent } from './learning-scenario-create.component';

describe('LearningScenarioCreateComponent', () => {
  let component: LearningScenarioCreateComponent;
  let fixture: ComponentFixture<LearningScenarioCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LearningScenarioCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningScenarioCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

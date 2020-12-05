import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LearningScenariosComponent } from './learning-scenarios.component';

describe('LearningScenariosComponent', () => {
  let component: LearningScenariosComponent;
  let fixture: ComponentFixture<LearningScenariosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LearningScenariosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningScenariosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

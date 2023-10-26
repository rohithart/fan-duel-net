import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubHeadingComponent } from './sub-heading.component';

describe('SubHeadingComponent', () => {
  let component: SubHeadingComponent;
  let fixture: ComponentFixture<SubHeadingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubHeadingComponent ]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubHeadingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });
});

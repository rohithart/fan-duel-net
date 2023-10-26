import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';

import { SportComponent } from './sport.component';
import { SharedModule } from 'src/app/shared/modules/shared.module';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('SportComponent', () => {
  let component: SportComponent;
  let fixture: ComponentFixture<SportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ SharedModule, HttpClientTestingModule ],
      declarations: [ SportComponent ],
      providers: [
        { provide: ActivatedRoute, useValue: { id: '123', snapshot: { params: { id: '1'}} } },
      ],
    })
    .compileComponents();

    fixture = TestBed.createComponent(SportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });
});

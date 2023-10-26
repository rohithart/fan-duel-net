import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';

import { SharedModule } from 'src/app/shared/modules/shared.module';
import { TeamComponent } from './team.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('TeamComponent', () => {
  let component: TeamComponent;
  let fixture: ComponentFixture<TeamComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ SharedModule, ToastrModule.forRoot(), HttpClientTestingModule, ],
      declarations: [ TeamComponent ],
      providers: [
        { provide: MatDialogRef, useValue: {} },
        { provide: MAT_DIALOG_DATA, useValue: {} },
        { provide: ActivatedRoute, useValue: { id: '123', snapshot: { params: { id: '1'}} } },
      ],
    })
    .compileComponents();

    fixture = TestBed.createComponent(TeamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { SharedModule } from 'src/app/shared/modules/shared.module';
import { Team } from 'src/app/models/Team';
import { Sport } from 'src/app/models/Sport';
import { AddPlayerModalComponent } from './add-player-modal.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

describe('AddPlayerModalComponent', () => {
  let component: AddPlayerModalComponent;
  let fixture: ComponentFixture<AddPlayerModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ SharedModule, NoopAnimationsModule ],
      declarations: [ AddPlayerModalComponent ],
      providers: [
        { provide: MatDialogRef, useValue: {} },
        { provide: MAT_DIALOG_DATA, useValue: { team: new Team('1', 'team-name', {} as Sport)} },
      ],
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPlayerModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { SharedModule } from 'src/app/shared/modules/shared.module';
import { Player } from 'src/app/models/Player';
import { Team } from 'src/app/models/Team';
import { AddDepthModalComponent } from './add-depth-modal.component';

describe('AddDepthModalComponent', () => {
  let component: AddDepthModalComponent;
  let fixture: ComponentFixture<AddDepthModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ SharedModule, NoopAnimationsModule ],
      declarations: [ AddDepthModalComponent ],
      providers: [
        { provide: MatDialogRef, useValue: {} },
        { provide: MAT_DIALOG_DATA, useValue: { player: new Player('1', 10, 'name', {'sport': {'id': '1', name: 'team-name' }} as Team)} },
      ],
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddDepthModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });
});

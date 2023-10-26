import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';

import { MaterialModule } from 'src/app/shared/modules/material.module';
import { Player } from 'src/app/models/Player';
import { Team } from 'src/app/models/Team';
import { PlayerCardComponent } from './player-card.component';


describe('PlayerCardComponent', () => {
  let component: PlayerCardComponent;
  let fixture: ComponentFixture<PlayerCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ MaterialModule ],
      declarations: [ PlayerCardComponent ],
      providers: [
        { provide: ActivatedRoute, useValue: { id: '123' } },
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlayerCardComponent);
    component = fixture.componentInstance;
    component.player = new Player('', 10, 'Name', {} as Team);
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });
});

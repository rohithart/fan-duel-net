import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';

import { MaterialModule } from 'src/app/shared/modules/material.module';
import { Player } from 'src/app/models/Player';
import { Team } from 'src/app/models/Team';
import { PlayerDepthCardComponent } from './player-depth-card.component';


describe('PlayerDepthCardComponent', () => {
  let component: PlayerDepthCardComponent;
  let fixture: ComponentFixture<PlayerDepthCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ MaterialModule ],
      declarations: [ PlayerDepthCardComponent ],
      providers: [
        { provide: ActivatedRoute, useValue: { id: '123' } },
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlayerDepthCardComponent);
    component = fixture.componentInstance;
    component.player = new Player('', 10, 'Name', {} as Team);
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });
});

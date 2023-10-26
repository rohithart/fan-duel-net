import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';

import { APP_CONFIG, AppConfig } from 'src/app/configs/app.config';
import { SharedModule } from 'src/app/shared/modules/shared.module';

import { NavBarComponent } from './nav-bar.component';

describe('NavBarComponent', () => {
  let component: NavBarComponent;
  let fixture: ComponentFixture<NavBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ SharedModule ],
      declarations: [ NavBarComponent ],
      providers: [
        { provide: APP_CONFIG, useValue: AppConfig },
        { provide: ActivatedRoute, useValue: { id: '123' } },
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NavBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });
});

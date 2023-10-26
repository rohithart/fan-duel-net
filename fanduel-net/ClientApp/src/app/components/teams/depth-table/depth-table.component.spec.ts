import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SharedModule } from 'src/app/shared/modules/shared.module';
import { TeamDepth } from 'src/app/models/TeamDepth';
import { DepthTableComponent } from './depth-table.component';

describe('DepthTableComponent', () => {
  let component: DepthTableComponent;
  let fixture: ComponentFixture<DepthTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ SharedModule ],
      declarations: [ DepthTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DepthTableComponent);
    component = fixture.componentInstance;
    component.depth = {}  as  TeamDepth;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });
});

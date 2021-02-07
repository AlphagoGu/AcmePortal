import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { ActivityAddComponent } from './activity-add.component';

describe('ActivityAddComponent', () => {
  let component: ActivityAddComponent;
  let fixture: ComponentFixture<ActivityAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [FormsModule],
      declarations: [ ActivityAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActivityAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('form invalid when empty', () => {
    expect(component.model.Firstname).toBeFalsy();
    expect(component.model.Lastname).toBeFalsy();
    expect(component.model.Activity).toBeFalsy();
    expect(component.model.Comments).toBeFalsy();
  });
});

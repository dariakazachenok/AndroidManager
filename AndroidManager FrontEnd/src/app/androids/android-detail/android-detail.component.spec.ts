import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AndroidDetailComponent } from './android-detail.component';

describe('AndroidDetailComponent', () => {
  let component: AndroidDetailComponent;
  let fixture: ComponentFixture<AndroidDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AndroidDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AndroidDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

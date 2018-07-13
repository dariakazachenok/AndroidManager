import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AndroidsListComponent } from './androids-list.component';

describe('AndroidsListComponent', () => {
  let component: AndroidsListComponent;
  let fixture: ComponentFixture<AndroidsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AndroidsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AndroidsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

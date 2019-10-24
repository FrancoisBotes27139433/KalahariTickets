/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { OpenClientComponent } from './open-client.component';

describe('OpenClientComponent', () => {
  let component: OpenClientComponent;
  let fixture: ComponentFixture<OpenClientComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OpenClientComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OpenClientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

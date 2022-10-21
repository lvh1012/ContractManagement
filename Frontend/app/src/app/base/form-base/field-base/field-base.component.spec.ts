import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FieldBaseComponent } from './field-base.component';

describe('FieldBaseComponent', () => {
  let component: FieldBaseComponent;
  let fixture: ComponentFixture<FieldBaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FieldBaseComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FieldBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

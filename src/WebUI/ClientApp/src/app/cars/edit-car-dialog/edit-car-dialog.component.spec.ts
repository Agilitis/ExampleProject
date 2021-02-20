import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCarDialogComponent } from './edit-car-dialog.component';

describe('EditCarDialogComponent', () => {
  let component: EditCarDialogComponent;
  let fixture: ComponentFixture<EditCarDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditCarDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditCarDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

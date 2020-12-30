import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicePartnersComponent } from './service-partners.component';

describe('ServicePartnersComponent', () => {
  let component: ServicePartnersComponent;
  let fixture: ComponentFixture<ServicePartnersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ServicePartnersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ServicePartnersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

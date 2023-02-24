import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnimatedPlaceholderComponent } from './animated-placeholder.component';

describe('AnimatedPlaceholderComponent', () => {
  let component: AnimatedPlaceholderComponent;
  let fixture: ComponentFixture<AnimatedPlaceholderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AnimatedPlaceholderComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(AnimatedPlaceholderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

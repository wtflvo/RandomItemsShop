import { TestBed } from '@angular/core/testing';

import { FakeShopApiService } from './fake-shop-api.service';

describe('FakeShopApiService', () => {
  let service: FakeShopApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FakeShopApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

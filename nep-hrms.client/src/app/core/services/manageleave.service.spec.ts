import { TestBed } from '@angular/core/testing';

import { ManageleaveService } from './manageleave.service';

describe('ManageleaveService', () => {
  let service: ManageleaveService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ManageleaveService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

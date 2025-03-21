import { TestBed } from '@angular/core/testing';

import { EmpdashboardService } from './empdashboard.service';

describe('EmpdashboardService', () => {
  let service: EmpdashboardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmpdashboardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

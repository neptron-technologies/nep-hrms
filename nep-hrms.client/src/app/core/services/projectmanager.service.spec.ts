import { TestBed } from '@angular/core/testing';

import { ProjectManagerService } from './projectmanager.service';

describe('ProjectmanagerService', () => {
  let service: ProjectmanagerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProjectmanagerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

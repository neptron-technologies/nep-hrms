import { TestBed } from '@angular/core/testing';
import { LoginService,} from './service-login.service';

describe('ServiceLoginService', () => {
  let service: LoginService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoginService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

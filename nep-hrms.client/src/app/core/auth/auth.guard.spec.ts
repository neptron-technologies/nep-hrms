import { TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { DataTransferService } from '../services/data-transfer.service';

describe('AuthGuard', () => {
  let guard: AuthGuard;
  let dataService: jasmine.SpyObj<DataTransferService>;
  let router: jasmine.SpyObj<Router>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        AuthGuard,
        { provide: DataTransferService, useValue: jasmine.createSpyObj('DataTransferService', ['isLoggedIn']) },
        { provide: Router, useValue: jasmine.createSpyObj('Router', ['navigate']) },
      ],
    });

    guard = TestBed.inject(AuthGuard);
    dataService = TestBed.inject(DataTransferService) as jasmine.SpyObj<DataTransferService>;
    router = TestBed.inject(Router) as jasmine.SpyObj<Router>;
  });

  it('should allow access if logged in', () => {
    dataService.isLoggedIn.and.returnValue(true);
    expect(guard.canActivate()).toBeTrue();
  });

  it('should redirect to login if not logged in', () => {
    dataService.isLoggedIn.and.returnValue(false);
    expect(guard.canActivate()).toBeFalse();
    expect(router.navigate).toHaveBeenCalledWith(['/login']);
  });
});

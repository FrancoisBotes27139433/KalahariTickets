/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TechnitionServiceService } from './TechnitionService.service';

describe('Service: TechnitionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TechnitionServiceService]
    });
  });

  it('should ...', inject([TechnitionServiceService], (service: TechnitionServiceService) => {
    expect(service).toBeTruthy();
  }));
});

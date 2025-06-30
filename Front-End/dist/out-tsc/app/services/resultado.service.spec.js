import { TestBed } from '@angular/core/testing';
import { ResultadoService } from './resultado.service';
describe('ResultadoService', () => {
    let service;
    beforeEach(() => {
        TestBed.configureTestingModule({});
        service = TestBed.inject(ResultadoService);
    });
    it('should be created', () => {
        expect(service).toBeTruthy();
    });
});

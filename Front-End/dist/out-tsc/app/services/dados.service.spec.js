import { TestBed } from '@angular/core/testing';
import { ResultadoService } from './resultado.service'; // Certifique-se de que o caminho está correto
describe('ResultadoService', () => {
    let service;
    beforeEach(() => {
        TestBed.configureTestingModule({});
        service = TestBed.inject(ResultadoService);
    });
    it('should be created', () => {
        expect(service).toBeTruthy();
    });
    it('should calculate results correctly', () => {
        const initialValue = 1000;
        const months = 12;
        const expected = {
            taxesValue: 180, // Ajuste conforme a lógica real do serviço
            performanceValue: 1200 // Ajuste conforme a lógica real do serviço
        };
        const result = service.calculate(initialValue, months);
        expect(result.taxesValue).toBeCloseTo(expected.taxesValue, 2);
        expect(result.performanceValue).toBeCloseTo(expected.performanceValue, 2);
    });
});

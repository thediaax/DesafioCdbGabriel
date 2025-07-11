import { Component } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ResultadoDto } from './services/resultado.service'; // Ajuste o caminho conforme necessário

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    standalone: true,
    imports: [HttpClientModule, FormsModule, CommonModule]
})
export class AppComponent {
    valorInicial: number = 0
    meses: number = 0
    apiUrl: string = 'https://localhost:7088/simulacao/investimento/cdb'
    resultado: ResultadoDto | null = null
    loading: boolean = false
    errorMessage: string | null = null

    constructor(private http: HttpClient) {}

    enviarDados() {
        this.errorMessage = null; // Limpar mensagem de erro anterior

        if (this.valorInicial < 1 || this.meses < 1) {
            this.errorMessage = 'Os valores devem ser maiores ou iguais a 1.'
            console.error(this.errorMessage)
            return;
        }

        const dados = {
            InitialValue: this.valorInicial,
            RescueTime: this.meses,
        };

        this.loading = true; // Iniciar carregamento

        this.http.post<ResultadoDto>(this.apiUrl, dados).subscribe(
            (response) => {
                console.log('Resposta do servidor:', response)
                this.resultado = response
                console.log('Resultado a ser exibido:', this.resultado)
                this.loading = false
            },
            (error) => {
                console.error('Erro ao enviar os dados:', error)
                this.errorMessage = 'Ocorreu um erro ao enviar os dados. Tente novamente mais tarde.'
                this.loading = false
            }
        );
    }
}
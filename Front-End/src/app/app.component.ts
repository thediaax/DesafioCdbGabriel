import { Component } from '@angular/core'
import { HttpClientModule, HttpClient } from '@angular/common/http'
import { FormsModule } from '@angular/forms'
import { CommonModule } from '@angular/common'
import { ResultadoDto } from './services/resultado.service' // Ajuste o caminho conforme necessário

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    standalone: true,
    imports: [HttpClientModule, FormsModule, CommonModule]
})
export class AppComponent {
    valorInicial: number = 0;
    meses: number = 0;
    apiUrl: string = 'https://localhost:7088/Calculo'
    resultado: ResultadoDto | null = null

    constructor(private http: HttpClient) {}

    enviarDados() {
        if (this.valorInicial < 1 || this.meses < 1) {
            console.error('Os valores devem ser maiores ou iguais a 1.')
            return
        }

        const dados = {
            InitialValue: this.valorInicial,
            RescueTime: this.meses,
        }

        this.http.post<ResultadoDto>(this.apiUrl + "/cdb-investimento", dados).subscribe(
            (response) => {
                console.log('Resposta do servidor:', response);
                this.resultado = response
                console.log('Resultado a ser exibido:', this.resultado);
            },
            (error) => {
                console.error('Erro ao enviar os dados:', error);
            }
        )
    }
}
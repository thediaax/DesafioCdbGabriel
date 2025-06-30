import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
let AppComponent = class AppComponent {
    http;
    valorInicial = 0;
    meses = 0;
    apiUrl = 'http://localhost:5196';
    resultado = null;
    constructor(http) {
        this.http = http;
    }
    enviarDados() {
        if (this.valorInicial < 1 || this.meses < 1) {
            console.error('Os valores devem ser maiores ou iguais a 1.');
            return;
        }
        const dados = {
            InitialValue: this.valorInicial,
            Month: this.meses,
        };
        this.http.post(this.apiUrl + "/Avaliacao", dados).subscribe((response) => {
            console.log('Resposta do servidor:', response);
            this.resultado = response;
            console.log('Resultado a ser exibido:', this.resultado);
        }, (error) => {
            console.error('Erro ao enviar os dados:', error);
        });
    }
};
AppComponent = __decorate([
    Component({
        selector: 'app-root',
        templateUrl: './app.component.html',
        standalone: true,
        imports: [HttpClientModule, FormsModule, CommonModule]
    })
], AppComponent);
export { AppComponent };

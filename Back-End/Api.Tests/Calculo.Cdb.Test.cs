using Simulacao.Cdb.Calculo.Domain;
using Simulacao.Cdb.Calculo.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simulacao.Cdb.Calculo.Test
{
    [TestClass]
    public class CalculoCdbTests
    {
        private CalculoCdb _calculoCdb;



        [TestInitialize]
        public void Setup()
        {
            _calculoCdb = new CalculoCdb();
        }

        [TestMethod]
        public void RetornodeSaldosCompleto_ValorInicialNegativo_LancaArgumentException()
        {
            // Arrange
            var request = new CalculoRequest
            {
                InitialValue = -100,
                RescueTime = 12
            };

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _calculoCdb.RetornodeSaldosCompleto(request));
        }

        [TestMethod]
        public void RetornodeSaldosCompleto_PrazoMenorQueUmMes_LancaArgumentException()
        {
            // Arrange
            var request = new CalculoRequest
            {
                InitialValue = 1000,
                RescueTime = 0
            };

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _calculoCdb.RetornodeSaldosCompleto(request));
        }

        [TestMethod]
        public void RetornodeSaldosCompleto_ValorValido_CalculaCorretamente()
        {
            // Arrange
            var request = new CalculoRequest
            {
                InitialValue = 1000,
                RescueTime = 12
            };

            // Act
            
            CalculoResponse response = _calculoCdb.RetornodeSaldosCompleto(request);

            // Assert
            decimal rendimentoEsperado = request.InitialValue *
                                          (decimal)Math.Pow((double)(1 + 0.009m * 1.08m), request.RescueTime);

            Assert.AreEqual(Math.Round(rendimentoEsperado, 10), Math.Round(response?.InvestimentoBruto ?? 0, 10));
            Assert.AreEqual(Math.Round(rendimentoEsperado - response?.Imposto ?? 0, 10), Math.Round(response?.InvestimentoLiquido ?? 0, 10));
        }

        [TestMethod]
        public void PorcentagemIR_PrazosDiferentes_RetornaPorcentagemCorreta()
        {
            // Arrange & Act & Assert
            Assert.AreEqual(0.225m, CalculoCdb.PorcentagemIR(5));   // Menos que 7 meses
            Assert.AreEqual(0.20m, CalculoCdb.PorcentagemIR(10));    // Entre 7 e 12 meses
            Assert.AreEqual(0.175m, CalculoCdb.PorcentagemIR(20));   // Entre 13 e 24 meses
            Assert.AreEqual(0.15m, CalculoCdb.PorcentagemIR(30));    // 25 meses ou mais
        }
    }
}
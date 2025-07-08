using Simulacao.Investimento.Calculo.Domain.CBD;
using Simulacao.Investimento.Calculo.Services.CBD;
using System.Diagnostics.CodeAnalysis;

namespace Simulacao.Investimento.Calculo.Test.CDB
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CalculoCdbTests
    {
        private readonly CalculoCdb _calculoCdb;




        public CalculoCdbTests()
        {
            _calculoCdb = new CalculoCdb();
        }

        [TestMethod]
        public void RetornodeSaldosCompleto_ValorInicialNegativo_LancaArgumentException()
        {
            // Arrange
            var request = new CdbRequest
            {
                InitialValue = -100,
                RescueTime = 12
            };

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _calculoCdb.RetornoSaldoCompleto(request));
        }

        [TestMethod]
        public void RetornodeSaldosCompleto_PrazoMenorQueUmMes_LancaArgumentException()
        {
            // Arrange
            var request = new CdbRequest
            {
                InitialValue = 1000,
                RescueTime = 0
            };

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _calculoCdb.RetornoSaldoCompleto(request));
        }

        [TestMethod]
        public void RetornodeSaldosCompleto_ValorValido_CalculaCorretamente()
        {
            // Arrange
            var request = new CdbRequest
            {
                InitialValue = 1000,
                RescueTime = 12
            };

            // Act

            CdbResponse response = _calculoCdb.RetornoSaldoCompleto(request);

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
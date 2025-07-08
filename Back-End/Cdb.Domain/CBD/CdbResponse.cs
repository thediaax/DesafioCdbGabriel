namespace Simulacao.Investimento.Calculo.Domain.CBD
{
    public class CdbResponse
    {
        /// <summary>
        /// valor inicial do investimento
        /// </summary>
        public decimal InvestimentoInicial { get; set; }


        /// <summary>
        /// taxa do imposto
        /// </summary>
        public decimal Imposto { get; set; }


        /// <summary>
        /// Saldo liquido do investimento (desconto do imposto aplicado)
        /// </summary>
        public decimal InvestimentoLiquido { get; set; }


        /// <summary>
        /// saldo bruto do investimento (desconto do imposto não aplicado)
        /// </summary>
        public decimal InvestimentoBruto { get; set; }
    }
}

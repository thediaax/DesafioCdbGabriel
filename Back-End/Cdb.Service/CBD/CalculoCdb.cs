using Simulacao.Investimento.Calculo.Domain.CBD;

namespace Simulacao.Investimento.Calculo.Services.CBD
{
    public class CalculoCdb : ICalculoCdb
    {

        private const string erroValorInicial = "O valor de investimento precisa ser positivo.";
        private const string erroPrazo = "o prazo de investimento minimo é um mês";
        private static decimal TaxaBase { get; } = 1.08m;
        private static decimal Cdi { get; } = 0.009m;
        private static decimal CalculaInvestimentoTotal(CdbRequest req, CdbResponse res)
        {
            res.InvestimentoInicial = req.InitialValue;
            decimal rendimento = req.InitialValue;

            if (req.InitialValue <= 0)
            {
                throw new ArgumentException(erroValorInicial);
            }

            if (req.RescueTime < 1)
            {
                throw new ArgumentException(erroPrazo);
            }

            else
            {
                for (int i = 0; i < req.RescueTime; i++)
                {
                    rendimento *= 1 + Cdi * TaxaBase;
                }
            }
            res.InvestimentoBruto = rendimento;
            return res.InvestimentoBruto;
        }

        private static void CalcularImposto(CdbResponse res, CdbRequest req)
        {
            decimal lucro = res.InvestimentoBruto - res.InvestimentoInicial;
            decimal porcentagem = PorcentagemIR(req.RescueTime);
            res.Imposto = lucro * porcentagem;
        }

        public static decimal PorcentagemIR(int prazoResgate)
        {
            return prazoResgate switch
            {
                < 7 => 0.225m,
                >= 7 and < 13 => 0.2m,
                >= 13 and < 25 => 0.175m,
                _ => 0.15m,
            };
        }

        private static void CalculoValorLiquido(CdbResponse res)
        {
            res.InvestimentoLiquido = res.InvestimentoBruto - res.Imposto;
        }

        public CdbResponse RetornoSaldoCompleto(CdbRequest req)
        {
            CdbResponse res = new();
            res.InvestimentoBruto = CalculaInvestimentoTotal(req, res);
            CalcularImposto(res, req);
            CalculoValorLiquido(res);
            return res;
        }
    }
}
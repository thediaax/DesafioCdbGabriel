using Domain;

namespace Services
{
    public class CalculoCdb : ICalculoCdb
    {

        const string erroValorInicial = "O valor precisa ser positivo.";
        const string erroPrazo = "o prazo precisa ser superior a 1 mês";
        const decimal taxaBase = 1.08m;
        const decimal cdi = 0.009m;
        private static decimal CalculaInvestimentoTotal(CalculoRequest req, CalculoResponse res)
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
                    rendimento *= (1 + (cdi * taxaBase));
                }
            }
            res.InvestimentoBruto = rendimento;
            return res.InvestimentoBruto;
        }

        private static void CalcularImposto(CalculoResponse res, CalculoRequest req)
        {
            decimal lucro = res.InvestimentoBruto - res.InvestimentoInicial;
            decimal porcentagem = PorcentagemIR(req.RescueTime);
            res.Imposto = lucro * porcentagem;
        }

        public static decimal PorcentagemIR(int prazoResgate)
        {
            switch (prazoResgate)
            {
                case int n when n < 7:
                    return 0.225m;

                case int n when n < 13:
                    return 0.2m;

                case int n when n < 25:
                    return 0.175m;

                default:
                    return 0.15m;
            }
        }

        private static void CalculoValorLiquido(CalculoResponse res)
        {
            res.InvestimentoLiquido = res.InvestimentoBruto - res.Imposto;
        }

        public CalculoResponse RetornodeSaldosCompleto(CalculoRequest req)
        {
            CalculoResponse res = new CalculoResponse();
            res.InvestimentoBruto = CalculaInvestimentoTotal(req, res);
            CalcularImposto(res, req);
            CalculoValorLiquido(res);
            return res;
        }
    }
}
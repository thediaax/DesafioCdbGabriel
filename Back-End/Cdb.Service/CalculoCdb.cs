using Domain;

namespace Services
{
    public class CalculoCdb : ICalculoCdb
    {
        private decimal CalculaInvestimentoTotal(CalculoRequest req, CalculoResponse res)
        {
            const decimal tb = 1.08m;
            const decimal cdi = 0.009m;
            decimal rendimento = req.InitialValue;

            if (req.InitialValue <= 0)
            {
                return 0;
            }
            if (req.RescueTime >= 1)
            {
                for (int i = 0; i < req.RescueTime; i++)
                {
                    rendimento *= (1 + (cdi * tb));
                }
            }
            res.InvestimentoBruto = rendimento;
            return res.InvestimentoBruto;
        }

        private decimal CalculoIR(CalculoResponse res, CalculoRequest req)
        {
            res.InvestimentoInicial = req.InitialValue;
            decimal lucro = res.InvestimentoBruto - res.InvestimentoInicial;
            decimal porcentagem = PorcentagemIR(req.RescueTime);
            res.Imposto = lucro * porcentagem; 

            return res.Imposto;
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

        private decimal CalculoValorLiquido(CalculoResponse res)
        {
            res.InvestimentoLiquido = res.InvestimentoBruto - res.Imposto;
            return res.InvestimentoLiquido;
        }

        public CalculoResponse RetornodeSaldos(CalculoRequest req)
        {
            CalculoResponse res = new CalculoResponse();
            res.InvestimentoBruto = CalculaInvestimentoTotal(req, res);
            CalculoIR(res, req);
            CalculoValorLiquido(res);
            return res;
        }
    }
}
using Simulacao.Investimento.Calculo.Domain.CBD;

namespace Simulacao.Investimento.Calculo.Services.CBD
{
    public interface ICalculoCdb
    {
        CdbResponse RetornoSaldoCompleto(CdbRequest req);
    }
}

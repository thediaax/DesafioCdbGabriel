using Simulacao.Cdb.Calculo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacao.Cdb.Calculo.Services
{
    public interface ICalculoCdb
    {
        CalculoResponse RetornodeSaldosCompleto(CalculoRequest req);
    }
}

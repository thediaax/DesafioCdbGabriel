using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacao.Cdb.Calculo.Domain
{
    public class CalculoResponse
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
        public decimal  InvestimentoLiquido { get; set; }


        /// <summary>
        /// saldo bruto do investimento (desconto do imposto não aplicado)
        /// </summary>
        public decimal InvestimentoBruto { get; set; }
    }
}

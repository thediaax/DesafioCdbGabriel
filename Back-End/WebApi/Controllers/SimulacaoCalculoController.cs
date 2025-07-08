using Microsoft.AspNetCore.Mvc;
using Simulacao.Investimento.Calculo.Domain.CBD;
using Simulacao.Investimento.Calculo.Services.CBD;

namespace Simulacao.Investimento.Api.Controllers
{
    [ApiController]
    [Route("simulacao/investimento")]
    public class CalculoController : ControllerBase
    {
        private readonly ICalculoCdb _calculoCdb;

        public CalculoController(ICalculoCdb calculoCdb)
        {
            _calculoCdb = calculoCdb;
        }

        [HttpPost("cdb")]
        public ActionResult<CdbResponse> CalcularInvestimento([FromBody] CdbRequest request)
        {
            try
            {
                var response = _calculoCdb.RetornoSaldoCompleto(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao calcular investimento: {ex.Message}");
            }
        }
    }
}

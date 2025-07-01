using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculoController : ControllerBase
    {
        private readonly ICalculoCdb _calculoCdb;

        public CalculoController(ICalculoCdb calculoCdb)
        {
            _calculoCdb = calculoCdb;
        }

        [HttpPost("cdb-investimento")]
        public ActionResult<CalculoResponse> CalcularInvestimento([FromBody] CalculoRequest request)
        {
            try
            {
                var response = _calculoCdb.RetornodeSaldosCompleto(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao calcular investimento: {ex.Message}");
            }
        }
    }
}

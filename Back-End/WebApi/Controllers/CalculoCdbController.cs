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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (request.InitialValue <= 0 || request.RescueTime < 1)
            {
                return BadRequest("Valores inválidos.");
            }

            try
            {
                var response = _calculoCdb.RetornodeSaldos(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao calcular investimento: {ex.Message}");
            }
        }
    }
}

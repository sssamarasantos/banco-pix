using Microsoft.AspNetCore.Mvc;
using TesteBanco.API.Business.IRepositories;

namespace TesteBanco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtratoController : ControllerBase
    {
        private readonly IExtratoRepository _extratoRepository;

        public ExtratoController(IExtratoRepository extratoRepository)
        {
            _extratoRepository = extratoRepository;
        }

        [HttpGet("{idCliente}")]
        public IActionResult Get(int idCliente)
        {
            var resultLogin = _extratoRepository.Get(idCliente);

            return Ok(resultLogin);
        }
    }
}

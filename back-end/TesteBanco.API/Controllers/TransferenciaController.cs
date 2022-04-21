using Microsoft.AspNetCore.Mvc;
using TesteBanco.API.Business.IRepositories;
using TesteBanco.API.Domain.DTOs;
using TesteBanco.API.Domain.Models;

namespace TesteBanco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransferenciaRepository _transferenciaRepository;

        public TransferenciaController(ITransferenciaRepository transferenciaRepository)
        {
            _transferenciaRepository = transferenciaRepository;
        }

        [HttpPost]
        public IActionResult Post(DadosTransferenciaDTO dadosTransferencia)
        {
            _transferenciaRepository.TransactionPix(dadosTransferencia);

            return Ok(dadosTransferencia);
        }
    }
}

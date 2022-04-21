using Microsoft.AspNetCore.Mvc;
using System;
using TesteBanco.API.Business.IRepositories;
using TesteBanco.API.Domain.DTOs;

namespace TesteBanco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            var listClients = _clienteRepository.List();
            return Ok(listClients);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var listClients = _clienteRepository.Get(id);
            return Ok(listClients);
        }

        [HttpPost]
        public IActionResult Post(ClienteDTO cliente)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("ModelState deve ser inválido", nameof(cliente));
            }

            _clienteRepository.Create(cliente);
            _clienteRepository.Save();

            return Created("", cliente);
        }
    }
}

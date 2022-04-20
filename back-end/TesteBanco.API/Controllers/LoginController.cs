using Microsoft.AspNetCore.Mvc;
using System;
using TesteBanco.API.Business.IRepositories;
using TesteBanco.API.Domain.Models;

namespace TesteBanco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpPost]
        public IActionResult Post(LoginDTO login)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("ModelState deve ser inválido", nameof(login));
            }

            var resultLogin = _loginRepository.Login(login);

            return Ok(resultLogin);
        }
    }
}

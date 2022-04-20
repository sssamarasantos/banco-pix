using System.Collections.Generic;
using TesteBanco.API.Domain.Models;

namespace TesteBanco.API.Business.IRepositories
{
    public interface ILoginRepository
    {
        LoginVO Login(LoginDTO login);
    }
}

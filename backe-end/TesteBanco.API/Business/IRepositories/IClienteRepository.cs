using System.Collections.Generic;
using TesteBanco.API.Domain.Models;

namespace TesteBanco.API.Business.IRepositories
{
    public interface IClienteRepository
    {
        Cliente Create(Cliente cliente);
        IList<Cliente> List();
        void Save();
    }
}

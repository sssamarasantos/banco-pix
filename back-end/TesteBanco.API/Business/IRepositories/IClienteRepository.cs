using System.Collections.Generic;
using TesteBanco.API.Domain.DTOs;
using TesteBanco.API.Domain.Models;

namespace TesteBanco.API.Business.IRepositories
{
    public interface IClienteRepository
    {
        Cliente Create(ClienteDTO cliente);
        IList<Cliente> List();
        Cliente Get(int id);
        void Save();
    }
}

using System.Collections.Generic;
using TesteBanco.API.Domain.Models;

namespace TesteBanco.API.Business.IRepositories
{
    public interface IExtratoRepository
    {
        IEnumerable<ExtratoVO> Get(int idCliente);
    }
}

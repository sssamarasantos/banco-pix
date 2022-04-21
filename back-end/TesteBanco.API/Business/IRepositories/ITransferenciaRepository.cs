using TesteBanco.API.Domain.DTOs;

namespace TesteBanco.API.Business.IRepositories
{
    public interface ITransferenciaRepository
    {
        void TransactionPix(DadosTransferenciaDTO transactionData);
    }
}

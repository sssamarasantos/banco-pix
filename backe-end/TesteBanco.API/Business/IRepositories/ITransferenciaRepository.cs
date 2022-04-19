using TesteBanco.API.Domain.Models;

namespace TesteBanco.API.Business.IRepositories
{
    public interface ITransferenciaRepository
    {
        void TransactionPix(DadosTransferencia transactionData);
    }
}

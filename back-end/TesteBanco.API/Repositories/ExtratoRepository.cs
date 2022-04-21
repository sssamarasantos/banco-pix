using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TesteBanco.API.Business.IRepositories;
using TesteBanco.API.Domain.Models;

namespace TesteBanco.API.Repositories
{
    public class ExtratoRepository : BaseRepository, IExtratoRepository
    {
        private static List<Cliente> clients;
        private static List<DadosTransferencia> transactionDatas;

        public ExtratoRepository()
        {
            clients = null;
            transactionDatas = null;

            if (clients is null)
                clients = GenerateClients();
            if (transactionDatas is null)
                transactionDatas = GenerateDataTransfer();
        }

        public IEnumerable<ExtratoVO> Get(int idCliente)
        {
            var transactionsReceived = SearchTransactionDataReceived(idCliente);
            var transactionSent = SearchTransactionDataSent(idCliente);

            var listExtrato = new List<ExtratoVO>();

            foreach(var item in transactionsReceived)
            {
                listExtrato.Add(new ExtratoVO
                {
                    NameClientOrigin = SearchName(item.IdClientOrigin),
                    Value = item.Value,
                    Date = item.Date.ToString("dd/MM/yyyy hh:mm")
                });
            }

            foreach(var item in transactionSent)
            {
                listExtrato.Add(new ExtratoVO
                {
                    NameClientOrigin = SearchName(item.IdClientOrigin),
                    Value = item.Value,
                    Date = item.Date.ToString("dd/MM/yyyy hh:mm")
                });
            }

            return listExtrato;
        }

        private IEnumerable<DadosTransferencia> SearchTransactionDataReceived(int idCliente)
        {
            var dadosRecebido = transactionDatas.Where(x => x.IdClientDestiny == idCliente).ToList();
            return dadosRecebido;
        }

        private IEnumerable<DadosTransferencia> SearchTransactionDataSent(int idCliente)
        {
            var dadosEnviado = transactionDatas.Where(x => x.IdClientOrigin == idCliente).ToList();
            return dadosEnviado;
        }

        private string SearchName(int id)
        {
            var name = clients.Find(x => x.Id == id).Name;
            return name;
        }
    }
}

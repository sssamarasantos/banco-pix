using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TesteBanco.API.Business.IRepositories;
using TesteBanco.API.Domain.Models;

namespace TesteBanco.API.Repositories
{
    public class TransferenciaRepository : BaseRepository, ITransferenciaRepository
    {
        private static List<Cliente> clients;
        private static List<DadosTransferencia> transactionDatas;

        public TransferenciaRepository()
        {
            if (clients is null)
                clients = GenerateClients();
            if (transactionDatas is null)
                transactionDatas = GenerateDataTransfer();
        }

        public void TransactionPix(DadosTransferencia transactionData)
        {
            ValidatePixKey(transactionData.IdClientOrigin, transactionData.PixKeyOrigin);
            ValidatePixKey(transactionData.IdClientDestiny, transactionData.PixKeyDestiny);

            var clientOrigin = SearchCustomerByPixKey(transactionData.PixKeyOrigin);
            var clientDestiny = SearchCustomerByPixKey(transactionData.PixKeyDestiny);

            ValidateHasValue(clientOrigin.Value, transactionData.Value);

            Discount(clientOrigin, transactionData.Value);
            Add(clientDestiny, transactionData.Value);

            SaveClient();
            TransactionCreate(transactionData);
            TransactionSave();
        }

        private Cliente Add(Cliente client, double value)
        {
            client.Value += value;

            return client;
        }

        private Cliente Discount(Cliente client, double value)
        {
            client.Value -= value;

            return client;
        }

        private DadosTransferencia TransactionCreate(DadosTransferencia transactionData)
        {
            transactionDatas.Add(transactionData);

            return transactionData;
        }

        private void TransactionSave()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(transactionDatas, options);

            File.WriteAllText("transferencias.json", jsonString);
        }

        private void SaveClient()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(clients, options);

            File.WriteAllText("cliente.json", jsonString);
        }

        private Cliente SearchCustomerByPixKey(string pixKey)
        {
            var client = clients.Find(x => x.PixKey == pixKey);
            return client;
        }

        private void ValidatePixKey(int idClient, string pixKey)
        {
            var existPixKey = clients.Where(x => x.Id == idClient && x.PixKey == pixKey).ToList();

            if (existPixKey.Count == 0)
                throw new ArgumentException("Chave inválida", nameof(existPixKey));
        }

        private void ValidateHasValue(double accountValue, double value)
        {
            if(accountValue <= 0.00)
                throw new Exception("Não há saldo");

            if (accountValue < value)
                throw new Exception("Não há saldo");
        }
    }
}

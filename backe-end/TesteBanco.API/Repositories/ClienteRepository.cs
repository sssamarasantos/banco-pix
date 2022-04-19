using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TesteBanco.API.Business.IRepositories;
using TesteBanco.API.Domain.Models;

namespace TesteBanco.API.Repositories
{
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        private static List<Cliente> clients;

        public ClienteRepository()
        {
            if (clients is null)
                clients = GenerateClients();
        }

        public Cliente Create(Cliente client)
        {
            ValidateCliente(client);
            ValidateId(client.Id);

            clients.Add(client);

            return client;
        }

        public IList<Cliente> List()
        {
            return clients;
        }

        public void Save()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(clients, options);

            File.WriteAllText("cliente.json", jsonString);
        }

        private void ValidateId(int id)
        {
            var existId = clients.Find(x => x.Id == id);
            if (existId != null)
                throw new Exception("Id já cadastrado");
        }

        private void ValidateCliente(Cliente client)
        {
            var existClient = clients.FirstOrDefault(x => x.CPF == client.CPF);
            if (existClient != null)
                throw new Exception("Cliente já cadastrado");
        }
    }
}

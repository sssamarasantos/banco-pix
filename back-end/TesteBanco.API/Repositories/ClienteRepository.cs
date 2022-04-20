using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TesteBanco.API.Business.IRepositories;
using TesteBanco.API.Domain.DTOs;
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

        public Cliente Create(ClienteDTO clientDTO)
        {
            var client = new Cliente
            {
                Name = clientDTO.Name,
                Cpf = clientDTO.Cpf,
                Password = clientDTO.Password,
                PixKey = clientDTO.PixKey,
                Value = clientDTO.Value
            };

            ValidateCliente(client.Cpf);

            client.Id = GenerateId();

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

        private int GenerateId()
        {
            return clients.Count + 1;
        }

        private void ValidateCliente(string cpf)
        {
            var existClient = clients.FirstOrDefault(x => x.Cpf == cpf);
            if (existClient != null)
                throw new Exception("Cliente já cadastrado");
        }
    }
}

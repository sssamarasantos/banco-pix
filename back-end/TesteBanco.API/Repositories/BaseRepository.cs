using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TesteBanco.API.Domain.Models;

namespace TesteBanco.API.Repositories
{
    public class BaseRepository
    {
        private static List<Cliente> clients;
        private static List<DadosTransferencia> dadosTransferencias;

        public List<Cliente> GenerateClients()
        {
            var file = "cliente.json";
            string jsonString = File.ReadAllText(file);

            clients = JsonSerializer.Deserialize<List<Cliente>>(jsonString);

            return clients;
        }

        public List<DadosTransferencia> GenerateDataTransfer()
        {
            var file = "transferencias.json";
            string jsonString = File.ReadAllText(file);

            dadosTransferencias = JsonSerializer.Deserialize<List<DadosTransferencia>>(jsonString);

            return dadosTransferencias;
        }

        public void SaveClient(List<Cliente> clientes)
        {
            var listClients = clientes;

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(listClients, options);

            File.WriteAllText("cliente.json", jsonString);
        }
    }
}

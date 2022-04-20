using System.ComponentModel.DataAnnotations;
using TesteBanco.API.Domain.DTOs;

namespace TesteBanco.API.Domain.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string PixKey { get; set; }
        public string Password { get; set; }
        public double Value { get; set; } = 0;
    }
}

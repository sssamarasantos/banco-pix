using System.ComponentModel.DataAnnotations;

namespace TesteBanco.API.Domain.DTOs
{
    public class ClienteDTO
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string PixKey { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Password { get; set; }
        public double Value { get; set; } = 0;
    }
}

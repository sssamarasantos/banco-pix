using System.ComponentModel.DataAnnotations;

namespace TesteBanco.API.Domain.Models
{
    public class Cliente
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string PixKey { get; set; }
        public double Value { get; set; } = 0;
    }
}

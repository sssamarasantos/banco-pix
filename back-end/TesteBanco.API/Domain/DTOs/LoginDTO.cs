using System.ComponentModel.DataAnnotations;

namespace TesteBanco.API.Domain.Models
{
    public class LoginDTO
    {
        
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cpf { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Password { get; set; }
    }
}

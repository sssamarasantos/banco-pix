using System.ComponentModel.DataAnnotations;

namespace TesteBanco.API.Domain.Models
{
    public class LoginVO
    {
        public string Token { get; set; }
        public Cliente User { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TesteBanco.API.Domain.DTOs
{
    public class DadosTransferenciaDTO
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public int IdClientOrigin { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int IdClientDestiny { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string PixKeyDestiny { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public double Value { get; set; }
    }
}

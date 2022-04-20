using System.ComponentModel.DataAnnotations;

namespace TesteBanco.API.Domain.Models
{
    public class DadosTransferencia
    {
        [Required(ErrorMessage ="Campo obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int IdClientOrigin { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string PixKeyOrigin { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int IdClientDestiny { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string PixKeyDestiny { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public double Value { get; set; }
    }
}

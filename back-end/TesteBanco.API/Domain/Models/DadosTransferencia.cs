using System;

namespace TesteBanco.API.Domain.Models
{
    public class DadosTransferencia
    {
        public int Id { get; set; }
        public int IdClientOrigin { get; set; }
        public int IdClientDestiny { get; set; }
        public string PixKeyDestiny { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}

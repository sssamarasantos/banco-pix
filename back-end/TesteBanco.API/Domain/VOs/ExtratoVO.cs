using System;
using System.ComponentModel.DataAnnotations;

namespace TesteBanco.API.Domain.Models
{
    public class ExtratoVO
    {
        public double Value { get; set; }
        public string NameClientOrigin { get; set; }
        public string Date { get; set; }
    }
}

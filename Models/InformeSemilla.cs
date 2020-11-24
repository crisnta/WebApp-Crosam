using System;
using System.Collections.Generic;
namespace crosam.Models{
    public class InformeSemilla{
        public int InformeSemillaId { get; set; }
        public int SupplierId { get; set; }
        public int NroGuia { get; set; }
        public decimal GastoSemilla { get; set; }
        public decimal GastoFlete { get; set; }
    }
}
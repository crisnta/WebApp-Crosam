using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace crosam.Models{
    
    public class Siembras{

        [Key]
        public int SiembraId { get; set; }

        public int ServicioFleteId { get; set; }

        [Display(Name = "Proveedor")]
        public int SupplierId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int NroGuia { get; set; }

        
        public int Recepcion { get; set; }

        [Display(Name = "Valor por Unidad (Kilo o Colector)")]
        public decimal ValorUnidad { get; set; }

        [Display(Name = "Gasto en Semilla")]
        public decimal GastoSemilla { get; set; }

        [Display(Name = "Gasto en Flete")]
       public decimal GastoFlete { get; set; }

       public virtual Supplier Supplier { get; set; }
       
       public virtual ServicioFlete ServicioFlete { get; set; }

       
    }

}
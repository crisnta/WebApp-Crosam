using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace crosam.Models{
    public class Sow{
        public int SowId { get; set; }
        [Display(Name = "Tipo de Cuelga")]
        public int CuelgaTypeId { get; set; }
        [Display(Name = "Proveedor")]
        public int SupplierId { get; set; }
        [Display(Name = "Sembrada Por")]
        public int SeederId { get; set; }
        [Display(Name = "Tipo de Substrato")]
        public int SubstratumId { get; set; }
        [Display(Name = "Largo de Cuelga")]
        public int CuelgaId { get; set; }
        [Display(Name = "Tamaño de Semilla")]
        public int SeedId { get; set; }
         [Display(Name = "Tipo de Boya")]
        public int BouyTypeId { get; set; }
        [Required]
        public int Linea { get; set; }
        [Required]
        [Display(Name = "Cuelgas")]
        public int CantidadColgado { get; set; }

         [DataType(DataType.Date)]
         public DateTime Fecha { get; set; }
         
         //Nav.
         public virtual CuelgaType CuelgaType { get; set; }
         public virtual Supplier Supplier { get; set; }
         public virtual Seeder Seeder { get; set; }
         public virtual Substratum Substratum { get; set; }
         public virtual Cuelga Cuelga { get; set; }
         public virtual Seed Seed { get; set; }
         public virtual BouyType BouyType { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace crosam.Models{
    public class Sow{
        public int SowId { get; set; }
        public int CuelgaTypeId { get; set; }
        public int SupplierId { get; set; }
        public int SeederId { get; set; }
        public int SubstratumId { get; set; }
        public int CuelgaId { get; set; }
        public int SeedId { get; set; }
        public int BouyTypeId { get; set; }
        public int Linea { get; set; }
        public int CantidadColgado { get; set; }

         [DataType(DataType.Date)]
         public DateTime Fecha { get; set; }
         
         public virtual CuelgaType CuelgaType { get; set; }
         public virtual Supplier Supplier { get; set; }
         public virtual Seeder Seeder { get; set; }
         public virtual Substratum Substratum { get; set; }
         public virtual Cuelga Cuelga { get; set; }
         public virtual Seed Seed { get; set; }
         public virtual BouyType BouyType { get; set; }

    }
}
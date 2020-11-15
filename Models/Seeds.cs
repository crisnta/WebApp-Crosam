using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace crosam.Models{
    
    public class Seed{
        public int SeedId { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal SeedSize { get; set; }
        public virtual ICollection<Sow> Sows { get; set; }
    }
}

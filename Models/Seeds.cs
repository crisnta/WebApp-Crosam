using System;
using System.Collections.Generic;

namespace crosam.Models{
    
    public class Seed{
        public int SeedId { get; set; }
        public decimal SeedSize { get; set; }
        public virtual ICollection<Sow> Sows { get; set; }
    }
}

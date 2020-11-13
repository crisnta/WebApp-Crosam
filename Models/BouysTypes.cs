using System;
using System.Collections.Generic;

namespace crosam.Models{
    public class BouyType{
        public int BouyTypeId { get; set; }
        public string BouyTypeName { get; set; }
        public virtual ICollection<Sow> Sows { get; set; }
    }
}
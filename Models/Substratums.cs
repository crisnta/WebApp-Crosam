using System;
using System.Collections.Generic;

namespace crosam.Models{

    public class Substratum{

        public int SubstratumId { get; set; }

        public string SubstratumName { get; set; }
        public virtual ICollection<Sow> Sows { get; set; }
    }

}
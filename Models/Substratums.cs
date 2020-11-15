using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace crosam.Models{

    public class Substratum{

        public int SubstratumId { get; set; }
        [Display(Name = "Sustrato")]

        public string SubstratumName { get; set; }
        public virtual ICollection<Sow> Sows { get; set; }
    }

}
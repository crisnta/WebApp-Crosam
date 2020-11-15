using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace crosam.Models{
    public class BouyType{
        public int BouyTypeId { get; set; }
        [Display(Name = "Boya")]
        public string BouyTypeName { get; set; }
        public virtual ICollection<Sow> Sows { get; set; }
    }
}
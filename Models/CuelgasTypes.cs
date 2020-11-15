using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace crosam.Models{
    public class CuelgaType{
        public int CuelgaTypeId { get; set; }
        [Display(Name = "Tipo de Cuelga")]
        public string CuelgaTypeName { get; set; }
        
        public ICollection<Sow> Sows { get; set; }
    }
}
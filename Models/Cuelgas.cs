using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace crosam.Models{
    public class Cuelga{
        public int CuelgaId { get; set; }
        public int CuelgaTypeId { get; set; }
        [Display(Name = "Largo Cuelga")]
        public int CuelgaLenght { get; set; }
        public virtual CuelgaType CuelgaType { get; set; }
        public virtual ICollection<Sow> Sows { get; set; }
    }
}
using System;
using System.Collections.Generic;
namespace crosam.Models{
    public class Cuelga{
        public int CuelgaId { get; set; }
        public int CuelgaTypeId { get; set; }
        public int CuelgaLenght { get; set; }
        public virtual CuelgaType CuelgaType { get; set; }
        public virtual ICollection<Sow> Sows { get; set; }
    }
}
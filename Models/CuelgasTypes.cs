using System;
using System.Collections.Generic;

namespace crosam.Models{
    public class CuelgaType{
        public int CuelgaTypeId { get; set; }
        public string CuelgaTypeName { get; set; }
        
        public ICollection<Sow> Sows { get; set; }
    }
}
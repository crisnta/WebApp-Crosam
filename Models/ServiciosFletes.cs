using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace crosam.Models
{   
    public class ServicioFlete{

        public int ServicioFleteId { get; set; }
        public string ServicioFleteName { get; set; }

        public virtual ICollection<Siembras> Siembras { get; set; }
    }
    
}
using System;
using System.Collections.Generic;
namespace crosam.Models{
    public class Destino{
        public int DestinoId { get; set; }
        public string Comercializadora { get; set; }

        public virtual ICollection<Harvest> Harvest { get; set; }
    }
}
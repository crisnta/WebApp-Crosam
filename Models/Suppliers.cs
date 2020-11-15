using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace crosam.Models{

    public class Supplier{
        public int SupplierId { get; set; }
        public int LocationId { get; set; }
        [Display(Name = "Proveedor")]
        public string SupplierName { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Sow> Sows { get; set; }

    }
    

}
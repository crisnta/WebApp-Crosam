using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace crosam.Models
{

    public class Location
    {
        public int LocationID { get; set; }
        [Display(Name = "Ubicación")]
        public string LocationName { get; set; }
        public ICollection<Seeder> seeders { get; set; }
        
        public virtual ICollection<Supplier> Suppliers { get; set;}
        
    }



}



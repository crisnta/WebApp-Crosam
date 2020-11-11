using System;
using System.Collections.Generic;

namespace crosam.Models
{

    public class Location
    {
        public int LocationID { get; set; }
        
        public string LocationName { get; set; }
        public ICollection<Seeder> seeders { get; set; }
        
        public virtual ICollection<Supplier> Suppliers { get; set;}
        
    }



}



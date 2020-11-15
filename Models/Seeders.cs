using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace crosam.Models
{
    public class Seeder
    {
        public int SeederID { get; set; }
        public int LocationID { get; set; }
        [Display(Name = "Sembrado Por")]
        public string SeederName { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Sow> Sows { get; set; }
    }

}

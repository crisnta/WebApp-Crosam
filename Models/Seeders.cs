using System;
using System.Collections.Generic;


namespace crosam.Models
{
    public class Seeder
    {
        public int SeederID { get; set; }
        public int LocationID { get; set; }
        public string SeederName { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Sow> Sows { get; set; }
    }

}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace crosam.Models
{
    public class User : IdentityUser
    {
        public char Sex { get; set; }
        public string City { get; set; }

    }
}
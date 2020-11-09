using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using crosam.Models;

namespace crosam.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Configuración que se ejecuta primero
            base.OnModelCreating(builder);
            // EF toma la ultima configuración
            builder.Entity<User>(entityTypeBuilder =>
             {
                 entityTypeBuilder.ToTable("Users");

                 entityTypeBuilder.Property(u => u.UserName)
                 .HasMaxLength(50)
                 .HasDefaultValue(0);

                 entityTypeBuilder.Property(u => u.Sex)
                 .HasMaxLength(1);

             });
 
        }

    }
}

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

        public DbSet<Location> Locations;   

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

             builder.Entity<Location>(entityTypeBuilder =>
             {
                 entityTypeBuilder.ToTable("Location");

    
                 entityTypeBuilder.Property(l => l.LocationName)
                 .HasMaxLength(20);

             });
 
        }

        public DbSet<crosam.Models.Location> Location { get; set; }

    }
}

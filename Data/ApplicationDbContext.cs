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

             builder.Entity<Location>(entityTypeBuilder =>
             {
                 entityTypeBuilder.ToTable("Location");
                 entityTypeBuilder.Property(l => l.LocationName)
                 .HasMaxLength(20);

             });

             builder.Entity<Seeder>(entityTypeBuilder =>
             {
                 entityTypeBuilder.ToTable("Seeder");
                 entityTypeBuilder.Property(s => s.SeederName)
                 .HasMaxLength(20);

             });

             builder.Entity<Supplier>(entityTypeBuilder =>
             {
                 entityTypeBuilder.ToTable("Supplier");
                 entityTypeBuilder.Property(su => su.SupplierName)
                 .HasMaxLength(20);

             });
             builder.Entity<Seed>(entityTypeBuilder =>
             {
                 entityTypeBuilder.ToTable("Seed");
                 entityTypeBuilder.Property(se => se.SeedSize)
                 .HasColumnType("decimal(18,4)");
             });


                
        }

        public DbSet<crosam.Models.Location> Location { get; set; }

        public DbSet<crosam.Models.Seeder> Seeder { get; set; }

        public DbSet<crosam.Models.Supplier> Supplier { get; set; }

        public DbSet<crosam.Models.BouyType> BouyType { get; set; }

        public DbSet<crosam.Models.Cuelga> Cuelga { get; set; }

        public DbSet<crosam.Models.CuelgaType> CuelgaType { get; set; }

        public DbSet<crosam.Models.Seed> Seed { get; set; }

        public DbSet<crosam.Models.Sow> Sow { get; set; }

        public DbSet<crosam.Models.Substratum> Substratum { get; set; }

        public DbSet<crosam.Models.Siembras> Siembras { get; set; }
        public DbSet<crosam.Models.ServicioFlete> ServicioFlete { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using MyDbContext.Entities;
using MyDbContext.Mapping;
using System;

namespace MyDbContext
{
    public partial class DbContext  : Microsoft.EntityFrameworkCore.DbContext
    {
        private string connection = "Host=localhost;Port=5433;Database=Prototype_Events;Username=postgres;Password=simplepassword";

        public virtual DbSet<Events> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(this.connection,o => o.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder = new EventsMapping(modelBuilder).ModelConfiguration;
            OnModelCreatingPartial(modelBuilder);
            //Cast the column "Location" from geometry type to geography type to perform distance calculations
            //modelBuilder.Entity<Events>().Property(b => b.Location).HasColumnType("geography (point)");
        }

       
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

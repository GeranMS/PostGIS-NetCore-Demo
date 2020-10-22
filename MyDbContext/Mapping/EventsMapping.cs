using Microsoft.EntityFrameworkCore;
using MyDbContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDbContext.Mapping
{
    class EventsMapping : EntityModelConfiguration
    {
        public EventsMapping(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<Events>(t =>
            {
                t.ToTable("events");

                t.HasKey(e => e.EventId);

                t.Property(e => e.EventId).HasColumnName("id").ValueGeneratedOnAdd();
                t.Property(e => e.Eventname).HasColumnName("name").IsRequired().HasMaxLength(60);
                t.Property(e => e.Longitude).HasColumnName("longitude").IsRequired();
                t.Property(e => e.Latitude).HasColumnName("latitude").IsRequired();
                t.Property(e => e.Location).HasColumnName("coordinates").HasColumnType("geography (point)");
            });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MyDbContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDbContext.Mapping
{
    public class UserMapping : EntityModelConfiguration
    {
        public UserMapping(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<User>(t =>
            {
                t.ToTable("User", "dbo");

                t.HasKey(e => e.UserId);

                t.Property(e => e.UserId).ValueGeneratedOnAdd();
                t.Property(e => e.Username).HasColumnName("Username").IsRequired().HasMaxLength(60);
                t.Property(e => e.Created).HasColumnName("Created").IsRequired();
                t.Property(e => e.Avatar).HasColumnName("Avatar");
            });
        }
    }
}

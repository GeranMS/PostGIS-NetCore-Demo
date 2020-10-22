using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDbContext
{
    public class EntityModelConfiguration
    {
        public ModelBuilder ModelConfiguration;

        public EntityModelConfiguration(ModelBuilder modelBuilder)
        {
            this.ModelConfiguration = modelBuilder;
        }
    }
}

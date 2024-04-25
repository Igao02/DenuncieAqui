using DenuncieAqui.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Infrastructure.EntitiesConfiguration
{
    internal class ReportsConfiguration : IEntityTypeConfiguration<Reports>
    {
        public void Configure(EntityTypeBuilder<Reports> builder)
        {
            builder.HasKey(r => r.ReportsId);

            builder.Property(r => r.ReportsId)
                   .IsRequired();

            builder.Property(r => r.ReportsName)
                   .HasMaxLength(100) 
                   .IsRequired(); 

            builder.Property(r => r.TypeReport)
                   .HasMaxLength(50); 

            builder.Property(r => r.ReportsDescription)
                   .HasMaxLength(500); 

            builder.Property(r => r.ReportsDate)
                   .IsRequired(); 

 
        }
    }
}

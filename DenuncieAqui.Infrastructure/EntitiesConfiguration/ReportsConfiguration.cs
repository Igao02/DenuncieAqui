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
    public class ReportsConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(r => r.ReportId);

            builder.Property(r => r.ReportId)
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

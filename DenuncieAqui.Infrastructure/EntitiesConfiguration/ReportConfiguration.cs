﻿using DenuncieAqui.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DenuncieAqui.Infrastructure.EntitiesConfiguration
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder
                .HasKey(r => r.Id);

            builder
                .Property(r => r.Id)
                .IsRequired();

            builder
                .Property(r => r.ReportName)
                .HasMaxLength(100) 
                .IsRequired(); 

            builder
                .Property(r => r.TypeReport)
                .HasMaxLength(50); 

            builder
                .Property(r => r.ReportDescription)
                .HasMaxLength(500); 

            builder
                .Property(r => r.ReportsDate)
                .IsRequired();

            builder
                .HasMany(_ => _.Likes)
                .WithOne(_ => _.Report)
                .HasForeignKey(_ => _.ReportId);

            builder
                .HasMany(_ => _.Images)
                .WithOne(_ => _.Report)
                .HasForeignKey(_ => _.ReportId);

            builder
                .HasMany(_ => _.Comments)
                .WithOne(_ => _.Report)
                .HasForeignKey(_ => _.ReportId);
        }
    }
}

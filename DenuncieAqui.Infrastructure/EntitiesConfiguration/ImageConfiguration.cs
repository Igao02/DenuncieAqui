﻿using DenuncieAqui.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DenuncieAqui.Infrastructure.EntitiesConfiguration
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.ImageName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(i => i.ImageUrl)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}

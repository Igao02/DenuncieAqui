using DenuncieAqui.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Infrastructure.EntitiesConfiguration
{
    public class ImagesConfiguration : IEntityTypeConfiguration<Images>
    {
        public void Configure(EntityTypeBuilder<Images> builder)
        {
            builder.HasKey(i => i.ImagesId);

            builder.Property(i => i.ImageName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(i => i.ImageUrl)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(i => i.ImageContent)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}

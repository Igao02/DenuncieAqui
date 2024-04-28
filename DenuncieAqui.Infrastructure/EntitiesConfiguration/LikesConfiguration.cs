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
    public class LikesConfiguration : IEntityTypeConfiguration<Likes>
    {
        public void Configure(EntityTypeBuilder<Likes> builder)
        {
            builder.HasKey(l => l.LikeId);

            builder.Property(l => l.LikeDate)
                .IsRequired();

            builder.Property(l => l.LikeCount)
                .IsRequired();
        }
    }
}

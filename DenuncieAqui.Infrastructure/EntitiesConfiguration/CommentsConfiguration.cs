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
    public class CommentsConfiguration : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.HasKey(c => c.CommentId);

            builder.Property(c => c.CommentContent)
                .HasMaxLength(350)
                .IsRequired();

            builder.Property(c => c.CommentCount);

            builder.Property(c => c.CommentDate)
                .IsRequired();

            
        }
    }
}

using DenuncieAqui.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DenuncieAqui.Infrastructure.EntitiesConfiguration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CommentContent)
                .HasMaxLength(350)
                .IsRequired();

            builder.Property(c => c.CommentDate)
                .IsRequired();
        }
    }
}

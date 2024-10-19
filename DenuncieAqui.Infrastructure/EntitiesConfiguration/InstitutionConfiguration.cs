using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DenuncieAqui.Infrastructure.EntitiesConfiguration;

public class InstitutionConfiguration : IEntityTypeConfiguration<Institution>
{
    public void Configure(EntityTypeBuilder<Institution> builder)
    {
        builder
            .HasKey(i => i.Id);

        builder
            .Property(i => i.Id)
            .IsRequired();

        builder
            .Property(i => i.CorporateName)
            .HasMaxLength(150)
            .IsRequired();
        
        builder
            .Property(i => i.Document)
            .HasMaxLength(14)
            .IsRequired();

        builder
            .Property(i => i.Address)
            .HasMaxLength(150)
            .IsRequired();

        builder
            .Property(i => i.CreationDate)
            .IsRequired();
    }
}

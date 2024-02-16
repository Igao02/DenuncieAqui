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
    internal class BooksConfiguration : IEntityTypeConfiguration<LivroExemplo>
    {
        public void Configure(EntityTypeBuilder<LivroExemplo> builder)
        {
            builder.HasKey(t => t.LivroId);
            builder.Property(p => p.PublishCompany).HasMaxLength(150).IsRequired();
            builder.Property(l => l.LivroName).HasMaxLength(50).IsRequired();

        }
    }
}

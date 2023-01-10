using RXCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RXCrud.Data.Configuration
{
    public class EstadoConfig : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Uf).IsUnique();
            builder.Property(u => u.Descricao).IsRequired();
        }
    }
}
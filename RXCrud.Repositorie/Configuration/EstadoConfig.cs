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
            builder.Property(u => u.Uf).IsRequired();
            builder.Property(u => u.Descricao).IsRequired();
        }
    }
}
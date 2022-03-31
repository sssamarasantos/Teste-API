using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.API.Models;

namespace Teste.API.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TB_Cliente");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Nome).HasMaxLength(256);
            builder.Property(m => m.Telefone).HasMaxLength(20);
            builder.Property(m => m.Endereco).HasMaxLength(500);
        }
    }
}

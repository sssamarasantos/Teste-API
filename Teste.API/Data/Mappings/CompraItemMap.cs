using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.API.Models;

namespace Teste.API.Data.Mappings
{
    public class CompraItemMap : IEntityTypeConfiguration<CompraItem>
    {
        public void Configure(EntityTypeBuilder<CompraItem> builder)
        {
            builder.ToTable("TB_CompraItem");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Quantidade).HasMaxLength(5);
            builder.HasOne(m => m.Produto).WithMany().HasForeignKey(m => m.IdProduto);
            builder.HasOne(m => m.Compra).WithMany().HasForeignKey(m => m.IdCompra);
        }
    }
}

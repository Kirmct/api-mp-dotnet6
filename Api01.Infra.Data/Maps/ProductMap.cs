using Api01.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api01.Infra.Data.Maps;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("PRODUTO");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("IDPESSOA").UseIdentityColumn(); ;
        builder.Property(x => x.CodeErp).HasColumnName("CODEERP");
        builder.Property(x => x.Name).HasColumnName("NOME");
        builder.Property(x => x.Price).HasColumnName("PRECO");

        //relacionamentos
        builder.HasMany(x => x.Purchases).WithOne(p => p.Product).HasForeignKey(x => x.ProductId);
    }
}

using Api01.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api01.Infra.Data.Maps;

public class PurchaseMap : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable("COMPRA");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("IDCOMPRA").UseIdentityColumn();
        builder.Property(x => x.PersonId).HasColumnName("IDPRODUTO");
        builder.Property(x => x.ProductId).HasColumnName("IDCOMPRA");
        builder.Property(x => x.Date).HasColumnName("DATACOMPRA");

        //relacionamentos
        builder.HasOne(x => x.Person).WithMany(x => x.Purchases);
        builder.HasOne(x => x.Product).WithMany(x => x.Purchases);

    }
}

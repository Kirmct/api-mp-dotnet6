﻿using Api01.Domain.Entities;
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
        builder.ToTable("produto");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("idproduto").UseIdentityColumn(); ;
        builder.Property(x => x.CodeErp).HasColumnName("codeerp");
        builder.Property(x => x.Name).HasColumnName("nome");
        builder.Property(x => x.Price).HasColumnName("preco");

        //relacionamentos
        builder.HasMany(x => x.Purchases).WithOne(p => p.Product).HasForeignKey(x => x.ProductId);
    }
}

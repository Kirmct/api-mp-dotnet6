using Api01.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api01.Infra.Data.Maps;

public class PersonMap : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("pessoa");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("idpessoa").UseIdentityColumn(); //chave unica que se incrementa

        builder.Property(x => x.Document).HasColumnName("documento");

        builder.Property(x => x.Name).HasColumnName("nome");

        builder.Property(x => x.Phone).HasColumnName("celular");

        //relacionamentos
        builder.HasMany(x => x.Purchases).WithOne(p => p.Person).HasForeignKey(x => x.PersonId);

    }
}

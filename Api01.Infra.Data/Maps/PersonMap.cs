using Api01.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api01.Infra.Data.Maps;

public class PersonMap : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("PESSOA");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("IDPESSOA").UseIdentityColumn(); //chave unica que se incrementa

        builder.Property(x => x.Document).HasColumnName("DOCUMENTO");

        builder.Property(x => x.Name).HasColumnName("NOME");

        builder.Property(x => x.Phone).HasColumnName("CELULAR");

        //relacionamentos
        builder.HasMany(x => x.Purchases).WithOne(p => p.Person).HasForeignKey(x => x.PersonId);

    }
}

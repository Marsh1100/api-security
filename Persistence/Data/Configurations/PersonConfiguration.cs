using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("person");

            builder.HasIndex(e => e.IdCategoryPerson, "idCategoryPerson");

            builder.HasIndex(e => e.IdCity, "idCity");

            builder.HasIndex(e => e.IdTypePerson, "idTypePerson");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.DateRegister).HasColumnName("dateRegister");
            builder.Property(e => e.IdCategoryPerson).HasColumnName("idCategoryPerson");
            builder.Property(e => e.IdCity).HasColumnName("idCity");
            builder.Property(e => e.IdTypePerson).HasColumnName("idTypePerson");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");

            builder.HasOne(d => d.IdCategoryPersonNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdCategoryPerson)
                .HasConstraintName("person_ibfk_2");

            builder.HasOne(d => d.IdCityNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdCity)
                .HasConstraintName("person_ibfk_3");

            builder.HasOne(d => d.IdTypePersonNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdTypePerson)
                .HasConstraintName("person_ibfk_1");

    }
}

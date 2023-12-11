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
            builder.Property(e => e.PersonId).HasColumnName("personId");

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

            builder.HasData(
                new Person {Id = 1, PersonId = "123459", Name = "Carlos David", DateRegister = new DateOnly(2009, 1, 11), IdTypePerson = 1, IdCategoryPerson = 4, IdCity = 3 },
                new Person {Id = 2, PersonId = "123468", Name = "Karla Lopez", DateRegister = new DateOnly(2011, 1, 11), IdTypePerson = 2, IdCategoryPerson = null, IdCity = 1 },
                new Person {Id = 3, PersonId = "123477", Name = "Hector Hernandez", DateRegister = new DateOnly(2009, 1, 11), IdTypePerson = 1, IdCategoryPerson = 1, IdCity = 4 },
                new Person {Id = 4, PersonId = "123486", Name = "Juan Sanches", DateRegister = new DateOnly(2013, 1, 11), IdTypePerson = 2, IdCategoryPerson = null, IdCity = 1 },
                new Person {Id = 5, PersonId = "123494", Name = "Pablo Gaviria", DateRegister = new DateOnly(2009, 1, 11), IdTypePerson = 1, IdCategoryPerson = 4, IdCity = 1 },
                new Person {Id = 6, PersonId = "123505", Name = "Elon Musk", DateRegister = new DateOnly(2022, 1, 11), IdTypePerson = 2, IdCategoryPerson = null, IdCity = 3 },
                new Person {Id = 7, PersonId = "123553", Name = "Leidy gaga", DateRegister = new DateOnly(2009, 1, 11), IdTypePerson = 1, IdCategoryPerson = 4, IdCity = 3 },
                new Person {Id = 8, PersonId = "123741", Name = "Michael Jackson", DateRegister = new DateOnly(2009, 1, 11), IdTypePerson = 2, IdCategoryPerson = null, IdCity = 1 },
                new Person {Id = 9, PersonId = "123562", Name = "Fredy Mercury", DateRegister = new DateOnly(2009, 1, 11), IdTypePerson = 1, IdCategoryPerson = 1, IdCity = 4 },
                new Person {Id = 10, PersonId = "123635", Name = "Fredy Fasbear", DateRegister = new DateOnly(2021, 1, 11), IdTypePerson = 2, IdCategoryPerson = null, IdCity = 1 },
                new Person {Id = 11, PersonId = "132456", Name = "Finn el Humano", DateRegister = new DateOnly(2009, 1, 11), IdTypePerson = 1, IdCategoryPerson = 4, IdCity = 3 }
            );

    }
}

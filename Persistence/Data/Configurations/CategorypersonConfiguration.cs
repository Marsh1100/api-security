using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class CategorypersonConfiguration : IEntityTypeConfiguration<Categoryperson>
{
    public void Configure(EntityTypeBuilder<Categoryperson> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("categoryperson");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
        builder.HasData(
                new Categoryperson{Id = 1, Name = "Auxiliar"},
                new Categoryperson{Id = 2, Name = "Cajero"},
                new Categoryperson{Id = 3, Name = "Supervisor"},
                new Categoryperson{Id = 4, Name = "Vigilante"}
            );

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class TypecontactConfiguration : IEntityTypeConfiguration<Typecontact>
{
    public void Configure(EntityTypeBuilder<Typecontact> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("typecontact");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("description");
        builder.HasData(
                new Typecontact{Id = 1, Description = "Celular"},
                new Typecontact{Id = 2, Description = "Email"}
            );
    }
}

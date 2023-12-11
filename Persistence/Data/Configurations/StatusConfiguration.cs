using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("status");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("description");

        builder.HasData(
                new Status{Id = 1, Description = "Activo"},
                new Status{Id = 2, Description = "Finalizado"},
                new Status{Id = 3, Description = "Pendiente"}
            );

    }
}

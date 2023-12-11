using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("city");

            builder.HasIndex(e => e.IdRegion, "idRegion");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IdRegion).HasColumnName("idRegion");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");

            builder.HasOne(d => d.IdRegionNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.IdRegion)
                .HasConstraintName("city_ibfk_1");

    }
}

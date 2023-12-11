using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        
        builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("region");

            builder.HasIndex(e => e.IdCountry, "idCountry");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IdCountry).HasColumnName("idCountry");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");

            builder.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Regions)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("region_ibfk_1");
            builder.HasData(
                new Region{Id=1, Name  = "Santander", IdCountry=1}
            );
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class ShiftConfiguration : IEntityTypeConfiguration<Shift>
{
    public void Configure(EntityTypeBuilder<Shift> builder)
    {
         builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("shift");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.HourEnd)
                .HasColumnType("time")
                .HasColumnName("hourEnd");
            builder.Property(e => e.HourStart)
                .HasColumnType("time")
                .HasColumnName("hourStart");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class ProgrammingConfiguration : IEntityTypeConfiguration<Programming>
{
    public void Configure(EntityTypeBuilder<Programming> builder)
    {
        builder
                .HasNoKey()
                .ToTable("programming");

            builder.HasIndex(e => e.IdContract, "idContract");

            builder.HasIndex(e => e.IdEmployee, "idEmployee");

            builder.HasIndex(e => e.IdShift, "idShift");

            builder.Property(e => e.IdContract).HasColumnName("idContract");
            builder.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            builder.Property(e => e.IdShift).HasColumnName("idShift");

            builder.HasOne(d => d.IdContractNavigation).WithMany()
                .HasForeignKey(d => d.IdContract)
                .HasConstraintName("programming_ibfk_1");

            builder.HasOne(d => d.IdEmployeeNavigation).WithMany()
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("programming_ibfk_3");

            builder.HasOne(d => d.IdShiftNavigation).WithMany()
                .HasForeignKey(d => d.IdShift)
                .HasConstraintName("programming_ibfk_2");

            builder.HasData(
                new Programming{Id=1, IdContract  =1,  IdEmployee  =1, IdShift  =1}
            );

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class ContractConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("contract");

            builder.HasIndex(e => e.IdClient, "idClient");

            builder.HasIndex(e => e.IdEmployee, "idEmployee");

            builder.HasIndex(e => e.IdStatus, "idStatus");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.DateContract).HasColumnName("dateContract");
            builder.Property(e => e.DateEnd).HasColumnName("dateEnd");
            builder.Property(e => e.IdClient).HasColumnName("idClient");
            builder.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            builder.Property(e => e.IdStatus).HasColumnName("idStatus");

            builder.HasOne(d => d.IdClientNavigation).WithMany(p => p.ContractIdClientNavigations)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("contract_ibfk_1");

            builder.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.ContractIdEmployeeNavigations)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("contract_ibfk_2");

            builder.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("contract_ibfk_3");

    }
}

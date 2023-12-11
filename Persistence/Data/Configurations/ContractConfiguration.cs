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
            builder.HasData(
                new Contract{Id = 1, IdClient = 2, DateContract = new DateOnly(2009, 1, 11), IdEmployee = 1, DateEnd = new DateOnly(2023, 1, 11), IdStatus = 1},
                new Contract{Id = 2, IdClient = 4, DateContract = new DateOnly(2022, 2, 11), IdEmployee = 3, DateEnd = new DateOnly(2023, 2, 11), IdStatus = 1},
                new Contract{Id = 3, IdClient = 6, DateContract = new DateOnly(2022, 3, 11), IdEmployee = 5, DateEnd = new DateOnly(2023, 3, 11), IdStatus = 2},
                new Contract{Id = 4, IdClient = 8, DateContract = new DateOnly(2022, 4, 11), IdEmployee = 7, DateEnd = new DateOnly(2023, 4, 11), IdStatus = 1},
                new Contract{Id = 5, IdClient = 10, DateContract = new DateOnly(2022, 5, 11), IdEmployee = 9, DateEnd = new DateOnly(2023, 5, 11), IdStatus = 3},
                new Contract{Id = 6, IdClient = 2, DateContract = new DateOnly(2022, 6, 11), IdEmployee = 11, DateEnd = new DateOnly(2023, 6, 11), IdStatus = 1}
            );

    }
}

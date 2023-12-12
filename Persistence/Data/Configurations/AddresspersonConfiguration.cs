using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class AddresspersonConfiguration : IEntityTypeConfiguration<Addressperson>
{
    public void Configure(EntityTypeBuilder<Addressperson> builder)
    {
         builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("addressperson");

            builder.HasIndex(e => e.IdPerson, "idPerson");

            builder.HasIndex(e => e.IdTypeAddress, "idTypeAddress");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("address");
            builder.Property(e => e.IdPerson).HasColumnName("idPerson");
            builder.Property(e => e.IdTypeAddress).HasColumnName("idTypeAddress");

            builder.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Addresspeople)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("addressperson_ibfk_1");

            builder.HasOne(d => d.IdTypeAddressNavigation).WithMany(p => p.Addresspeople)
                .HasForeignKey(d => d.IdTypeAddress)
                .HasConstraintName("addressperson_ibfk_2");

           
    }
}

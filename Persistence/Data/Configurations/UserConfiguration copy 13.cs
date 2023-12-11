using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class ContactpersonConfiguration : IEntityTypeConfiguration<Contactperson>
{
    public void Configure(EntityTypeBuilder<Contactperson> builder)
    {
        
        builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("contactperson");

            builder.HasIndex(e => e.IdPerson, "idPerson");

            builder.HasIndex(e => e.IdTypeContact, "idTypeContact");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("description");
            builder.Property(e => e.IdPerson).HasColumnName("idPerson");
            builder.Property(e => e.IdTypeContact).HasColumnName("idTypeContact");

            builder.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Contactpeople)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("contactperson_ibfk_1");

            builder.HasOne(d => d.IdTypeContactNavigation).WithMany(p => p.Contactpeople)
                .HasForeignKey(d => d.IdTypeContact)
                .HasConstraintName("contactperson_ibfk_2");
    }
}

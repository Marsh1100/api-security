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
            
            builder.HasData(
                new Contactperson{Id = 1, Description = "3132419732", IdTypeContact=1, IdPerson = 1},
                new Contactperson{Id = 2, Description = "3132419732", IdTypeContact=1, IdPerson = 2},
                new Contactperson{Id = 3, Description = "3132419732", IdTypeContact=1, IdPerson = 3},
                new Contactperson{Id = 4, Description = "3132419732", IdTypeContact=1, IdPerson = 4},
                new Contactperson{Id = 5, Description = "3132419732", IdTypeContact=1, IdPerson = 5},
                new Contactperson{Id = 6, Description = "julian@gmial", IdTypeContact=2, IdPerson = 6},
                new Contactperson{Id = 7, Description = "margi@gmial", IdTypeContact=2, IdPerson = 7},
                new Contactperson{Id = 8, Description = "nico@gmial", IdTypeContact=2, IdPerson = 8},
                new Contactperson{Id = 9, Description = "lalala@gmial", IdTypeContact=2, IdPerson = 9},
                new Contactperson{Id = 10, Description = "sopas@gmial", IdTypeContact=2, IdPerson = 10}
            );
    }
}

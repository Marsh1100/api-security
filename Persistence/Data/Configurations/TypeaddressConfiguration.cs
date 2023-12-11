using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class TypeaddressConfiguration : IEntityTypeConfiguration<Typeaddress>
{
    public void Configure(EntityTypeBuilder<Typeaddress> builder)
    {
        
        builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("typeaddress");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("description");
            
            builder.HasData(
                new Typeaddress{Id = 1, Description = "Conjunto"},
                new Typeaddress{Id = 2, Description = "Casa"},
                new Typeaddress{Id = 2, Description = "Torre"}

            );
    }
}

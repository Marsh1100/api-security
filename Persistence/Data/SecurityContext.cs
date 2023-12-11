using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Data;

public partial class SecurityContext : DbContext
{
    public SecurityContext()
    {
    }

    public SecurityContext(DbContextOptions<SecurityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Addressperson> Addresspeople { get; set; }

    public virtual DbSet<Categoryperson> Categorypeople { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Contactperson> Contactpeople { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Programming> Programmings { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Typeaddress> Typeaddresses { get; set; }

    public virtual DbSet<Typecontact> Typecontacts { get; set; }

    public virtual DbSet<Typeperson> Typepeople { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=campus2024;database=security", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Addressperson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("addressperson");

            entity.HasIndex(e => e.IdPerson, "idPerson");

            entity.HasIndex(e => e.IdTypeAddress, "idTypeAddress");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.IdTypeAddress).HasColumnName("idTypeAddress");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Addresspeople)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("addressperson_ibfk_1");

            entity.HasOne(d => d.IdTypeAddressNavigation).WithMany(p => p.Addresspeople)
                .HasForeignKey(d => d.IdTypeAddress)
                .HasConstraintName("addressperson_ibfk_2");
        });

        modelBuilder.Entity<Categoryperson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categoryperson");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("city");

            entity.HasIndex(e => e.IdRegion, "idRegion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdRegion).HasColumnName("idRegion");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdRegionNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.IdRegion)
                .HasConstraintName("city_ibfk_1");
        });

        modelBuilder.Entity<Contactperson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contactperson");

            entity.HasIndex(e => e.IdPerson, "idPerson");

            entity.HasIndex(e => e.IdTypeContact, "idTypeContact");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.IdTypeContact).HasColumnName("idTypeContact");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Contactpeople)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("contactperson_ibfk_1");

            entity.HasOne(d => d.IdTypeContactNavigation).WithMany(p => p.Contactpeople)
                .HasForeignKey(d => d.IdTypeContact)
                .HasConstraintName("contactperson_ibfk_2");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contract");

            entity.HasIndex(e => e.IdClient, "idClient");

            entity.HasIndex(e => e.IdEmployee, "idEmployee");

            entity.HasIndex(e => e.IdStatus, "idStatus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateContract).HasColumnName("dateContract");
            entity.Property(e => e.DateEnd).HasColumnName("dateEnd");
            entity.Property(e => e.IdClient).HasColumnName("idClient");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IdStatus).HasColumnName("idStatus");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.ContractIdClientNavigations)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("contract_ibfk_1");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.ContractIdEmployeeNavigations)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("contract_ibfk_2");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("contract_ibfk_3");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("country");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("person");

            entity.HasIndex(e => e.IdCategoryPerson, "idCategoryPerson");

            entity.HasIndex(e => e.IdCity, "idCity");

            entity.HasIndex(e => e.IdTypePerson, "idTypePerson");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateRegister).HasColumnName("dateRegister");
            entity.Property(e => e.IdCategoryPerson).HasColumnName("idCategoryPerson");
            entity.Property(e => e.IdCity).HasColumnName("idCity");
            entity.Property(e => e.IdTypePerson).HasColumnName("idTypePerson");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdCategoryPersonNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdCategoryPerson)
                .HasConstraintName("person_ibfk_2");

            entity.HasOne(d => d.IdCityNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdCity)
                .HasConstraintName("person_ibfk_3");

            entity.HasOne(d => d.IdTypePersonNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdTypePerson)
                .HasConstraintName("person_ibfk_1");
        });

        modelBuilder.Entity<Programming>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("programming");

            entity.HasIndex(e => e.IdContract, "idContract");

            entity.HasIndex(e => e.IdEmployee, "idEmployee");

            entity.HasIndex(e => e.IdShift, "idShift");

            entity.Property(e => e.IdContract).HasColumnName("idContract");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IdShift).HasColumnName("idShift");

            entity.HasOne(d => d.IdContractNavigation).WithMany()
                .HasForeignKey(d => d.IdContract)
                .HasConstraintName("programming_ibfk_1");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany()
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("programming_ibfk_3");

            entity.HasOne(d => d.IdShiftNavigation).WithMany()
                .HasForeignKey(d => d.IdShift)
                .HasConstraintName("programming_ibfk_2");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("region");

            entity.HasIndex(e => e.IdCountry, "idCountry");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCountry).HasColumnName("idCountry");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Regions)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("region_ibfk_1");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("shift");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HourEnd)
                .HasColumnType("time")
                .HasColumnName("hourEnd");
            entity.Property(e => e.HourStart)
                .HasColumnType("time")
                .HasColumnName("hourStart");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Typeaddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("typeaddress");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Typecontact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("typecontact");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Typeperson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("typeperson");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("description");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IdenNumber)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("idenNumber");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasMany(d => d.IdRols).WithMany(p => p.IdUsers)
                .UsingEntity<Dictionary<string, object>>(
                    "Userrol",
                    r => r.HasOne<Rol>().WithMany()
                        .HasForeignKey("IdRol")
                        .HasConstraintName("userrol_ibfk_1"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("IdUser")
                        .HasConstraintName("userrol_ibfk_2"),
                    j =>
                    {
                        j.HasKey("IdUser", "IdRol")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("userrol");
                        j.HasIndex(new[] { "IdRol" }, "idRol");
                        j.IndexerProperty<int>("IdUser").HasColumnName("idUser");
                        j.IndexerProperty<int>("IdRol").HasColumnName("idRol");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

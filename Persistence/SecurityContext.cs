using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class SecurityContext : DbContext 
{
    public SecurityContext(DbContextOptions<SecurityContext> options) : base(options)
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

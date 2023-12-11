using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Person :BaseEntity
{

    public string Name { get; set; }
    public string PersonId { get; set; }

    public DateOnly DateRegister { get; set; }

    public int IdTypePerson { get; set; }

    public int ? IdCategoryPerson { get; set; }

    public int IdCity { get; set; }

    public virtual ICollection<Addressperson> Addresspeople { get; set; } = new List<Addressperson>();

    public virtual ICollection<Contactperson> Contactpeople { get; set; } = new List<Contactperson>();

    public virtual ICollection<Contract> ContractIdClientNavigations { get; set; } = new List<Contract>();

    public virtual ICollection<Contract> ContractIdEmployeeNavigations { get; set; } = new List<Contract>();

    public virtual Categoryperson IdCategoryPersonNavigation { get; set; }

    public virtual City IdCityNavigation { get; set; }

    public virtual Typeperson IdTypePersonNavigation { get; set; }
}

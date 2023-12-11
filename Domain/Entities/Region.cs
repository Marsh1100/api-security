using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Region : BaseEntity
{
    public string Name { get; set; }

    public int IdCountry { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country IdCountryNavigation { get; set; }
}

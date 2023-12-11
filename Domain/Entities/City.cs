using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class City : BaseEntity
{
    public string Name { get; set; }

    public int IdRegion { get; set; }

    public virtual Region IdRegionNavigation { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}

using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int IdRegion { get; set; }

    public virtual Region IdRegionNavigation { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}

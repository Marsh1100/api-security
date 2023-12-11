using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Country : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();
}

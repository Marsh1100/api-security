using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Status
{
    public int Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}

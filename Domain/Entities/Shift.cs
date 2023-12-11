using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Shift : BaseEntity
{

    public string Name { get; set; }

    public TimeOnly HourStart { get; set; }

    public TimeOnly HourEnd { get; set; }
}

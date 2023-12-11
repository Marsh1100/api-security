using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Shift
{
    public int Id { get; set; }

    public string Name { get; set; }

    public TimeOnly HourStart { get; set; }

    public TimeOnly HourEnd { get; set; }
}

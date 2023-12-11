using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Shift : BaseEntity
{

    public string Name { get; set; }

    public int HourStart { get; set; }

    public int HourEnd { get; set; }
}

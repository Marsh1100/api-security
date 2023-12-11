using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Categoryperson : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}

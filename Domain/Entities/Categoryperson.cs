using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Categoryperson
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}

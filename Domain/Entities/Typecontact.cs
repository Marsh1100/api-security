using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Typecontact
{
    public int Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Contactperson> Contactpeople { get; set; } = new List<Contactperson>();
}

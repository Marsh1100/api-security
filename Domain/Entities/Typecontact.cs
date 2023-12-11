using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Typecontact : BaseEntity
{
    public string Description { get; set; }

    public virtual ICollection<Contactperson> Contactpeople { get; set; } = new List<Contactperson>();
}

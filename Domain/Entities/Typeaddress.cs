using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Typeaddress
{
    public int Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Addressperson> Addresspeople { get; set; } = new List<Addressperson>();
}

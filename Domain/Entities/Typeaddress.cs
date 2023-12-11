using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Typeaddress : BaseEntity
{

    public string Description { get; set; }

    public virtual ICollection<Addressperson> Addresspeople { get; set; } = new List<Addressperson>();
}

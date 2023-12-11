using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Addressperson
{
    public int Id { get; set; }

    public string Address { get; set; }

    public int IdPerson { get; set; }

    public int IdTypeAddress { get; set; }

    public virtual Person IdPersonNavigation { get; set; }

    public virtual Typeaddress IdTypeAddressNavigation { get; set; }
}

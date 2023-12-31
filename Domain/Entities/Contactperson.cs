﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Contactperson : BaseEntity
{

    public string Description { get; set; }

    public int IdPerson { get; set; }

    public int IdTypeContact { get; set; }

    public virtual Person IdPersonNavigation { get; set; }

    public virtual Typecontact IdTypeContactNavigation { get; set; }
}

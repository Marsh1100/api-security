using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Contract : BaseEntity
{
    public int IdClient { get; set; }

    public int IdEmployee { get; set; }

    public DateOnly DateContract { get; set; }

    public DateOnly DateEnd { get; set; }

    public int IdStatus { get; set; }

    public virtual Person IdClientNavigation { get; set; }

    public virtual Person IdEmployeeNavigation { get; set; }

    public virtual Status IdStatusNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Programming  : BaseEntity
{
    public int IdContract { get; set; }

    public int IdShift { get; set; }

    public int IdEmployee { get; set; }

    public virtual Contract IdContractNavigation { get; set; }

    public virtual Person IdEmployeeNavigation { get; set; }

    public virtual Shift IdShiftNavigation { get; set; }
}

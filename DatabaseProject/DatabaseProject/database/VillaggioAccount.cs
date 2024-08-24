using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class VillaggioAccount
{
    public Guid IdAccount { get; set; }

    public Guid IdVillaggio { get; set; }

    public virtual Account IdAccountNavigation { get; set; } = null!;

    public virtual Villaggio IdVillaggioNavigation { get; set; } = null!;
}

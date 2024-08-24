using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class VillaggiAccount
{
    public Guid IdAccount { get; set; }

    public Guid IdVillaggio { get; set; }

    public virtual Account IdAccountNavigation { get; set; } = null!;

    public virtual Villaggi IdVillaggioNavigation { get; set; } = null!;
}

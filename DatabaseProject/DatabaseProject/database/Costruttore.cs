using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Costruttore
{
    public Guid IdVillaggio { get; set; }

    public int IdCostruttore { get; set; }

    public virtual Villaggio IdVillaggioNavigation { get; set; } = null!;
}

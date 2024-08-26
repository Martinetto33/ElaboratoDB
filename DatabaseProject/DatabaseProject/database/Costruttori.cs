using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Costruttori
{
    public Guid IdVillaggio { get; set; }

    public int IdCostruttore { get; set; }

    public virtual Villaggi IdVillaggioNavigation { get; set; } = null!;
}

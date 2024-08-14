using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Costruttore
{
    public Guid IdVillaggio { get; set; }

    public int IdCostruttore { get; set; }

    public int? LivelloMiglioramento { get; set; }

    public string Occupato { get; set; } = null!;

    public virtual Villaggio IdVillaggioNavigation { get; set; } = null!;

    public virtual MiglioramentoEdificio? LivelloMiglioramentoNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class TipiTruppe
{
    public string Nome { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public virtual ICollection<StatisticheTruppeMigliorate> StatisticheTruppeMigliorates { get; set; } = new List<StatisticheTruppeMigliorate>();

    public virtual ICollection<TruppeInVillaggio> TruppeInVillaggios { get; set; } = new List<TruppeInVillaggio>();
}

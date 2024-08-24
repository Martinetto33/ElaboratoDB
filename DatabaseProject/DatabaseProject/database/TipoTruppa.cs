using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class TipoTruppa
{
    public string Nome { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public virtual ICollection<StatisticheTruppaMigliorata> StatisticheTruppeMigliorates { get; set; } = new List<StatisticheTruppaMigliorata>();

    public virtual ICollection<TruppaInVillaggio> TruppeInVillaggios { get; set; } = new List<TruppaInVillaggio>();
}

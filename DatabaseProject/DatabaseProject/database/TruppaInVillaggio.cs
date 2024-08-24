using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class TruppaInVillaggio
{
    public Guid IdVillaggio { get; set; }

    public int Livello { get; set; }

    public string Nome { get; set; } = null!;

    public virtual Villaggio IdVillaggioNavigation { get; set; } = null!;

    public virtual ICollection<MiglioramentiTruppa> MiglioramentiTruppas { get; set; } = new List<MiglioramentiTruppa>();

    public virtual TipoTruppa NomeNavigation { get; set; } = null!;
}

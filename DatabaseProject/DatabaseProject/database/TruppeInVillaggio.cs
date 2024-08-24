using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class TruppeInVillaggio
{
    public Guid IdVillaggio { get; set; }

    public int Livello { get; set; }

    public string Nome { get; set; } = null!;

    public virtual Villaggi IdVillaggioNavigation { get; set; } = null!;

    public virtual ICollection<MiglioramentiTruppa> MiglioramentiTruppas { get; set; } = new List<MiglioramentiTruppa>();

    public virtual TipiTruppe NomeNavigation { get; set; } = null!;
}

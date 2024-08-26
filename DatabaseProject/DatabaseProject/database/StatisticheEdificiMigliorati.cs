using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class StatisticheEdificiMigliorati
{
    public int PuntiVita { get; set; }

    public string Nome { get; set; } = null!;

    public int LivelloMiglioramento { get; set; }

    public virtual ICollection<EdificiInVillaggio> EdificiInVillaggios { get; set; } = new List<EdificiInVillaggio>();

    public virtual TipiEdificio NomeNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class StatisticheEdificioMigliorato
{
    public int PuntiVita { get; set; }

    public string Nome { get; set; } = null!;

    public int LivelloMiglioramento { get; set; }

    public virtual ICollection<EdificioInVillaggio> EdificiInVillaggios { get; set; } = new List<EdificioInVillaggio>();

    public virtual TipoEdificio NomeNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class TipoEdificio
{
    public string Nome { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public virtual ICollection<StatisticheEdificioMigliorato> StatisticheEdificiMiglioratis { get; set; } = new List<StatisticheEdificioMigliorato>();
}

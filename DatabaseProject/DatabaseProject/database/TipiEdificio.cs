using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class TipiEdificio
{
    public string Nome { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public virtual ICollection<StatisticheEdificiMigliorati> StatisticheEdificiMiglioratis { get; set; } = new List<StatisticheEdificiMigliorati>();
}

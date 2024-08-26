using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class StatisticheTruppeMigliorate
{
    public int LivelloMiglioramento { get; set; }

    public int DurataMs { get; set; }

    public int Costo { get; set; }

    public int PuntiEsperienzaConferiti { get; set; }

    public int PuntiVita { get; set; }

    public int DanniInflitti { get; set; }

    public string Nome { get; set; } = null!;

    public virtual TipiTruppe NomeNavigation { get; set; } = null!;
}

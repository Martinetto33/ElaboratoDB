using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class MiglioramentoTruppa
{
    public Guid Id { get; set; }

    public int Durata { get; set; }

    public int Costo { get; set; }

    public int LivelloMiglioramento { get; set; }

    public int PuntiEsperienzaConferiti { get; set; }

    public Guid IdVillaggio { get; set; }

    public int IdEdificio { get; set; }

    public virtual Edificio Edificio { get; set; } = null!;

    public virtual Truppa IdNavigation { get; set; } = null!;
}

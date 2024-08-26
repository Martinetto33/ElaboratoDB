using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class MiglioramentiEdificio
{
    public Guid IdVillaggio { get; set; }

    public int IdEdificio { get; set; }

    public int DurataMs { get; set; }

    public int Costo { get; set; }

    public int LivelloMiglioramento { get; set; }

    public int PuntiEsperienzaConferiti { get; set; }

    public int IdCostruttore { get; set; }

    public virtual EdificiInVillaggio EdificiInVillaggio { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Truppa
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;

    public int Livello { get; set; }

    public int PuntiVita { get; set; }

    public int DanniInflitti { get; set; }

    public string Descrizione { get; set; } = null!;

    public Guid IdVillaggio { get; set; }

    public virtual Villaggio IdVillaggioNavigation { get; set; } = null!;

    public virtual ICollection<MiglioramentoTruppa> MiglioramentoTruppas { get; set; } = new List<MiglioramentoTruppa>();
}

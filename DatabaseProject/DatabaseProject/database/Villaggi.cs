using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Villaggi
{
    public float Forza { get; set; }

    public int LivelloEsperienza { get; set; }

    public int NumeroTrofei { get; set; }

    public int NumeroStelleGuerra { get; set; }

    public Guid IdVillaggio { get; set; }

    public virtual ICollection<Costruttori> Costruttoris { get; set; } = new List<Costruttori>();

    public virtual ICollection<EdificiInVillaggio> EdificiInVillaggios { get; set; } = new List<EdificiInVillaggio>();

    public virtual ICollection<TruppeInVillaggio> TruppeInVillaggios { get; set; } = new List<TruppeInVillaggio>();

    public virtual VillaggiAccount? VillaggiAccount { get; set; }
}

﻿using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Villaggio
{
    public float Forza { get; set; }

    public int LivelloEsperienza { get; set; }

    public int NumeroTrofei { get; set; }

    public int NumeroStelleGuerra { get; set; }

    public Guid IdVillaggio { get; set; }

    public virtual ICollection<Costruttore> Costruttoris { get; set; } = new List<Costruttore>();

    public virtual ICollection<EdificioInVillaggio> EdificiInVillaggios { get; set; } = new List<EdificioInVillaggio>();

    public virtual ICollection<TruppaInVillaggio> TruppeInVillaggios { get; set; } = new List<TruppaInVillaggio>();

    public virtual VillaggioAccount? VillaggiAccount { get; set; }
}

using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Villaggio
{
    public float Forza { get; set; }

    public int LivelloEsperienza { get; set; }

    public int NumeroTrofei { get; set; }

    public int NumeroStelleGuerra { get; set; }

    public Guid IdVillaggio { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<Costruttore> Costruttores { get; set; } = new List<Costruttore>();

    public virtual ICollection<Edificio> Edificios { get; set; } = new List<Edificio>();

    public virtual ICollection<Truppa> Truppas { get; set; } = new List<Truppa>();
}

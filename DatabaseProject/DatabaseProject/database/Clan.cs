﻿using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Clan
{
    public string Nome { get; set; } = null!;

    public int NumeroMembri { get; set; }

    public int TrofeiTotali { get; set; }

    public int StelleGuerraTotali { get; set; }

    public Guid IdClan { get; set; }

    public virtual ICollection<Combattimento> Combattimentos { get; set; } = new List<Combattimento>();

    public virtual ICollection<PartecipazioneClan> PartecipazioneClans { get; set; } = new List<PartecipazioneClan>();
}

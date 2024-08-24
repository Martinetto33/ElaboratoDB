using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Account
{
    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public Guid IdAccount { get; set; }

    public Guid IdGiocatore { get; set; }

    public virtual ICollection<AccountAttaccante> AccountAttaccantis { get; set; } = new List<AccountAttaccante>();

    public virtual ICollection<AccountDifensore> AccountDifensoris { get; set; } = new List<AccountDifensore>();

    public virtual Giocatore IdGiocatoreNavigation { get; set; } = null!;

    public virtual ICollection<PartecipazioneClan> PartecipazioniClans { get; set; } = new List<PartecipazioneClan>();

    public virtual VillaggioAccount? VillaggiAccount { get; set; }
}

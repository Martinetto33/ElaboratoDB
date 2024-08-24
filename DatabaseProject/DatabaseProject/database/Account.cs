using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Account
{
    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public Guid IdAccount { get; set; }

    public Guid IdGiocatore { get; set; }

    public virtual ICollection<AccountAttaccanti> AccountAttaccantis { get; set; } = new List<AccountAttaccanti>();

    public virtual ICollection<AccountDifensori> AccountDifensoris { get; set; } = new List<AccountDifensori>();

    public virtual Giocatori IdGiocatoreNavigation { get; set; } = null!;

    public virtual ICollection<PartecipazioniClan> PartecipazioniClans { get; set; } = new List<PartecipazioniClan>();

    public virtual VillaggiAccount? VillaggiAccount { get; set; }
}

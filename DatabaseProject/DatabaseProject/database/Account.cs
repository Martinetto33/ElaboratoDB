using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Account
{
    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public Guid IdAccount { get; set; }

    public Guid IdVillaggio { get; set; }

    public Guid IdGiocatore { get; set; }

    public virtual ICollection<AccountAttaccante> AccountAttaccantes { get; set; } = new List<AccountAttaccante>();

    public virtual ICollection<AccountDifensore> AccountDifensores { get; set; } = new List<AccountDifensore>();

    public virtual Giocatore IdGiocatoreNavigation { get; set; } = null!;

    public virtual Villaggio IdVillaggioNavigation { get; set; } = null!;

    public virtual ICollection<PartecipazioneClan> PartecipazioneClans { get; set; } = new List<PartecipazioneClan>();
}

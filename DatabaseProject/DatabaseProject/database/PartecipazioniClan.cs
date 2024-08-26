using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class PartecipazioniClan
{
    public Guid IdClan { get; set; }

    public Guid IdAccount { get; set; }

    public DateTime DataInizio { get; set; }

    public DateTime? DataFine { get; set; }

    public string Ruolo { get; set; } = null!;

    public virtual Account IdAccountNavigation { get; set; } = null!;

    public virtual Clan IdClanNavigation { get; set; } = null!;
}

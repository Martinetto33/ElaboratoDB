using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class PartecipazioneClan
{
    public Guid IdClan { get; set; }

    public Guid IdAccount { get; set; }

    public DateOnly DataInizio { get; set; }

    public DateOnly? DataFine { get; set; }

    public string Ruolo { get; set; } = null!;

    public virtual Account IdAccountNavigation { get; set; } = null!;

    public virtual Clan IdClanNavigation { get; set; } = null!;
}

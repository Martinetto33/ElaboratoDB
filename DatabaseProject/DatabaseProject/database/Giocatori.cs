using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Giocatori
{
    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public Guid IdGiocatore { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}

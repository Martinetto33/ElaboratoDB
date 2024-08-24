using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class AccountDifensore
{
    public Guid IdAttacco { get; set; }

    public Guid IdAccount { get; set; }

    public virtual Account IdAccountNavigation { get; set; } = null!;

    public virtual Attacco IdAttaccoNavigation { get; set; } = null!;
}

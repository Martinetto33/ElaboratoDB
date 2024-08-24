using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class AccountDifensori
{
    public Guid IdAttacco { get; set; }

    public Guid IdAccount { get; set; }

    public virtual Account IdAccountNavigation { get; set; } = null!;

    public virtual Attacchi IdAttaccoNavigation { get; set; } = null!;
}

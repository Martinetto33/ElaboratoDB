﻿namespace DatabaseProject.database;

public partial class AccountAttaccante
{
    public Guid IdAttacco { get; set; }

    public int TrofeiOttenuti { get; set; }

    public Guid IdAccount { get; set; }

    public virtual Account IdAccountNavigation { get; set; } = null!;

    public virtual Attacco IdAttaccoNavigation { get; set; } = null!;
}

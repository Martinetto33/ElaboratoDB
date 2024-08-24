using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Combattimenti
{
    public Guid IdGuerra { get; set; }

    public Guid IdClan { get; set; }

    public int StelleOttenute { get; set; }

    public int AttacchiEffettuati { get; set; }

    public float TempoMedioAttacco { get; set; }

    public string Vincitore { get; set; } = null!;

    public virtual Clan IdClanNavigation { get; set; } = null!;

    public virtual Guerre IdGuerraNavigation { get; set; } = null!;
}

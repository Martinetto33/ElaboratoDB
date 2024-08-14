using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Attacco
{
    public float TempoImpiegato { get; set; }

    public int PercentualeDistruzione { get; set; }

    public int StelleOttenute { get; set; }

    public Guid IdAttacco { get; set; }

    public Guid IdGuerra { get; set; }

    public virtual AccountAttaccante? AccountAttaccante { get; set; }

    public virtual AccountDifensore? AccountDifensore { get; set; }

    public virtual Guerra IdGuerraNavigation { get; set; } = null!;
}

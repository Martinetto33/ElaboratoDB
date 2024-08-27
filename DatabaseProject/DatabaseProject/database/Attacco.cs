using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Attacco
{
    public float TempoImpiegato { get; set; }

    public int PercentualeDistruzione { get; set; }

    public int StelleOttenute { get; set; }

    public int TrofeiAttaccante { get; set; }

    public int TrofeiDifensore { get; set; }

    public Guid IdAttacco { get; set; }

    public virtual AccountAttaccante? AccountAttaccanti { get; set; }

    public virtual AccountDifensore? AccountDifensori { get; set; }

    public virtual AttaccoEGuerra? AttacchiEGuerre { get; set; }
}

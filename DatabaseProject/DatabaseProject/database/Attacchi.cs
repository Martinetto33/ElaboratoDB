using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Attacchi
{
    public float TempoImpiegato { get; set; }

    public int PercentualeDistruzione { get; set; }

    public int StelleOttenute { get; set; }

    public int TrofeiAttaccante { get; set; }

    public int TrofeiDifensore { get; set; }

    public Guid IdAttacco { get; set; }

    public virtual AccountAttaccanti? AccountAttaccanti { get; set; }

    public virtual AccountDifensori? AccountDifensori { get; set; }

    public virtual AttacchiEGuerre? AttacchiEGuerre { get; set; }
}

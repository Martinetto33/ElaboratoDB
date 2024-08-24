using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class MiglioramentiTruppa
{
    public Guid IdVillaggio { get; set; }

    public string NomeTruppa { get; set; } = null!;

    public int LivelloMiglioramento { get; set; }

    public virtual TruppaInVillaggio TruppeInVillaggio { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Guerre
{
    public Guid IdGuerra { get; set; }

    public string InCorso { get; set; } = null!;

    public virtual ICollection<AttacchiEGuerre> AttacchiEGuerres { get; set; } = new List<AttacchiEGuerre>();

    public virtual ICollection<Combattimenti> Combattimentis { get; set; } = new List<Combattimenti>();
}

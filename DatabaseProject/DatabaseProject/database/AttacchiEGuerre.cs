using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class AttacchiEGuerre
{
    public Guid IdAttacco { get; set; }

    public Guid IdGuerra { get; set; }

    public virtual Attacchi IdAttaccoNavigation { get; set; } = null!;

    public virtual Guerre IdGuerraNavigation { get; set; } = null!;
}

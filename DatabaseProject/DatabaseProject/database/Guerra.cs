using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Guerra
{
    public Guid IdGuerra { get; set; }

    public string InCorso { get; set; } = null!;

    public virtual ICollection<AttaccoEGuerra> AttacchiEGuerre { get; set; } = new List<AttaccoEGuerra>();

    public virtual ICollection<Combattimento> Combattimenti { get; set; } = new List<Combattimento>();
}

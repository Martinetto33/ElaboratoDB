using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Guerra
{
    public Guid IdGuerra { get; set; }

    public string InCorso { get; set; } = null!;

    public virtual ICollection<AttacchiEGuerre> AttacchiEGuerre { get; set; } = new List<AttacchiEGuerre>();

    public virtual ICollection<Combattimento> Combattimenti { get; set; } = new List<Combattimento>();
}

using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Guerra
{
    public Guid IdGuerra { get; set; }

    public string InCorso { get; set; } = null!;

    public virtual ICollection<Attacco> Attaccos { get; set; } = new List<Attacco>();

    public virtual ICollection<Combattimento> Combattimentos { get; set; } = new List<Combattimento>();
}

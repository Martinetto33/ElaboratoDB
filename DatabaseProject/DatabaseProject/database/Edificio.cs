using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class Edificio
{
    public Guid IdVillaggio { get; set; }

    public string Nome { get; set; } = null!;

    public int Livello { get; set; }

    public int PuntiVita { get; set; }

    public int IdEdificio { get; set; }

    public string Tipo { get; set; } = null!;

    public int? DanniAlSecondo { get; set; }

    public int? NumeroBersagli { get; set; }

    public int? RaggioAzione { get; set; }

    public string? TipoRisorsa { get; set; }

    public int? ProduzioneOraria { get; set; }

    public string? DescrizioneFunzione { get; set; }

    public string? Ruolo { get; set; }

    public string? Occupato { get; set; }

    public virtual Villaggio IdVillaggioNavigation { get; set; } = null!;

    public virtual ICollection<MiglioramentoEdificio> MiglioramentoEdificios { get; set; } = new List<MiglioramentoEdificio>();

    public virtual ICollection<MiglioramentoTruppa> MiglioramentoTruppas { get; set; } = new List<MiglioramentoTruppa>();
}

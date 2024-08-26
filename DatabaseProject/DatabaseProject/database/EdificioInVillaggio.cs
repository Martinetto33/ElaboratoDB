using System;
using System.Collections.Generic;

namespace DatabaseProject.database;

public partial class EdificioInVillaggio
{
    public Guid IdVillaggio { get; set; }

    public int IdEdificio { get; set; }

    public string Categoria { get; set; } = null!;

    public int? DanniAlSecondo { get; set; }

    public int? NumeroBersagli { get; set; }

    public int? RaggioAzione { get; set; }

    public string? TipoRisorsa { get; set; }

    public int? ProduzioneOraria { get; set; }

    public string? DescrizioneFunzione { get; set; }

    public string? RuoloEdificioSpeciale { get; set; }

    public string Nome { get; set; } = null!;

    public int LivelloMiglioramento { get; set; }

    public virtual Villaggio IdVillaggioNavigation { get; set; } = null!;

    public virtual ICollection<MiglioramentoEdificio> MiglioramentiEdificios { get; set; } = new List<MiglioramentoEdificio>();

    public virtual StatisticheEdificioMigliorato StatisticheEdificiMigliorati { get; set; } = null!;
}

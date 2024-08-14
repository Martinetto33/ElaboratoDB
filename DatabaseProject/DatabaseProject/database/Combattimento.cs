namespace DatabaseProject.database;

public partial class Combattimento
{
    public Guid IdGuerra { get; set; }

    public Guid IdClan { get; set; }

    public int StelleOttenute { get; set; }

    public int AttacchiEffettuati { get; set; }

    public float TempoMedioAttacco { get; set; }

    public string Vincitore { get; set; } = null!;

    public virtual Clan IdClanNavigation { get; set; } = null!;

    public virtual Guerra IdGuerraNavigation { get; set; } = null!;
}

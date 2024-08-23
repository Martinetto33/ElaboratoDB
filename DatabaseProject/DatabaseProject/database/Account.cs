namespace DatabaseProject.database;

public partial class Account
{
    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public Guid IdAccount { get; set; }

    public Guid IdVillaggio { get; set; }

    public Guid IdGiocatore { get; set; }

    public virtual ICollection<AccountAttaccante> AccountAttaccanti { get; set; } = new List<AccountAttaccante>();

    public virtual ICollection<AccountDifensore> AccountDifensori { get; set; } = new List<AccountDifensore>();

    public virtual Giocatore IdGiocatoreNavigation { get; set; } = null!;

    public virtual Villaggio IdVillaggioNavigation { get; set; } = null!;

    public virtual ICollection<PartecipazioneClan> PartecipazioniClan { get; set; } = new List<PartecipazioneClan>();
}

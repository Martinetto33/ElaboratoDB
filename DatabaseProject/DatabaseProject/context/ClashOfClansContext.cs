using DatabaseProject.config;
using DatabaseProject.database;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProject.context;

public partial class ClashOfClansContext : DbContext
{
    public ClashOfClansContext()
    {
    }

    public ClashOfClansContext(DbContextOptions<ClashOfClansContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountAttaccante> AccountAttaccanti { get; set; }

    public virtual DbSet<AccountDifensore> AccountDifensori { get; set; }

    public virtual DbSet<Attacco> Attacchi { get; set; }

    public virtual DbSet<Clan> Clans { get; set; }

    public virtual DbSet<Combattimento> Combattimenti { get; set; }

    public virtual DbSet<Costruttore> Costruttori { get; set; }

    public virtual DbSet<Edificio> Edifici { get; set; }

    public virtual DbSet<Giocatore> Giocatori { get; set; }

    public virtual DbSet<Guerra> Guerre { get; set; }

    public virtual DbSet<MiglioramentoEdificio> MiglioramentoEdifici { get; set; }

    public virtual DbSet<MiglioramentoTruppa> MiglioramentoTruppe { get; set; }

    public virtual DbSet<PartecipazioneClan> PartecipazioniClan { get; set; }

    public virtual DbSet<Truppa> Truppe { get; set; }

    public virtual DbSet<Villaggio> Villaggi { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql(Configuration.CONNECTION_STRING, Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.IdAccount).HasName("PRIMARY");

            entity.ToTable("account");

            entity.HasIndex(e => e.IdVillaggio, "FKAPPARTENENZA_ID").IsUnique();

            entity.HasIndex(e => e.IdGiocatore, "FKPROPRIETA");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.IdGiocatoreNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.IdGiocatore)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKPROPRIETA");

            entity.HasOne(d => d.IdVillaggioNavigation).WithOne(p => p.Account)
                .HasForeignKey<Account>(d => d.IdVillaggio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKAPPARTENENZA_FK");
        });

        modelBuilder.Entity<AccountAttaccante>(entity =>
        {
            entity.HasKey(e => e.IdAttacco).HasName("PRIMARY");

            entity.ToTable("account_attaccante");

            entity.HasIndex(e => e.IdAccount, "FKACC_ACC_ATTACKER");

            entity.Property(e => e.IdAttacco).ValueGeneratedOnAdd();
            entity.Property(e => e.TrofeiOttenuti).HasColumnType("int(11)");

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.AccountAttaccanti)
                .HasForeignKey(d => d.IdAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKACC_ACC_ATTACKER");

            entity.HasOne(d => d.IdAttaccoNavigation).WithOne(p => p.AccountAttaccante)
                .HasForeignKey<AccountAttaccante>(d => d.IdAttacco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKACC_ATT_FK_ATTACKER");
        });

        modelBuilder.Entity<AccountDifensore>(entity =>
        {
            entity.HasKey(e => e.IdAttacco).HasName("PRIMARY");

            entity.ToTable("account_difensore");

            entity.HasIndex(e => e.IdAccount, "FKACC_ACC_DEFENDER");

            entity.Property(e => e.IdAttacco).ValueGeneratedOnAdd();
            entity.Property(e => e.TrofeiOttenuti).HasColumnType("int(11)");

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.AccountDifensori)
                .HasForeignKey(d => d.IdAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKACC_ACC_DEFENDER");

            entity.HasOne(d => d.IdAttaccoNavigation).WithOne(p => p.AccountDifensore)
                .HasForeignKey<AccountDifensore>(d => d.IdAttacco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKACC_ATT_FK_DEFENDER");
        });

        modelBuilder.Entity<Attacco>(entity =>
        {
            entity.HasKey(e => e.IdAttacco).HasName("PRIMARY");

            entity.ToTable("attacco");

            entity.HasIndex(e => e.IdGuerra, "FKCOSTITUZIONE");

            entity.Property(e => e.PercentualeDistruzione).HasColumnType("int(11)");
            entity.Property(e => e.StelleOttenute).HasColumnType("int(11)");

            entity.HasOne(d => d.IdGuerraNavigation).WithMany(p => p.Attaccos)
                .HasForeignKey(d => d.IdGuerra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCOSTITUZIONE");
        });

        modelBuilder.Entity<Clan>(entity =>
        {
            entity.HasKey(e => e.IdClan).HasName("PRIMARY");

            entity.ToTable("clan");

            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.NumeroMembri).HasColumnType("int(11)");
            entity.Property(e => e.StelleGuerraTotali).HasColumnType("int(11)");
            entity.Property(e => e.TrofeiTotali).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Combattimento>(entity =>
        {
            entity.HasKey(e => new { e.IdGuerra, e.IdClan })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("combattimento");

            entity.HasIndex(e => e.IdClan, "FKCOM_CLA");

            entity.Property(e => e.AttacchiEffettuati).HasColumnType("int(11)");
            entity.Property(e => e.StelleOttenute).HasColumnType("int(11)");
            entity.Property(e => e.Vincitore)
                .HasMaxLength(1)
                .IsFixedLength();

            entity.HasOne(d => d.IdClanNavigation).WithMany(p => p.Combattimentos)
                .HasForeignKey(d => d.IdClan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCOM_CLA");

            entity.HasOne(d => d.IdGuerraNavigation).WithMany(p => p.Combattimentos)
                .HasForeignKey(d => d.IdGuerra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCOM_GUE");
        });

        modelBuilder.Entity<Costruttore>(entity =>
        {
            entity.HasKey(e => new { e.IdVillaggio, e.IdCostruttore })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("costruttore");

            entity.HasIndex(e => e.LivelloMiglioramento, "FKLAVORO_COSTRUTTORE_ID").IsUnique();

            entity.Property(e => e.IdCostruttore).HasColumnType("int(11)");
            entity.Property(e => e.LivelloMiglioramento).HasColumnType("int(11)");
            entity.Property(e => e.Occupato)
                .HasMaxLength(1)
                .IsFixedLength();

            entity.HasOne(d => d.IdVillaggioNavigation).WithMany(p => p.Costruttores)
                .HasForeignKey(d => d.IdVillaggio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCOLLABORAZIONE");

            entity.HasOne(d => d.LivelloMiglioramentoNavigation).WithOne(p => p.Costruttore)
                .HasForeignKey<Costruttore>(d => d.LivelloMiglioramento)
                .HasConstraintName("FKLAVORO_COSTRUTTORE_FK");
        });

        modelBuilder.Entity<Edificio>(entity =>
        {
            entity.HasKey(e => new { e.IdVillaggio, e.IdEdificio })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("edificio");

            entity.Property(e => e.IdEdificio).HasColumnType("int(11)");
            entity.Property(e => e.DanniAlSecondo).HasColumnType("int(11)");
            entity.Property(e => e.DescrizioneFunzione).HasMaxLength(500);
            entity.Property(e => e.Livello).HasColumnType("int(11)");
            entity.Property(e => e.Nome).HasMaxLength(50);
            entity.Property(e => e.NumeroBersagli).HasColumnType("int(11)");
            entity.Property(e => e.Occupato)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.ProduzioneOraria).HasColumnType("int(11)");
            entity.Property(e => e.PuntiVita).HasColumnType("int(11)");
            entity.Property(e => e.RaggioAzione).HasColumnType("int(11)");
            entity.Property(e => e.Ruolo).HasMaxLength(100);
            entity.Property(e => e.Tipo).HasMaxLength(50);
            entity.Property(e => e.TipoRisorsa).HasMaxLength(30);

            entity.HasOne(d => d.IdVillaggioNavigation).WithMany(p => p.Edificios)
                .HasForeignKey(d => d.IdVillaggio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCOMPOSIZIONE");
        });

        modelBuilder.Entity<Giocatore>(entity =>
        {
            entity.HasKey(e => e.IdGiocatore).HasName("PRIMARY");

            entity.ToTable("giocatore");

            entity.Property(e => e.Cognome).HasMaxLength(50);
            entity.Property(e => e.Nome).HasMaxLength(50);
        });

        modelBuilder.Entity<Guerra>(entity =>
        {
            entity.HasKey(e => e.IdGuerra).HasName("PRIMARY");

            entity.ToTable("guerra");

            entity.Property(e => e.InCorso)
                .HasMaxLength(1)
                .IsFixedLength();
        });

        modelBuilder.Entity<MiglioramentoEdificio>(entity =>
        {
            entity.HasKey(e => e.LivelloMiglioramento).HasName("PRIMARY");

            entity.ToTable("miglioramento_edificio");

            entity.HasIndex(e => new { e.IdVillaggio, e.IdEdificio }, "FKEVOLUZIONE_EDIFICIO");

            entity.Property(e => e.LivelloMiglioramento)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Costo).HasColumnType("int(11)");
            entity.Property(e => e.Durata).HasColumnType("int(11)");
            entity.Property(e => e.IdEdificio).HasColumnType("int(11)");
            entity.Property(e => e.PuntiEsperienzaConferiti).HasColumnType("int(11)");

            entity.HasOne(d => d.Edificio).WithMany(p => p.MiglioramentoEdificios)
                .HasForeignKey(d => new { d.IdVillaggio, d.IdEdificio })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKEVOLUZIONE_EDIFICIO");
        });

        modelBuilder.Entity<MiglioramentoTruppa>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.LivelloMiglioramento })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("miglioramento_truppa");

            entity.HasIndex(e => new { e.IdVillaggio, e.IdEdificio }, "FKLAVORO_LABORATORIO");

            entity.Property(e => e.LivelloMiglioramento).HasColumnType("int(11)");
            entity.Property(e => e.Costo).HasColumnType("int(11)");
            entity.Property(e => e.Durata).HasColumnType("int(11)");
            entity.Property(e => e.IdEdificio).HasColumnType("int(11)");
            entity.Property(e => e.PuntiEsperienzaConferiti).HasColumnType("int(11)");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.MiglioramentoTruppas)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKEVOLUZIONE_TRUPPA");

            entity.HasOne(d => d.Edificio).WithMany(p => p.MiglioramentoTruppas)
                .HasForeignKey(d => new { d.IdVillaggio, d.IdEdificio })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKLAVORO_LABORATORIO");
        });

        modelBuilder.Entity<PartecipazioneClan>(entity =>
        {
            entity.HasKey(e => new { e.IdClan, e.IdAccount, e.DataInizio })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("partecipazione_clan");

            entity.HasIndex(e => e.IdAccount, "FKPERMANENZA");

            entity.Property(e => e.Ruolo).HasMaxLength(20);

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.PartecipazioniClan)
                .HasForeignKey(d => d.IdAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKPERMANENZA");

            entity.HasOne(d => d.IdClanNavigation).WithMany(p => p.PartecipazioneClans)
                .HasForeignKey(d => d.IdClan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKACCOGLIENZA");
        });

        modelBuilder.Entity<Truppa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("truppa");

            entity.HasIndex(e => e.IdVillaggio, "FKDISPONIBILITA");

            entity.Property(e => e.DanniInflitti).HasColumnType("int(11)");
            entity.Property(e => e.Descrizione).HasMaxLength(500);
            entity.Property(e => e.Livello).HasColumnType("int(11)");
            entity.Property(e => e.Nome).HasMaxLength(50);
            entity.Property(e => e.PuntiVita).HasColumnType("int(11)");

            entity.HasOne(d => d.IdVillaggioNavigation).WithMany(p => p.Truppas)
                .HasForeignKey(d => d.IdVillaggio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKDISPONIBILITA");
        });

        modelBuilder.Entity<Villaggio>(entity =>
        {
            entity.HasKey(e => e.IdVillaggio).HasName("PRIMARY");

            entity.ToTable("villaggio");

            entity.Property(e => e.LivelloEsperienza).HasColumnType("int(11)");
            entity.Property(e => e.NumeroStelleGuerra).HasColumnType("int(11)");
            entity.Property(e => e.NumeroTrofei).HasColumnType("int(11)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

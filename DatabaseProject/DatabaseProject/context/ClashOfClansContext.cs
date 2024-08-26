using System;
using System.Collections.Generic;
using DatabaseProject.database;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

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

    public virtual DbSet<Account> Account { get; set; }

    public virtual DbSet<AccountAttaccante> AccountAttaccanti { get; set; }

    public virtual DbSet<AccountDifensore> AccountDifensori { get; set; }

    public virtual DbSet<Attacco> Attacchi { get; set; }

    public virtual DbSet<AttacchiEGuerre> AttacchiEGuerre { get; set; }

    public virtual DbSet<Clan> Clan { get; set; }

    public virtual DbSet<Combattimento> Combattimenti { get; set; }

    public virtual DbSet<Costruttore> Costruttori { get; set; }

    public virtual DbSet<EdificioInVillaggio> EdificiInVillaggio { get; set; }

    public virtual DbSet<Giocatore> Giocatori { get; set; }

    public virtual DbSet<Guerra> Guerre { get; set; }

    public virtual DbSet<MiglioramentoEdificio> MiglioramentiEdificio { get; set; }

    public virtual DbSet<MiglioramentiTruppa> MiglioramentiTruppa { get; set; }

    public virtual DbSet<PartecipazioneClan> PartecipazioniClan { get; set; }

    public virtual DbSet<StatisticheEdificioMigliorato> StatisticheEdificiMigliorati { get; set; }

    public virtual DbSet<StatisticheTruppaMigliorata> StatisticheTruppeMigliorate { get; set; }

    public virtual DbSet<TipoEdificio> TipiEdificio { get; set; }

    public virtual DbSet<TipoTruppa> TipiTruppa { get; set; }

    public virtual DbSet<TruppaInVillaggio> TruppeInVillaggio { get; set; }

    public virtual DbSet<Villaggio> Villaggi { get; set; }

    public virtual DbSet<VillaggioAccount> VillaggiAccount { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=clash_of_clans_v2;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.IdAccount).HasName("PRIMARY");

            entity.ToTable("account");

            entity.HasIndex(e => e.IdGiocatore, "FKPROPRIETA");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.IdGiocatoreNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.IdGiocatore)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKPROPRIETA");
        });

        modelBuilder.Entity<AccountAttaccante>(entity =>
        {
            entity.HasKey(e => e.IdAttacco).HasName("PRIMARY");

            entity.ToTable("account_attaccanti");

            entity.HasIndex(e => e.IdAccount, "FKACC_ACC");

            entity.Property(e => e.IdAttacco).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.AccountAttaccantis)
                .HasForeignKey(d => d.IdAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKACC_ACC");

            entity.HasOne(d => d.IdAttaccoNavigation).WithOne(p => p.AccountAttaccanti)
                .HasForeignKey<AccountAttaccante>(d => d.IdAttacco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKACC_ATT_FK");
        });

        modelBuilder.Entity<AccountDifensore>(entity =>
        {
            entity.HasKey(e => e.IdAttacco).HasName("PRIMARY");

            entity.ToTable("account_difensori");

            entity.HasIndex(e => e.IdAccount, "FKACC_ACC_1");

            entity.Property(e => e.IdAttacco).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.AccountDifensoris)
                .HasForeignKey(d => d.IdAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKACC_ACC_1");

            entity.HasOne(d => d.IdAttaccoNavigation).WithOne(p => p.AccountDifensori)
                .HasForeignKey<AccountDifensore>(d => d.IdAttacco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKACC_ATT_1_FK");
        });

        modelBuilder.Entity<Attacco>(entity =>
        {
            entity.HasKey(e => e.IdAttacco).HasName("PRIMARY");

            entity.ToTable("attacchi");

            entity.Property(e => e.PercentualeDistruzione).HasColumnType("int(11)");
            entity.Property(e => e.StelleOttenute).HasColumnType("int(11)");
            entity.Property(e => e.TrofeiAttaccante).HasColumnType("int(11)");
            entity.Property(e => e.TrofeiDifensore).HasColumnType("int(11)");
        });

        modelBuilder.Entity<AttacchiEGuerre>(entity =>
        {
            entity.HasKey(e => e.IdAttacco).HasName("PRIMARY");

            entity.ToTable("attacchi_e_guerre");

            entity.HasIndex(e => e.IdGuerra, "FKIDENTIFICAZIONE_GUERRA");

            entity.Property(e => e.IdAttacco).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdAttaccoNavigation).WithOne(p => p.AttacchiEGuerre)
                .HasForeignKey<AttacchiEGuerre>(d => d.IdAttacco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKIDENTIFICAZIONE_ATTACCO_FK");

            entity.HasOne(d => d.IdGuerraNavigation).WithMany(p => p.AttacchiEGuerres)
                .HasForeignKey(d => d.IdGuerra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKIDENTIFICAZIONE_GUERRA");
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

            entity.ToTable("combattimenti");

            entity.HasIndex(e => e.IdClan, "FKCOM_CLA");

            entity.Property(e => e.AttacchiEffettuati).HasColumnType("int(11)");
            entity.Property(e => e.StelleOttenute).HasColumnType("int(11)");
            entity.Property(e => e.Vincitore)
                .HasMaxLength(1)
                .IsFixedLength();

            entity.HasOne(d => d.IdClanNavigation).WithMany(p => p.Combattimenti)
                .HasForeignKey(d => d.IdClan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCOM_CLA");

            entity.HasOne(d => d.IdGuerraNavigation).WithMany(p => p.Combattimentis)
                .HasForeignKey(d => d.IdGuerra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCOM_GUE");
        });

        modelBuilder.Entity<Costruttore>(entity =>
        {
            entity.HasKey(e => new { e.IdVillaggio, e.IdCostruttore })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("costruttori");

            entity.Property(e => e.IdCostruttore).HasColumnType("int(11)");

            entity.HasOne(d => d.IdVillaggioNavigation).WithMany(p => p.Costruttori)
                .HasForeignKey(d => d.IdVillaggio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCOLLABORAZIONE");
        });

        modelBuilder.Entity<EdificioInVillaggio>(entity =>
        {
            entity.HasKey(e => new { e.IdVillaggio, e.IdEdificio })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("edifici_in_villaggio");

            entity.HasIndex(e => new { e.Nome, e.LivelloMiglioramento }, "FKCONFERIMENTO_STATISTICHE_EDIFICIO");

            entity.Property(e => e.IdEdificio).HasColumnType("int(11)");
            entity.Property(e => e.Categoria).HasMaxLength(50);
            entity.Property(e => e.DanniAlSecondo).HasColumnType("int(11)");
            entity.Property(e => e.DescrizioneFunzione).HasMaxLength(500);
            entity.Property(e => e.LivelloMiglioramento).HasColumnType("int(11)");
            entity.Property(e => e.Nome).HasMaxLength(50);
            entity.Property(e => e.NumeroBersagli).HasColumnType("int(11)");
            entity.Property(e => e.ProduzioneOraria).HasColumnType("int(11)");
            entity.Property(e => e.RaggioAzione).HasColumnType("int(11)");
            entity.Property(e => e.RuoloEdificioSpeciale).HasMaxLength(100);
            entity.Property(e => e.TipoRisorsa).HasMaxLength(30);

            entity.HasOne(d => d.IdVillaggioNavigation).WithMany(p => p.EdificiInVillaggio)
                .HasForeignKey(d => d.IdVillaggio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCOMPOSIZIONE");

            entity.HasOne(d => d.StatisticheEdificiMigliorati).WithMany(p => p.EdificiInVillaggios)
                .HasForeignKey(d => new { d.Nome, d.LivelloMiglioramento })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCONFERIMENTO_STATISTICHE_EDIFICIO");
        });

        modelBuilder.Entity<Giocatore>(entity =>
        {
            entity.HasKey(e => e.IdGiocatore).HasName("PRIMARY");

            entity.ToTable("giocatori");

            entity.Property(e => e.Cognome).HasMaxLength(50);
            entity.Property(e => e.Nome).HasMaxLength(50);
        });

        modelBuilder.Entity<Guerra>(entity =>
        {
            entity.HasKey(e => e.IdGuerra).HasName("PRIMARY");

            entity.ToTable("guerre");

            entity.Property(e => e.InCorso)
                .HasMaxLength(1)
                .IsFixedLength();
        });

        modelBuilder.Entity<MiglioramentoEdificio>(entity =>
        {
            entity.HasKey(e => new { e.IdVillaggio, e.IdEdificio, e.LivelloMiglioramento })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("miglioramenti_edificio");

            entity.Property(e => e.IdEdificio).HasColumnType("int(11)");
            entity.Property(e => e.LivelloMiglioramento).HasColumnType("int(11)");
            entity.Property(e => e.Costo).HasColumnType("int(11)");
            entity.Property(e => e.DurataMs)
                .HasColumnType("int(11)")
                .HasColumnName("DurataMS");
            entity.Property(e => e.IdCostruttore).HasColumnType("int(11)");
            entity.Property(e => e.PuntiEsperienzaConferiti).HasColumnType("int(11)");

            entity.HasOne(d => d.EdificiInVillaggio).WithMany(p => p.MiglioramentiEdificios)
                .HasForeignKey(d => new { d.IdVillaggio, d.IdEdificio })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKEVOLUZIONE_EDIFICIO");
        });

        modelBuilder.Entity<MiglioramentiTruppa>(entity =>
        {
            entity.HasKey(e => new { e.IdVillaggio, e.NomeTruppa, e.LivelloMiglioramento })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("miglioramenti_truppa");

            entity.Property(e => e.NomeTruppa).HasMaxLength(50);
            entity.Property(e => e.LivelloMiglioramento).HasColumnType("int(11)");

            entity.HasOne(d => d.TruppeInVillaggio).WithMany(p => p.MiglioramentiTruppas)
                .HasForeignKey(d => new { d.IdVillaggio, d.NomeTruppa })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKEVOLUZIONE_TRUPPA");
        });

        modelBuilder.Entity<PartecipazioneClan>(entity =>
        {
            entity.HasKey(e => new { e.IdClan, e.IdAccount, e.DataInizio })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("partecipazioni_clan");

            entity.HasIndex(e => e.IdAccount, "FKPERMANENZA");

            entity.Property(e => e.DataInizio)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp(3)")
                .HasColumnType("timestamp(3)");
            entity.Property(e => e.DataFine).HasColumnType("timestamp(3)");
            entity.Property(e => e.Ruolo).HasMaxLength(20);

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.PartecipazioniClans)
                .HasForeignKey(d => d.IdAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKPERMANENZA");

            entity.HasOne(d => d.IdClanNavigation).WithMany(p => p.PartecipazioniClan)
                .HasForeignKey(d => d.IdClan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKACCOGLIENZA");
        });

        modelBuilder.Entity<StatisticheEdificioMigliorato>(entity =>
        {
            entity.HasKey(e => new { e.Nome, e.LivelloMiglioramento })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("statistiche_edifici_migliorati");

            entity.Property(e => e.Nome).HasMaxLength(50);
            entity.Property(e => e.LivelloMiglioramento).HasColumnType("int(11)");
            entity.Property(e => e.PuntiVita).HasColumnType("int(11)");

            entity.HasOne(d => d.NomeNavigation).WithMany(p => p.StatisticheEdificiMiglioratis)
                .HasForeignKey(d => d.Nome)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKNOME_STATISTICA_EDIFICIO");
        });

        modelBuilder.Entity<StatisticheTruppaMigliorata>(entity =>
        {
            entity.HasKey(e => new { e.LivelloMiglioramento, e.Nome })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("statistiche_truppe_migliorate");

            entity.HasIndex(e => e.Nome, "FKBONUS_MIGLIORAMENTO_TRUPPA_R");

            entity.Property(e => e.LivelloMiglioramento).HasColumnType("int(11)");
            entity.Property(e => e.Nome).HasMaxLength(50);
            entity.Property(e => e.Costo).HasColumnType("int(11)");
            entity.Property(e => e.DanniInflitti).HasColumnType("int(11)");
            entity.Property(e => e.DurataMs)
                .HasColumnType("int(11)")
                .HasColumnName("DurataMS");
            entity.Property(e => e.PuntiEsperienzaConferiti).HasColumnType("int(11)");
            entity.Property(e => e.PuntiVita).HasColumnType("int(11)");

            entity.HasOne(d => d.NomeNavigation).WithMany(p => p.StatisticheTruppeMigliorates)
                .HasForeignKey(d => d.Nome)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKBONUS_MIGLIORAMENTO_TRUPPA_R");
        });

        modelBuilder.Entity<TipoEdificio>(entity =>
        {
            entity.HasKey(e => e.Nome).HasName("PRIMARY");

            entity.ToTable("tipi_edificio");

            entity.Property(e => e.Nome).HasMaxLength(50);
            entity.Property(e => e.Descrizione).HasMaxLength(500);
        });

        modelBuilder.Entity<TipoTruppa>(entity =>
        {
            entity.HasKey(e => e.Nome).HasName("PRIMARY");

            entity.ToTable("tipi_truppe");

            entity.Property(e => e.Nome).HasMaxLength(50);
            entity.Property(e => e.Descrizione).HasMaxLength(500);
        });

        modelBuilder.Entity<TruppaInVillaggio>(entity =>
        {
            entity.HasKey(e => new { e.IdVillaggio, e.Nome })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("truppe_in_villaggio");

            entity.HasIndex(e => e.Nome, "FKTIPOLOGIA_TRUPPA");

            entity.Property(e => e.Nome).HasMaxLength(50);
            entity.Property(e => e.Livello).HasColumnType("int(11)");

            entity.HasOne(d => d.IdVillaggioNavigation).WithMany(p => p.TruppeInVillaggio)
                .HasForeignKey(d => d.IdVillaggio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKDISPONIBILITA");

            entity.HasOne(d => d.NomeNavigation).WithMany(p => p.TruppeInVillaggios)
                .HasForeignKey(d => d.Nome)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTIPOLOGIA_TRUPPA");
        });

        modelBuilder.Entity<Villaggio>(entity =>
        {
            entity.HasKey(e => e.IdVillaggio).HasName("PRIMARY");

            entity.ToTable("villaggi");

            entity.Property(e => e.LivelloEsperienza).HasColumnType("int(11)");
            entity.Property(e => e.NumeroStelleGuerra).HasColumnType("int(11)");
            entity.Property(e => e.NumeroTrofei).HasColumnType("int(11)");
        });

        modelBuilder.Entity<VillaggioAccount>(entity =>
        {
            entity.HasKey(e => e.IdAccount).HasName("PRIMARY");

            entity.ToTable("villaggi_account");

            entity.HasIndex(e => e.IdVillaggio, "FKIDENTIFICAZIONE_VILLAGGIO_ID").IsUnique();

            entity.Property(e => e.IdAccount).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdAccountNavigation).WithOne(p => p.VillaggiAccount)
                .HasForeignKey<VillaggioAccount>(d => d.IdAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKIDENTIFICAZIONE_ACCOUNT_FK");

            entity.HasOne(d => d.IdVillaggioNavigation).WithOne(p => p.VillaggioAccount)
                .HasForeignKey<VillaggioAccount>(d => d.IdVillaggio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKIDENTIFICAZIONE_VILLAGGIO_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

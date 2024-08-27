-- *********************************************
-- * SQL MySQL generation                      
-- *--------------------------------------------
-- * DB-MAIN version: 11.0.2              
-- * Generator date: Sep 14 2021              
-- * Generation date: Sat Aug 24 18:58:14 2024 
-- * LUN file: C:\Users\marty\Desktop\Database Elaborato\Elaborato Database Clash of Clans.lun 
-- * Schema: Relazionale-3NF/1 
-- ********************************************* 

-- Tables Section
-- _____________ 

create table ACCOUNT (
     Username varchar(100) not null,
     Email varchar(100) not null,
     IdAccount char(36) not null,
     IdGiocatore char(36) not null,
     constraint IDACCOUNT_ID primary key (IdAccount));

create table ACCOUNT_ATTACCANTI (
     IdAttacco char(36) not null,
     IdAccount char(36) not null,
     constraint FKACC_ATT_ID primary key (IdAttacco));

create table ACCOUNT_DIFENSORI (
     IdAttacco char(36) not null,
     IdAccount char(36) not null,
     constraint FKACC_ATT_1_ID primary key (IdAttacco));

create table ATTACCHI (
     TempoImpiegato float(1) not null,
     PercentualeDistruzione int not null,
     StelleOttenute int not null,
     TrofeiAttaccante int not null,
     TrofeiDifensore int not null,
     IdAttacco char(36) not null,
     constraint IDATTACCO_ID primary key (IdAttacco));

create table CLAN (
     Nome varchar(100) not null,
     NumeroMembri int not null,
     TrofeiTotali int not null,
     StelleGuerraTotali int not null,
     IdClan char(36) not null,
     constraint IDCLAN_ID primary key (IdClan));

create table COMBATTIMENTI (
     IdGuerra char(36) not null,
     IdClan char(36) not null,
     StelleOttenute int not null,
     AttacchiEffettuati int not null,
     TempoMedioAttacco float(1) not null,
     Vincitore char not null,
     constraint IDCOMBATTIMENTO primary key (IdGuerra, IdClan));

create table COSTRUTTORI (
     IdVillaggio char(36) not null,
     IdCostruttore int not null,
     constraint IDCOSTRUTTORE primary key (IdVillaggio, IdCostruttore));

create table EDIFICI_IN_VILLAGGIO (
     IdVillaggio char(36) not null,
     IdEdificio int not null,
     Categoria varchar(50) not null,
     DanniAlSecondo int,
     NumeroBersagli int,
     RaggioAzione int,
     TipoRisorsa varchar(30),
     ProduzioneOraria int,
     DescrizioneFunzione varchar(500),
     RuoloEdificioSpeciale varchar(100),
     Nome varchar(50) not null,
     LivelloMiglioramento int not null,
     constraint IDEDIFICIO_1 primary key (IdVillaggio, IdEdificio));

create table TIPI_EDIFICIO (
     Nome varchar(50) not null,
     Descrizione varchar(500) not null,
     constraint IDTIPI_EDIFICIO primary key (Nome));

create table GIOCATORI (
     Nome varchar(50) not null,
     Cognome varchar(50) not null,
     IdGiocatore char(36) not null,
     constraint IDGIOCATORE_ID primary key (IdGiocatore));

create table GUERRE (
     IdGuerra char(36) not null,
     InCorso char not null,
     constraint IDGUERRA_ID primary key (IdGuerra));

create table MIGLIORAMENTI_EDIFICIO (
     IdVillaggio char(36) not null,
     IdEdificio int not null,
     DurataMS int not null,
     Costo int not null,
     LivelloMiglioramento int not null,
     PuntiEsperienzaConferiti int not null,
     IdCostruttore int not null,
     constraint IDMIGLIORAMENTO_EDIFICIO primary key (IdVillaggio, IdEdificio, LivelloMiglioramento));

create table MIGLIORAMENTI_TRUPPA (
     IdVillaggio char(36) not null,
     NomeTruppa varchar(50) not null,
     LivelloMiglioramento int not null,
     constraint IDMIGLIORAMENTI_TRUPPA primary key (IdVillaggio, NomeTruppa, LivelloMiglioramento));

create table PARTECIPAZIONI_CLAN (
     IdClan char(36) not null,
     IdAccount char(36) not null,
     DataInizio timestamp(3) not null,
     DataFine TIMESTAMP(3) NULL DEFAULT NULL, -- mannaggia a te DBMain
     Ruolo varchar(20) not null,
     constraint IDPARTECIPAZIONE_CLAN primary key (IdClan, IdAccount, DataInizio));

create table STATISTICHE_EDIFICI_MIGLIORATI (
     PuntiVita int not null,
     Nome varchar(50) not null,
     LivelloMiglioramento int not null,
     constraint IDSTATISTICHE_EDIFICI_MIGLIORATI primary key (Nome, LivelloMiglioramento));

create table VILLAGGI_ACCOUNT (
     IdAccount char(36) not null,
     IdVillaggio char(36) not null,
     constraint FKIDENTIFICAZIONE_ACCOUNT_ID primary key (IdAccount),
     constraint FKIDENTIFICAZIONE_VILLAGGIO_ID unique (IdVillaggio));

create table STATISTICHE_TRUPPE_MIGLIORATE (
     LivelloMiglioramento int not null,
     DurataMS int not null,
     Costo int not null,
     PuntiEsperienzaConferiti int not null,
     PuntiVita int not null,
     DanniInflitti int not null,
     Nome varchar(50) not null,
     constraint IDSTATISTICHE_TRUPPE_MIGLIORATE primary key (LivelloMiglioramento, Nome));

create table ATTACCHI_E_GUERRE (
     IdAttacco char(36) not null,
     IdGuerra char(36) not null,
     constraint FKIDENTIFICAZIONE_ATTACCO_ID primary key (IdAttacco));

create table TIPI_TRUPPE (
     Nome varchar(50) not null,
     Descrizione varchar(500) not null,
     constraint IDTIPI_TRUPPE primary key (Nome));

create table TRUPPE_IN_VILLAGGIO (
     IdVillaggio char(36) not null,
     Livello int not null,
     Nome varchar(50) not null,
     constraint IDTRUPPE primary key (IdVillaggio, Nome));

create table VILLAGGI (
     Forza float(1) not null,
     LivelloEsperienza int not null,
     NumeroTrofei int not null,
     NumeroStelleGuerra int not null,
     IdVillaggio char(36) not null,
     constraint IDVILLAGGIO_ID primary key (IdVillaggio));


-- Constraints Section
-- ___________________ 

-- Not implemented
-- alter table ACCOUNT add constraint IDACCOUNT_CHK
--     check(exists(select * from VILLAGGI_ACCOUNT
--                  where VILLAGGI_ACCOUNT.IdAccount = IdAccount)); 

alter table ACCOUNT add constraint FKPROPRIETA
     foreign key (IdGiocatore)
     references GIOCATORI (IdGiocatore);

alter table ACCOUNT_ATTACCANTI add constraint FKACC_ACC
     foreign key (IdAccount)
     references ACCOUNT (IdAccount);

alter table ACCOUNT_ATTACCANTI add constraint FKACC_ATT_FK
     foreign key (IdAttacco)
     references ATTACCHI (IdAttacco);

alter table ACCOUNT_DIFENSORI add constraint FKACC_ACC_1
     foreign key (IdAccount)
     references ACCOUNT (IdAccount);

alter table ACCOUNT_DIFENSORI add constraint FKACC_ATT_1_FK
     foreign key (IdAttacco)
     references ATTACCHI (IdAttacco);

-- Not implemented
-- alter table ATTACCHI add constraint IDATTACCO_CHK
--     check(exists(select * from ACCOUNT_ATTACCANTI
--                  where ACCOUNT_ATTACCANTI.IdAttacco = IdAttacco)); 

-- Not implemented
-- alter table ATTACCHI add constraint IDATTACCO_CHK
--     check(exists(select * from ATTACCHI_E_GUERRE
--                  where ATTACCHI_E_GUERRE.IdAttacco = IdAttacco)); 

-- Not implemented
-- alter table ATTACCHI add constraint IDATTACCO_CHK
--     check(exists(select * from ACCOUNT_DIFENSORI
--                  where ACCOUNT_DIFENSORI.IdAttacco = IdAttacco)); 

-- Not implemented
-- alter table CLAN add constraint IDCLAN_CHK
--     check(exists(select * from PARTECIPAZIONI_CLAN
--                  where PARTECIPAZIONI_CLAN.IdClan = IdClan)); 

alter table COMBATTIMENTI add constraint FKCOM_CLA
     foreign key (IdClan)
     references CLAN (IdClan);

alter table COMBATTIMENTI add constraint FKCOM_GUE
     foreign key (IdGuerra)
     references GUERRE (IdGuerra);

alter table COSTRUTTORI add constraint FKCOLLABORAZIONE
     foreign key (IdVillaggio)
     references VILLAGGI (IdVillaggio);

alter table EDIFICI_IN_VILLAGGIO add constraint FKCOMPOSIZIONE
     foreign key (IdVillaggio)
     references VILLAGGI (IdVillaggio);

alter table EDIFICI_IN_VILLAGGIO add constraint FKCONFERIMENTO_STATISTICHE_EDIFICIO
     foreign key (Nome, LivelloMiglioramento)
     references STATISTICHE_EDIFICI_MIGLIORATI (Nome, LivelloMiglioramento);

-- Not implemented
-- alter table GIOCATORI add constraint IDGIOCATORE_CHK
--     check(exists(select * from ACCOUNT
--                  where ACCOUNT.IdGiocatore = IdGiocatore)); 

-- Not implemented
-- alter table GUERRE add constraint IDGUERRA_CHK
--     check(exists(select * from COMBATTIMENTI
--                  where COMBATTIMENTI.IdGuerra = IdGuerra)); 

alter table MIGLIORAMENTI_EDIFICIO add constraint FKEVOLUZIONE_EDIFICIO
     foreign key (IdVillaggio, IdEdificio)
     references EDIFICI_IN_VILLAGGIO (IdVillaggio, IdEdificio);

alter table MIGLIORAMENTI_TRUPPA add constraint FKEVOLUZIONE_TRUPPA
     foreign key (IdVillaggio, NomeTruppa)
     references TRUPPE_IN_VILLAGGIO (IdVillaggio, Nome);

alter table PARTECIPAZIONI_CLAN add constraint FKPERMANENZA
     foreign key (IdAccount)
     references ACCOUNT (IdAccount);

alter table PARTECIPAZIONI_CLAN add constraint FKACCOGLIENZA
     foreign key (IdClan)
     references CLAN (IdClan);

alter table STATISTICHE_EDIFICI_MIGLIORATI add constraint FKNOME_STATISTICA_EDIFICIO
     foreign key (Nome)
     references TIPI_EDIFICIO (Nome);

alter table VILLAGGI_ACCOUNT add constraint FKIDENTIFICAZIONE_ACCOUNT_FK
     foreign key (IdAccount)
     references ACCOUNT (IdAccount);

alter table VILLAGGI_ACCOUNT add constraint FKIDENTIFICAZIONE_VILLAGGIO_FK
     foreign key (IdVillaggio)
     references VILLAGGI (IdVillaggio);

alter table STATISTICHE_TRUPPE_MIGLIORATE add constraint FKBONUS_MIGLIORAMENTO_TRUPPA_R
     foreign key (Nome)
     references TIPI_TRUPPE (Nome);

alter table ATTACCHI_E_GUERRE add constraint FKIDENTIFICAZIONE_ATTACCO_FK
     foreign key (IdAttacco)
     references ATTACCHI (IdAttacco);

alter table ATTACCHI_E_GUERRE add constraint FKIDENTIFICAZIONE_GUERRA
     foreign key (IdGuerra)
     references GUERRE (IdGuerra);

alter table TRUPPE_IN_VILLAGGIO add constraint FKDISPONIBILITA
     foreign key (IdVillaggio)
     references VILLAGGI (IdVillaggio);

alter table TRUPPE_IN_VILLAGGIO add constraint FKTIPOLOGIA_TRUPPA
     foreign key (Nome)
     references TIPI_TRUPPE (Nome);

-- Not implemented
-- alter table VILLAGGI add constraint IDVILLAGGIO_CHK
--     check(exists(select * from VILLAGGI_ACCOUNT
--                  where VILLAGGI_ACCOUNT.IdVillaggio = IdVillaggio)); 

-- Not implemented
-- alter table VILLAGGI add constraint IDVILLAGGIO_CHK
--     check(exists(select * from COSTRUTTORI
--                  where COSTRUTTORI.IdVillaggio = IdVillaggio)); 

-- Not implemented
-- alter table VILLAGGI add constraint IDVILLAGGIO_CHK
--     check(exists(select * from EDIFICI_IN_VILLAGGIO
--                  where EDIFICI_IN_VILLAGGIO.IdVillaggio = IdVillaggio)); 


-- Index Section
-- _____________ 


-- *********************************************
-- * SQL MySQL generation                      
-- *--------------------------------------------
-- * DB-MAIN version: 11.0.2              
-- * Generator date: Sep 14 2021              
-- * Generation date: Mon Aug 12 13:28:56 2024 
-- * LUN file: C:\Users\marty\Desktop\Database Elaborato\Elaborato Database Clash of Clans.lun 
-- * Schema: Relazionale/1-1-1 
-- ********************************************* 
-- Tables Section
-- _____________ 

create table ACCOUNT (
     Username varchar(100) not null,
     Email varchar(100) not null,
     IdAccount char(36) not null,
     IdVillaggio char(36) not null,
     IdGiocatore char(36) not null,
     constraint IDACCOUNT primary key (IdAccount),
     constraint FKAPPARTENENZA_ID unique (IdVillaggio));

create table ACCOUNT_ATTACCANTE (
     IdAttacco char(36) not null,
     TrofeiOttenuti int not null,
     IdAccount char(36) not null,
     constraint FKACC_ATT_ID primary key (IdAttacco));

create table ACCOUNT_DIFENSORE (
     IdAttacco char(36) not null,
     TrofeiOttenuti int not null,
     IdAccount char(36) not null,
     constraint FKACC_ATT_ID primary key (IdAttacco));

create table ATTACCO (
     TempoImpiegato float(1) not null,
     PercentualeDistruzione int not null,
     StelleOttenute int not null,
     IdAttacco char(36) not null,
     IdGuerra char(36) not null,
     constraint IDATTACCO_ID primary key (IdAttacco));

create table CLAN (
     Nome varchar(100) not null,
     NumeroMembri int not null,
     TrofeiTotali int not null,
     StelleGuerraTotali int not null,
     IdClan char(36) not null,
     constraint IDCLAN_ID primary key (IdClan));

create table COMBATTIMENTO (
     IdGuerra char(36) not null,
     IdClan char(36) not null,
     StelleOttenute int not null,
     AttacchiEffettuati int not null,
     TempoMedioAttacco float(1) not null,
     Vincitore char not null,
     constraint IDCOMBATTIMENTO primary key (IdGuerra, IdClan));

create table COSTRUTTORE (
     IdVillaggio char(36) not null,
     IdCostruttore int not null,
     LivelloMiglioramento int,
     Occupato char not null,
     constraint IDCOSTRUTTORE primary key (IdVillaggio, IdCostruttore),
     constraint FKLAVORO_COSTRUTTORE_ID unique (LivelloMiglioramento));

create table EDIFICIO (
     IdVillaggio char(36) not null,
     Nome varchar(50) not null,
     Livello int not null,
     PuntiVita int not null,
     IdEdificio int not null,
     Tipo varchar(50) not null,
     DanniAlSecondo int,
     NumeroBersagli int,
     RaggioAzione int,
     TipoRisorsa varchar(30),
     ProduzioneOraria int,
     DescrizioneFunzione varchar(500),
     Ruolo varchar(100),
     Occupato char,
     constraint IDEDIFICIO_1 primary key (IdVillaggio, IdEdificio));

create table GIOCATORE (
     Nome varchar(50) not null,
     Cognome varchar(50) not null,
     IdGiocatore char(36) not null,
     constraint IDGIOCATORE_ID primary key (IdGiocatore));

create table GUERRA (
     IdGuerra char(36) not null,
     InCorso char not null,
     constraint IDGUERRA_ID primary key (IdGuerra));

create table MIGLIORAMENTO_EDIFICIO (
     Durata int not null,
     Costo int not null,
     LivelloMiglioramento int not null,
     PuntiEsperienzaConferiti int not null,
     IdVillaggio char(36) not null,
     IdEdificio int not null,
     constraint IDMIGLIORAMENTO_EDIFICIO_ID primary key (LivelloMiglioramento));

create table MIGLIORAMENTO_TRUPPA (
     Id char(36) not null,
     Durata int not null,
     Costo int not null,
     LivelloMiglioramento int not null,
     PuntiEsperienzaConferiti int not null,
     IdVillaggio char(36) not null,
     IdEdificio int not null,
     constraint IDMIGLIORAMENTO_TRUPPA primary key (Id, LivelloMiglioramento));

create table PARTECIPAZIONE_CLAN (
     IdClan char(36) not null,
     IdAccount char(36) not null,
     DataInizio date not null,
     DataFine date,
     Ruolo varchar(20) not null,
     constraint IDPARTECIPAZIONE_CLAN primary key (IdClan, IdAccount, DataInizio));

create table TRUPPA (
     Id char(36) not null,
     Nome varchar(50) not null,
     Livello int not null,
     PuntiVita int not null,
     DanniInflitti int not null,
     Descrizione varchar(500) not null,
     IdVillaggio char(36) not null,
     constraint IDTRUPPA primary key (Id));

create table VILLAGGIO (
     Forza float(1) not null,
     LivelloEsperienza int not null,
     NumeroTrofei int not null,
     NumeroStelleGuerra int not null,
     IdVillaggio char(36) not null,
     constraint IDVILLAGGIO_ID primary key (IdVillaggio));


-- Constraints Section
-- ___________________ 

alter table ACCOUNT add constraint FKPROPRIETA
     foreign key (IdGiocatore)
     references GIOCATORE (IdGiocatore);

alter table ACCOUNT add constraint FKAPPARTENENZA_FK
     foreign key (IdVillaggio)
     references VILLAGGIO (IdVillaggio);

alter table ACCOUNT_ATTACCANTE add constraint FKACC_ACC_ATTACKER
     foreign key (IdAccount)
     references ACCOUNT (IdAccount);

alter table ACCOUNT_ATTACCANTE add constraint FKACC_ATT_FK_ATTACKER
     foreign key (IdAttacco)
     references ATTACCO (IdAttacco);

alter table ACCOUNT_DIFENSORE add constraint FKACC_ACC_DEFENDER
     foreign key (IdAccount)
     references ACCOUNT (IdAccount);

alter table ACCOUNT_DIFENSORE add constraint FKACC_ATT_FK_DEFENDER
     foreign key (IdAttacco)
     references ATTACCO (IdAttacco);

-- Not implemented
-- alter table ATTACCO add constraint IDATTACCO_CHK
--     check(exists(select * from ACCOUNT_DIFENSORE
--                  where ACCOUNT_DIFENSORE.IdAttacco = IdAttacco)); 

-- Not implemented
-- alter table ATTACCO add constraint IDATTACCO_CHK
--     check(exists(select * from ACCOUNT_ATTACCANTE
--                  where ACCOUNT_ATTACCANTE.IdAttacco = IdAttacco)); 

alter table ATTACCO add constraint FKCOSTITUZIONE
     foreign key (IdGuerra)
     references GUERRA (IdGuerra);

-- Not implemented
-- alter table CLAN add constraint IDCLAN_CHK
--     check(exists(select * from PARTECIPAZIONE_CLAN
--                  where PARTECIPAZIONE_CLAN.IdClan = IdClan)); 

alter table COMBATTIMENTO add constraint FKCOM_CLA
     foreign key (IdClan)
     references CLAN (IdClan);

alter table COMBATTIMENTO add constraint FKCOM_GUE
     foreign key (IdGuerra)
     references GUERRA (IdGuerra);

alter table COSTRUTTORE add constraint FKLAVORO_COSTRUTTORE_FK
     foreign key (LivelloMiglioramento)
     references MIGLIORAMENTO_EDIFICIO (LivelloMiglioramento);

alter table COSTRUTTORE add constraint FKCOLLABORAZIONE
     foreign key (IdVillaggio)
     references VILLAGGIO (IdVillaggio);

alter table EDIFICIO add constraint FKCOMPOSIZIONE
     foreign key (IdVillaggio)
     references VILLAGGIO (IdVillaggio);

-- Not implemented
-- alter table GIOCATORE add constraint IDGIOCATORE_CHK
--     check(exists(select * from ACCOUNT
--                  where ACCOUNT.IdGiocatore = IdGiocatore)); 

-- Not implemented
-- alter table GUERRA add constraint IDGUERRA_CHK
--     check(exists(select * from COMBATTIMENTO
--                  where COMBATTIMENTO.IdGuerra = IdGuerra)); 

-- Not implemented
-- alter table MIGLIORAMENTO_EDIFICIO add constraint IDMIGLIORAMENTO_EDIFICIO_CHK
--     check(exists(select * from COSTRUTTORE
--                  where COSTRUTTORE.LivelloMiglioramento = LivelloMiglioramento)); 

alter table MIGLIORAMENTO_EDIFICIO add constraint FKEVOLUZIONE_EDIFICIO
     foreign key (IdVillaggio, IdEdificio)
     references EDIFICIO (IdVillaggio, IdEdificio);

alter table MIGLIORAMENTO_TRUPPA add constraint FKLAVORO_LABORATORIO
     foreign key (IdVillaggio, IdEdificio)
     references EDIFICIO (IdVillaggio, IdEdificio);

alter table MIGLIORAMENTO_TRUPPA add constraint FKEVOLUZIONE_TRUPPA
     foreign key (Id)
     references TRUPPA (Id);

alter table PARTECIPAZIONE_CLAN add constraint FKPERMANENZA
     foreign key (IdAccount)
     references ACCOUNT (IdAccount);

alter table PARTECIPAZIONE_CLAN add constraint FKACCOGLIENZA
     foreign key (IdClan)
     references CLAN (IdClan);

alter table TRUPPA add constraint FKDISPONIBILITA
     foreign key (IdVillaggio)
     references VILLAGGIO (IdVillaggio);

-- Not implemented
-- alter table VILLAGGIO add constraint IDVILLAGGIO_CHK
--     check(exists(select * from COSTRUTTORE
--                  where COSTRUTTORE.IdVillaggio = IdVillaggio)); 

-- Not implemented
-- alter table VILLAGGIO add constraint IDVILLAGGIO_CHK
--     check(exists(select * from EDIFICIO
--                  where EDIFICIO.IdVillaggio = IdVillaggio)); 

-- Not implemented
-- alter table VILLAGGIO add constraint IDVILLAGGIO_CHK
--     check(exists(select * from ACCOUNT
--                  where ACCOUNT.IdVillaggio = IdVillaggio)); 


-- Index Section
-- _____________ 

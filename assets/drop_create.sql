--
-- File generated with SQLiteStudio v3.3.2 on Mon Apr 12 13:34:15 2021
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Est_Partenaire
DROP TABLE IF EXISTS Est_Partenaire;
-- Table: Reservation
DROP TABLE IF EXISTS Reservation;
-- Table: TypeChambre
DROP TABLE IF EXISTS TypeChambre;
-- Table: Client
DROP TABLE IF EXISTS Client;
-- Table: Agence
DROP TABLE IF EXISTS Agence;
-- Table: Hotel
DROP TABLE IF EXISTS Hotel;


CREATE TABLE Agence (
    idAgence         NUMERIC        CONSTRAINT PK_AGENCE PRIMARY KEY,
    nomAgence        VARCHAR (50),
    adresse          VARCHAR (50),
    commissionAgence DECIMAL (3, 2),
    login            VARCHAR (11),
    password         VARCHAR (14) 
);

CREATE TABLE Client (
    idClient            INT          CONSTRAINT PK_CLIENT PRIMARY KEY,
    nomClient           VARCHAR (50),
    prenomClient        VARCHAR (50),
    numeroCarteBancaire VARCHAR (50),
    idAgence            NUMERIC      CONSTRAINT FK_CLIENT_AGENCE REFERENCES Agence (idAgence) 
);

CREATE TABLE Est_Partenaire (
    idHotel  NUMERIC CONSTRAINT [FK_EST_PARTENAIRE_ID-HOTEL] REFERENCES Hotel (idHotel),
    idAgence NUMERIC CONSTRAINT [FK_EST_PARTENAIRE_ID-AGENCE] REFERENCES Agence (idAgence),
    CONSTRAINT PK_EST_PARTENAIRE PRIMARY KEY (
        idHotel,
        idAgence
    )
);

CREATE TABLE Hotel (
    idHotel      NUMERIC        CONSTRAINT PK_HOTEL PRIMARY KEY,
    nomHotel     VARCHAR (50),
    adresseHotel VARCHAR (50),
    ville        VARCHAR (50),
    paysHotel    VARCHAR (50),
    nbEtoiles    INT,
    prixNuit     DECIMAL (5, 2) 
);

CREATE TABLE Reservation (
    idReservation NUMERIC        CONSTRAINT PK_RESERVATION PRIMARY KEY,
    nomClient     VARCHAR (50),
    prenomClient  VARCHAR (50),
    datedebut     VARCHAR (15),
    datefin       VARCHAR (15),
    cartecredit   VARCHAR (17),
    nbpersonne    INT,
    dureeSejour   INT,
    prixTotal     NUMERIC (5, 2),
    numChambre    NUMERIC        CONSTRAINT [FK_RESERVATION_NUM-CHAMBRE] REFERENCES TypeChambre (numChambre) 
);

CREATE TABLE TypeChambre (
    numChambre NUMERIC      CONSTRAINT PK_TYPE_CHAMBRE PRIMARY KEY,
    nbLits     INT,
    imageURL   VARCHAR (50),
    image      VARCHAR (50),
    idHotel    NUMERIC      CONSTRAINT [FK_TYPE_CHAMBRE_ID-HOTEL] REFERENCES Hotel (idHotel) 
);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
-------CREATION DE LA BASE DE DONNEE CaisseEnreigistreuse

create database CaisseEnreigistreuse;


use CaisseEnreigistreuse;


create table produit(
    code NVARCHAR(6) PRIMARY KEY NOT NULL,
    designation NVARCHAR(255) NOT NULL,
    prixAchat float NOT NULL,
    prixVente float NOT NULL
)
go


create table achat(
    id_achat int IDENTITY PRIMARY KEY NOT NULL,
    quantite int NOT NULL,
    montant float NOT NULL,
    code NVARCHAR(6) NOT NULL
    
)
go


create table caissier(
    matricule NVARCHAR(11) PRIMARY KEY NOT NULL,
    nom NVARCHAR(30) NOT NULL
)
go

create table panier(
    numero int PRIMARY KEY NOT NULL,
    date Date NOT NULL,
    solde float NOT NULL,
    id_achat int NOT NULL
   
)
go


create table ticket(
    id_ticket int PRIMARY KEY NOT NULL,
    remise float NOT NULL,
    netApayer float NOT NULL,
    numero int NOT NULL,
    matricule NVARCHAR(11)
)
go

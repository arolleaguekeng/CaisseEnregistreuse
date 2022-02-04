-------CREATION DE LA BASE DE DONNEE CaisseEnreigistreuse

create database caisseEnregistreuse;
go


use caisseEnregistreuse;
go


create table produit(
    code NVARCHAR(6) PRIMARY KEY NOT NULL,
    designation NVARCHAR(255) NOT NULL,
    prixAchat float NOT NULL,
    prixVente float NOT NULL
)
go


create table achat(
    quantite int NOT NULL,
    montant float NOT NULL,
    code NVARCHAR(6) NOT NULL,
	numero int NOT NULL
    
)
go


create table caissier(
    matricule NVARCHAR(11) PRIMARY KEY NOT NULL,
    nom NVARCHAR(30) NOT NULL
)
go

create table panier(
    numero int IDENTITY PRIMARY KEY NOT NULL,
    date Date NOT NULL,
    solde float NOT NULL
   
)
go


create table ticket(
    remise float NOT NULL,
    netApayer float NOT NULL,
    numero int NOT NULL,
    matricule NVARCHAR(11)
)
go

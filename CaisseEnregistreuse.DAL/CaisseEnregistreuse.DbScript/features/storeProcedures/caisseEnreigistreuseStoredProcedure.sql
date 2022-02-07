CREATE PROCEDURE sp_caissier_select
(
 @matricule NVARCHAR(11) = NULL,
 @nom NVARCHAR(30) = NULL 
)
AS
BEGIN
  SELECT 
  * 
 FROM 
  caissier
END
go



CREATE PROCEDURE sp_produit_select
(
 @code NVARCHAR(6) = NULL,
 @designation NVARCHAR(255) = NULL,
 @prixAchat float = NULL,
 @prixVente float = NULL
)
AS
BEGIN
  SELECT 
  * 
 FROM 
  produit
END
go


CREATE PROCEDURE sp_achat_select
(
    @quantite int = NULL,
    @montant float = NULL,
    @code NVARCHAR(6) = NULL,
    @numero int = NULL
)
AS
BEGIN
  SELECT 
  * 
 FROM 
  achat
END
go


CREATE PROCEDURE sp_panier_select
(
    @numero int = NULL,
    @date Date = NULL,
    @solde float = NULL,
    @remise float = NULL
   
)
AS
BEGIN
  SELECT 
  * 
 FROM 
  panier
END
go

CREATE PROCEDURE sp_ticket_select
(
    @remise float = NULL,
    @netApayer float = NULL,
    @matricule NVARCHAR(11) = NULL,
    @numero int = NULL
)
AS
BEGIN
  SELECT 
  * 
 FROM 
  ticket
END
go




CREATE PROCEDURE sp_achat_insert
(
    @quantite int = NULL,
    @montant float = NULL,
    @code NVARCHAR(6) = NULL,
    @numero int = NULL
)
AS
BEGIN
    INSERT INTO achat
    (
      quantite,
      montant,
      code,
      numero)
    VALUES(
      @quantite,
      @montant,
      @code,
      @numero
    )
END
go



CREATE PROCEDURE sp_panier_insert
(
 @numero NVARCHAR(6) = NULL,
 @date Date = NULL,
 @solde float = NULL,
 @remise float = NULL

)
AS
BEGIN
   INSERT INTO panier
    (
      date,
      solde,
      numero
    )
    VALUES(
      @date,
      @solde,
      numero
     
    )
END
go



CREATE PROCEDURE Sp_Tiket_Insert
(
 @remise float = NULL,
 @netApayer float = NULL,
 @numero int = NULL,
 @matricule NVARCHAR(11) = NULL

)
AS
BEGIN
   INSERT INTO Panier
    (
      remise,
      netApayer,
      matricule
    )
    VALUES(
      @remise,
      @netApayer,
      @matricule
     
    )
END
go



USE [caisseEnregistreuse]
GO
/****** Object:  StoredProcedure [dbo].[sp_get_history]    Script Date: 05/02/2022 08:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_get_history
(
	@codeProduit NVARCHAR = NULL ,
	@quantiteProduit INT = NULL ,
	@prixAchatProduit FLOAT= NULL ,
	@prixVenteProduit FLOAT= NULL ,
	@montantAchat FLOAT = NULL,
	@montantTotalAchat FLOAT = NULL,
	@benefice FLOAT = NULL ,
	@date Date =  NULL OUTPUT
)
AS
BEGIN
	SELECT DISTINCT pd.code, SUM(a.quantite) as "Quantiée Vendue", pd.prixAchat ,
	pd.prixVente, a.montant,SUM(pd.prixAchat) as "Montant achat", SUM(pd.prixVente)-SUM(pd.prixAchat) as "Bénéfice",p.date
	FROM produit pd JOIN achat a on(a.code = pd.code)
	JOIN  panier p on (a.numero = p.numero)
	WHERE p.date = '12/10/2021' 
	GROUP BY pd.code  , a.quantite,pd.prixAchat, pd.prixVente, a.montant,p.date
END














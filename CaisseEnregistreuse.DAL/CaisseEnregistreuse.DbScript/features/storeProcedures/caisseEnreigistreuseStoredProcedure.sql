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
    @solde float = NULL
   
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
 @solde float = NULL

)
AS
BEGIN
   INSERT INTO panier
    (
      numero,
      date,
      solde
    )
    VALUES(
      @numero,
      @date,
      @solde
     
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
      numero,
      matricule
    )
    VALUES(
      @remise,
      @netApayer,
      @numero,
      @matricule
     
    )
END
go














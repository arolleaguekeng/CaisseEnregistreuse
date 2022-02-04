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
    @id_achat int = NULL,
    @quantite int = NULL,
    @montant float = NULL,
    @code NVARCHAR(6) = NULL
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
    @id_achat int = NULL
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
    @id_ticket int = NULL,
    @remise float = NULL,
    @netApayer float = NULL,
    @numero int = NULL,
    @matricule NVARCHAR(11) = NULL
)
AS
BEGIN
  SELECT 
  * 
 FROM 
  ticket
END
go

























------------------caisse enregistreuse insertion------------------------




-----------------caisse enregistreuse caissier---------------------------
INSERT INTO caissier(matricule, nom) VALUES('EM201CE', 'Alexis TSOBENG');
INSERT INTO caissier(matricule, nom) VALUES('EM301CE', 'Annais VERONNE');
INSERT INTO caissier(matricule, nom) VALUES('EM401CE', 'stephane AYAN');
INSERT INTO caissier(matricule, nom) VALUES('EM501CE', 'nicola TOUKAM');
INSERT INTO caissier(matricule, nom) VALUES('EM601CE', 'elisa ANNE');



----------------caisse enregistrement produit----------------------------
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD01CE', 'sac de riz bijou 20kg', 18000, 21000);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD02CE', 'boite de cereale Nestle', 2500, 3500);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD03CE', 'boite de lait en poudre Nestle', 3000, 5000);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD04CE', 'boite de cafe UCAO 500g', 10000, 13500);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD05CE', 'boite de chocalate tartina 500g', 2500, 5000);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD06CE', 'boite de chocalate bambibo 500g', 2000, 4000);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD07CE', 'tablette de chocolate mambo 15g', 800, 1000);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD08CE', 'tablette de chocolat blanc 15g', 1050, 2000);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD09CE', 'palette de 36 oeufs', 800, 1800);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD10CE', 'boite de lait non sucre (pink)', 200, 500);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD11CE', 'sac de farine bijou 10kg', 12500, 16000);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD12CE', 'bouteille d''huile d''arachide', 800, 1400);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD13CE', 'paquet de sucre tantie', 500, 800);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD14CE', 'boite de sardine marocaine', 300, 500);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD15CE', 'boite de mayonnaise calve', 1000, 1500);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD16CE', 'sachet levure chimique de farine', 50, 150);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD17CE', 'savon azur', 200, 350);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD18CE', 'sachet de detergent Ozil 15g', 50, 100);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD19CE', 'sachet sucre en poudre 300g', 500, 1000);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD20CE', 'bidon eau de javel la (croix)', 1500, 2500);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD21CE', 'savon de toillete sanet', 800, 1500);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD22CE', 'lait de toilette (white express)', 2500, 3500);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD23CE', 'gamme de toilette (moby bebe)', 7500, 11000);
INSERT INTO produit(code, designation, prixAchat, prixVente) VALUES('PD24CE', 'pot de miel pure 500g', 3500, 5000);


------------------caisse enregistreuse achat---------------------------------
INSERT INTO achat(quantite, montant, code) VALUES(2, 42000, 'PD01CE', 1)
INSERT INTO achat(quantite, montant, code) VALUES(5, 19500, 'PD02CE', 1)
INSERT INTO achat(quantite, montant, code) VALUES(3, 15000, 'PD03CE', 1)
INSERT INTO achat(quantite, montant, code) VALUES(1, 13500, 'PD04CE', 2)
INSERT INTO achat(quantite, montant, code) VALUES(3, 15000, 'PD05CE', 2)
INSERT INTO achat(quantite, montant, code) VALUES(1, 4000, 'PD06CE', 2)
INSERT INTO achat(quantite, montant, code) VALUES(2, 2000, 'PD07CE', 3)
INSERT INTO achat(quantite, montant, code) VALUES(1, 2000, 'PD08CE', 3)
INSERT INTO achat(quantite, montant, code) VALUES(2, 3600, 'PD09CE', 1)
INSERT INTO achat(quantite, montant, code) VALUES(1, 13500, 'PD04CE', 4)
INSERT INTO achat(quantite, montant, code) VALUES(3, 3000, 'PD05CE', 4)
INSERT INTO achat(quantite, montant, code) VALUES(1, 2000, 'PD06CE', 4)



--------------------caise enregistreuse panier------------------------------ 
INSERT INTO panier(numero, date, solde) VALUES (1, '12/10/2021', 80100);
INSERT INTO panier(numero, date, solde) VALUES (2, '12/10/2021', 32500);
INSERT INTO panier(numero, date, solde) VALUES (3, '12/10/2021', 4000);
INSERT INTO panier(numero, date, solde) VALUES (4, '12/10/2021', 18500);




--------------------------panier vide-----------------------------------

INSERT INTO panier(numero, date, solde) VALUES (5, '12/10/2021');
INSERT INTO panier(numero, date, solde) VALUES (6, '12/10/2021');
INSERT INTO panier(numero, date, solde) VALUES (7, '12/10/2021');

SELECT DISTINCT pd.code, pd.designation, 
    pd.prixAchat*(SELECT SUM(quantite) FROM achat 
                                    WHERE code = pd.code
                                    AND numero = p.numero) AS prixAchat,
    pd.prixVente*(SELECT SUM(quantite) FROM achat 
                                    WHERE code = pd.code
                                    AND numero = p.numero) AS prixVente,
    (SELECT SUM(quantite) FROM achat 
                        WHERE code = pd.code
                        AND numero = p.numero)*(pd.prixVente - pd.prixAchat) AS benefice
FROM panier p
LEFT OUTER JOIN achat a ON a.numero = p.numero
LEFT OUTER JOIN produit pd ON pd.code = a.code
WHERE p.date = '12/10/2021';

string query = $"SELECT DISTINCT pd.code, pd.designation, pd.prixAchat * (SELECT SUM(quantite) FROM achat WHERE code = pd.code AND numero = p.numero) AS prixAchat, pd.prixVente * (SELECT SUM(quantite) FROM achat WHERE code = pd.code AND numero = p.numero) AS prixVente, (SELECT SUM(quantite) FROM achat WHERE code = pd.code AND numero = p.numero)*(pd.prixVente - pd.prixAchat) AS benefice FROM panier p LEFT OUTER JOIN achat a ON a.numero = p.numero LEFT OUTER JOIN produit pd ON pd.code = a.code WHERE p.date = '12/10/2021' ";
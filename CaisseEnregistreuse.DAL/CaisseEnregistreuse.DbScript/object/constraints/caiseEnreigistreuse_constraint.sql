

-----------------------contrainte de la bd caisse enreigistreuse


use CaisseEnreigistreuse;
ALTER table achat
ADD constraint fk_code
foreign key (code) references produit (code)
go

ALTER table achat
ADD constraint fk_numero
foreign key (numero) references panier (numero)
go



ALTER table ticket
ADD constraint fk_numero
foreign key (numero) references panier (numero)
go



ALTER table ticket
ADD constraint fk_matricule
foreign key (matricule) references caissier (matricule)
go
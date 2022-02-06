
using System.Collections.Generic;

namespace CaisseEnregistreuse.BO
{
    public class Achat
    {

        public Produit _Produit { get; set; }
        public int Quantite { get; set; }
        public double Montant { get; set; }
        public int NumeroPanier { get; set; }

        public Achat()
        {

        }

        public Achat(Produit produit, int quantite)
        {
            _Produit = produit;
            Quantite = quantite;
            Montant = quantite * produit.PrixAchat;
            //NumeroPanier = Panier.Numero;
        }
        public Achat(Produit produit, int quantite, int numeroPanier):this(produit, quantite)
        {
            NumeroPanier = numeroPanier;
        }

        public override bool Equals(object obj)
        {
            return obj is Achat achat &&
                   EqualityComparer<Produit>.Default.Equals(_Produit, achat._Produit) &&
                   NumeroPanier == achat.NumeroPanier;
        }

        public override int GetHashCode()
        {
            int hashCode = 968850227;
            hashCode = hashCode * -1521134295 + EqualityComparer<Produit>.Default.GetHashCode(_Produit);
            hashCode = hashCode * -1521134295 + NumeroPanier.GetHashCode();
            return hashCode;
        }
    }
}

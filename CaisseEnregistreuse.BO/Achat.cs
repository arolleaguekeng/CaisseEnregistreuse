
using System.Collections.Generic;

namespace CaisseEnregistreuse.BO
{
    public class Achat
    {

        public Produit _Produit { get; set; }
        public int Quantite { get; set; }
        public double Montant { get; set; }
        public int Numero { get; set; }

        public Achat()
        {
            _Produit = new Produit();
        }

        public Achat(Produit produit, int quantite, double montant)
        {
            _Produit = produit;
            Quantite = quantite;
            Montant = montant;
            
        }

        public Achat(Produit produit, int quantite, int numeroPanier, double montant) 
        {
            _Produit = produit;
            Quantite = quantite;
            Numero = numeroPanier;
            Montant = montant;
        }

        public override bool Equals(object obj)
        {
            return obj is Achat achat &&
                   EqualityComparer<Produit>.Default.Equals(_Produit, achat._Produit) &&
                   Numero == achat.Numero;
        }

        public override int GetHashCode()
        {
            int hashCode = 968850227;
            hashCode = hashCode * -1521134295 + EqualityComparer<Produit>.Default.GetHashCode(_Produit);
            hashCode = hashCode * -1521134295 + Numero.GetHashCode();
            return hashCode;
        }
    }
}

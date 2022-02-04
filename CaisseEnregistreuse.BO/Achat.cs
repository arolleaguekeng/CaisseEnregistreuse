
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
            NumeroPanier = Panier.Numero;
        }
        public Achat(Produit produit, int quantite, int numeroPanier):this(produit, quantite)
        {
            NumeroPanier = numeroPanier;
        }
    }
}

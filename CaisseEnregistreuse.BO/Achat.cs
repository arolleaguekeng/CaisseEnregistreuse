
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

        public Achat(Produit produit, int quantite, double montant)
        {
            _Produit = produit;
            Quantite = quantite;
            Montant = montant;
            NumeroPanier = Panier.Numero;
        }
        public Achat(Produit produit, int quantite, double montant, int numeroPanier):this(produit, quantite, montant)
        {
            NumeroPanier = numeroPanier;
        }
    }
}

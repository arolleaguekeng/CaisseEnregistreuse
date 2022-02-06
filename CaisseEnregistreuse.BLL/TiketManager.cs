using CaisseEnregistreuse.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.BLL
{
    public class TiketManager
    {
        Panier panier;
        PanierManager manager;
        public TiketManager()
        {
            panier = new Panier();
            manager = new PanierManager();
        }
        public double CalculNetApayer(Panier panier ,string typeRemise, double remise,Tiket tiket)
        {
            if(typeRemise=="p")
            {
               tiket.NetAPayer = manager.CalculSolde(panier) - (manager.CalculSolde(panier) * remise) / 100; 
            }
            if(typeRemise.ToLower()=="n")
            { 
               tiket.NetAPayer =  manager.CalculSolde(panier) - remise;
            }
            return panier.Solde - remise;
        }

        public double CalculNetApayer(Panier panier)
        {
            return manager.CalculSolde(panier);
        }
        public void AfficherTiket(Panier panier)
        {
            Console.WriteLine("+".PadRight(100, '-') + "+");
            string column = "".PadRight(100, ' ') + "Tiket".PadRight(100, ' ') + "|";
            Console.WriteLine(column);
            Console.WriteLine("+".PadRight(100, '-') + "+");
            foreach (var achat in panier.Achats)
            {
                Console.WriteLine("|".PadRight(100, '-') + "|");
                Console.WriteLine("|".PadRight(10, ' ') + achat._Produit.Code + " ".PadRight(10, ' ') + achat._Produit.PrixVente);
            }


        }
    }
}

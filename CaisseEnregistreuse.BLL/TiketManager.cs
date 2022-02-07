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
        public void AfficherTiket(Panier panier, string[,] tab)
        {
            Console.WriteLine("+".PadRight(100, '-') + "+");
            string column = "".PadRight(50, ' ') + "Tiket".PadRight(50, ' ') + "|";
            Console.WriteLine(column);
            Console.WriteLine("+".PadRight(100, '-') + "+");
            string[,] produits = new string[panier.Achats.Count,4];
           


            
        }
    }
}

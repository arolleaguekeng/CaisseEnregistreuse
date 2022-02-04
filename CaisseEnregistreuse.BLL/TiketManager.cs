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
            Console.WriteLine("+-----------------------------------------------------------+");
            Console.WriteLine("Tiket");
            Console.WriteLine($"|{reader["name"].ToString().PadRight(50, ' ')}"

            Console.WriteLine("+-----------------------------------------------------------+");
            
        }
    }
}

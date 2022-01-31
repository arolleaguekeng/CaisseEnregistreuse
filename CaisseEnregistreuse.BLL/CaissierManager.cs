using CaisseEnregistreuse.BO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.BLL
{
    public class CaissierManager
    {
        public string Commande;
        Panier panier;
        public CaissierManager()
        {
            panier = new Panier();
            Commande = $"print {panier.Numero}.pdf";
        }



        public void ImprimerTiket(string nomImprimente)
        {
            Process.Start("cmd.exe", Commande);
        }
    }
}

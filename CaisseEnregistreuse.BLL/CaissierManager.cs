using CaisseEnregistreuse.BO;
using CaisseEnregistreuse.DAL;
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
        CaissierDAO caissierDAO;
        public CaissierManager()
        {
           
            Commande = $"print {Panier.Numero}.pdf";
            caissierDAO = new CaissierDAO();
        }



        public void ImprimerTiket(string nomImprimente)
        {
            Process.Start("cmd.exe", Commande);
        }

        public Caissier getCaissier(Caissier caissier)
        {
            return caissierDAO.GetCaissier(caissier);
        }

       
    }
}

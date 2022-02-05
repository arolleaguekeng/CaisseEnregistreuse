using CaisseEnregistreuse.BO;
using CaisseEnregistreuse.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.BLL
{
    public class Historique_manager
    {
        private PanierManager manager;
        private AchatManager achatManager;
        public Historique_manager()
        {
            manager = new PanierManager();
            achatManager = new AchatManager();
        }
        public List<Historique> GetHistorique(DateTime date)
        {
            double montantTotalAchat = 0;
            List<Historique> historiques = new List<Historique>();
            var panier = manager.Get(new Panier { Date = date});
            Historique historique = new Historique(); 
            historique.Date = panier.Date;
            foreach (var achat in panier.Achats)
            {
                historique.CodeProduit = achat._Produit.Code;
                historique.QuantiteProduit = achat.Quantite;
                historique.PrixAchatProduit = achat._Produit.PrixAchat;
                historique.PrixVenteProduit = achat._Produit.PrixVente;
                historique.Benefice = achat._Produit.PrixVente - achat._Produit.PrixAchat;
                historique.MontantAchat = achat.Montant;
                foreach (var produit in panier.Achats)
                {
                    montantTotalAchat += produit.Montant;
                }
                historique.MontantTotalAchat = montantTotalAchat;

                historiques.Add(historique);

            }
            historique.Date = panier.Date;
            return historiques;
        }
    }
}

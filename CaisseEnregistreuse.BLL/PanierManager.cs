
using CaisseEnregistreuse.BO;
using CaisseEnregistreuse.DAL;
using System.Collections.Generic;
using System.Linq;

namespace CaisseEnregistreuse.BLL
{
    public class PanierManager
    {
        private PanierDAO panierDAO;
        

        public PanierManager()
        {
            panierDAO = new PanierDAO();
        }

        public Panier Add(Panier panier)
        {
            return panierDAO.Add(panier);
        }

        public Panier Get(Panier panier)
        {
            return panierDAO.Get(panier);
        }

        public List<Panier> Find(Panier p)
        {
            return panierDAO.Find(p).ToList();
        }
        public double CalculSolde(Panier panier)
        {
            double solde = 0;
            foreach(var achat in panier.Achats )
            {
                solde += achat.Montant;
            }
            return solde;
        }
       
    }
}

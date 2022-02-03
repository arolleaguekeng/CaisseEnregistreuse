
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
    }
}

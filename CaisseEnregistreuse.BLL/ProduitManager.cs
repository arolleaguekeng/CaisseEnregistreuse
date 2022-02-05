

using CaisseEnregistreuse.BO;
using CaisseEnregistreuse.DAL;
using System.Collections.Generic;

namespace CaisseEnregistreuse.BLL
{
    public class ProduitManager
    {

        private ProduitDAO produitDAO;

        public ProduitManager()
        {
            produitDAO = new ProduitDAO();
        }

        public Produit Get(Produit produit)
        {
            return produitDAO.Get(produit);
        }

        public List<Produit> GetAll(Produit produit)
        {
            return (List<Produit>)produitDAO.GetAll(produit);
        }


    }
}



using CaisseEnregistreuse.BO;
using CaisseEnregistreuse.DAL;

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
    }
}

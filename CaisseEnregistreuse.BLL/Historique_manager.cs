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
        private HistoriqueDAO historiqueDAO;
        public Historique_manager()
        {
            historiqueDAO = new HistoriqueDAO();
        }
        public List<Historique> GetHistorique()
        {
            return historiqueDAO.Get().ToList();
        }
    }
}

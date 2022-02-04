using CaisseEnregistreuse.BO;
using CaisseEnregistreuse.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.BLL
{
    public class AchatManager
    {

        private AchatDAO achatDAO;

        public AchatManager()
        {
            achatDAO = new AchatDAO();
        }

        public Achat Get(Achat achat)
        {
            return achatDAO.Get(achat);
        }

        public List<Achat> Find(Achat p)
        {
            return achatDAO.Find(p).ToList();
        }
    }
}

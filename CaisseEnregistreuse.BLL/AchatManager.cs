using CaisseEnregistreuse.BO;
using CaisseEnregistreuse.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaisseEnregistreuse.BLL
{
    public class AchatManager
    {
         private AchatDAO achatDAO;

        public AchatManager()
        {
            achatDAO = new AchatDAO();
        }

        public Achat Add(Achat Achat)
        {
            return achatDAO.Add(Achat);
        }

        public Achat Get(Achat Achat)
        {
            return achatDAO.Get(Achat);
        }

        public List<Achat> Find(Achat p)
        {
            return achatDAO.Find(p).ToList();
        }

    }
}

using CaisseEnregistreuse.BO;
using CaisseEnregistreuse.common;
using Junior.DAL;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.DAL
{
    public class CaissierDAO
    {

        private Sql sql;
        public CaissierDAO()
        {
            sql = new Sql("SqlServer");
        }

        public Caissier Get(Caissier caissier)
        {
            var datareader = sql.Read("sp_caissier_select", GetParameter(caissier), true);
            return GetCaissier(datareader);
        }

        private Caissier GetCaissier(DbDataReader datareader)
        {
 
            Caissier caissier = new Caissier(
                "kjlml", "kmlkjmj"
                );
            return caissier;
        }
        private IEnumerable<Sql.Parameter> GetParameter(Caissier caissier)
        {
            return new Sql.Parameter[]
            {
                new Sql.Parameter("@matricule", System.Data.DbType.String, (object)caissier.Matricule??DBNull.Value),
                new Sql.Parameter("@nom", System.Data.DbType.DateTime, (object)caissier.Nom??DBNull.Value)
            };
        }

        
    }
}

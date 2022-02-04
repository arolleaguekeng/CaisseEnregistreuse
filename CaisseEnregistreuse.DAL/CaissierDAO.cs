using CaisseEnregistreuse.BO;
using Junior.DAL;
using System;
using System.Collections.Generic;
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



        public Caissier Add(Caissier caissier)
        {
            var output = sql.Execute(" ", GetParameter(caissier), true);
            return caissier;
        }

        public Caissier GetCaissier(Caissier caissier)
        {
            var datareader = sql.Read("sp_caissier_select", GetParameter(caissier), true);
            return Get(datareader);
        }

        private Caissier Get(System.Data.Common.DbDataReader datareader)
        {
            
            Caissier caissier = new Caissier(
                datareader["matricule"].ToString(),
                datareader["nom"].ToString()
                );
            return caissier;
        }
        private IEnumerable<Sql.Parameter> GetParameter(Caissier caissier)
        {
            return new Sql.Parameter[]
            {
                new Sql.Parameter("matricule", System.Data.DbType.String, (object)caissier.Matricule??DBNull.Value, System.Data.ParameterDirection.Output),
                new Sql.Parameter("nom", System.Data.DbType.DateTime, (object)caissier.Nom??DBNull.Value)
            };
        }

        
    }
}

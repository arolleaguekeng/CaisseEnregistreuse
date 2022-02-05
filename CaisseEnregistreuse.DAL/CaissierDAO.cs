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
            return sql.Read<Caissier>
                (
                "sp_caissier_select", GetParameter(caissier), GetCaissier, true
                )?.FirstOrDefault();

           
        }

        private Caissier GetCaissier(DbDataReader datareader)
        {

            return  new Caissier(
                datareader["matricule"].ToString(),
                datareader["nom"].ToString()
                ) ;
           
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

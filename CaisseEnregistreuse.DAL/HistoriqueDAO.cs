using CaisseEnregistreuse.BO;
using Junior.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.DAL
{
    public class HistoriqueDAO
    {
        Sql sql;
        public HistoriqueDAO()
        {
            sql = new Sql("SqlServer");
        }

        public IEnumerable<Historique> Get()
        {
            return sql.Read<Historique>("sp_get_history", null, GetHistorique, true);
        }

        private Historique GetHistorique(System.Data.Common.DbDataReader datareader)
        {
            return( new Historique
            (
                datareader["codeProduit"] != DBNull.Value ? datareader["codeProduit"].ToString() : default,
                int.Parse(datareader["quantiteProduit"] != DBNull.Value ? datareader["quantiteProduit"].ToString() : default,
                double.Parse(datareader["prixAchatProduit"] != DBNull.Value ? datareader["prixAchatProduit"].ToString() : default ,
                double.Parse(datareader["prixVenteProduit"] != DBNull.Value ? datareader["prixVenteProduit"].ToString() : default ,
                int.Parse(datareader["benefice"] != DBNull.Value ? datareader["benefice"].ToString() :default,
                DateTime.Parse(datareader["date"]).ToString()
            );
            
        }




        private IEnumerable<Sql.Parameter> GetParmeter(Historique historique)
        {
            return new Sql.Parameter[]
            {
                new Sql.Parameter("codeProduit", System.Data.DbType.String, (object)historique.CodeProduit??DBNull.Value  , System.Data.ParameterDirection.Output),
                new Sql.Parameter("quantiteProduit", System.Data.DbType.Int64, historique.QuantiteProduit == 0?DBNull.Value:(object)historique.QuantiteProduit  , System.Data.ParameterDirection.Output),
                new Sql.Parameter("prixAchatProduit", System.Data.DbType.Double,historique.PrixAchatProduit == 0?DBNull.Value:(object)historique.PrixAchatProduit  , System.Data.ParameterDirection.Output),
                new Sql.Parameter("prixVenteProduit", System.Data.DbType.Double,historique.PrixVenteProduit == 0?DBNull.Value:(object)historique.PrixVenteProduit  , System.Data.ParameterDirection.Output),
                new Sql.Parameter("benefice", System.Data.DbType.Double,historique.Benefice == 0?DBNull.Value:(object)historique.Benefice  , System.Data.ParameterDirection.Output),
                new Sql.Parameter("date", System.Data.DbType.Date,historique.Date == null?DBNull.Value:(object)historique.Date  , System.Data.ParameterDirection.Output)
            };
        }

    }
}

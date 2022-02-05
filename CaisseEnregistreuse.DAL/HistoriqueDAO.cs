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

        public IEnumerable<Historique> Get(Historique historique)
        {
            return sql.Read<Historique>("sp_get_history", null, GetHistorique, true);
        }

        private Historique GetHistorique(System.Data.Common.DbDataReader datareader)
        {
            return (new Historique
            (
                datareader["codeProduit"].ToString(),
                int.Parse(datareader["quantiteProduit"].ToString()),
                double.Parse(datareader["prixAchatProduit"].ToString()),
                double.Parse(datareader["prixVenteProduit"].ToString()),
                double.Parse(datareader["montantAchat"].ToString()),
                double.Parse(datareader["montantTotalAchat"].ToString()),
                int.Parse(datareader["benefice"].ToString()),
                DateTime.Parse(datareader["date"].ToString()))
            );
            
        }




        private IEnumerable<Sql.Parameter> GetParmeter(Historique historique)
        {
            return new Sql.Parameter[]
            {
                new Sql.Parameter("codeProduit", System.Data.DbType.String, (object)historique.CodeProduit??DBNull.Value ),
                new Sql.Parameter("quantiteProduit", System.Data.DbType.Int64, historique.QuantiteProduit == 0?DBNull.Value:(object)historique.QuantiteProduit ),
                new Sql.Parameter("prixAchatProduit", System.Data.DbType.Double,historique.PrixAchatProduit == 0?DBNull.Value:(object)historique.PrixAchatProduit ),
                new Sql.Parameter("prixVenteProduit", System.Data.DbType.Double,historique.PrixVenteProduit == 0?DBNull.Value:(object)historique.PrixVenteProduit ),
                new Sql.Parameter("montantAchat", System.Data.DbType.Double,historique.MontantAchat == 0?DBNull.Value:(object)historique.PrixVenteProduit ),
                new Sql.Parameter("montantTotalAchat", System.Data.DbType.Double,historique.MontantTotalAchat == 0?DBNull.Value:(object)historique.PrixVenteProduit ),
                new Sql.Parameter("benefice", System.Data.DbType.Double,historique.Benefice == 0?DBNull.Value:(object)historique.Benefice),
                new Sql.Parameter("date", System.Data.DbType.Date,historique.Date == null?DBNull.Value:(object)historique.Date  , System.Data.ParameterDirection.Output)
            };
        }

    }
}

using CaisseEnregistreuse.BO;
using Junior.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.DAL
{
    public class HistoriqueDAO : Sql
    {
        public HistoriqueDAO() :base("SqlServer")
        {
            
        }

        public IEnumerable<Historique> Get(Historique historique , string date)
        {
            string query = "SELECT DISTINCT pd.code, pd.designation, " +
                "(SELECT SUM(quantite) FROM achat " +
                                    "WHERE code = pd.code " +
                                    "AND numero IN(SELECT numero FROM panier WHERE[date] = p.date)) AS quantiteProduit, " +
                "pd.prixAchat, pd.prixVente, " +
                "pd.prixVente * (SELECT SUM(quantite) FROM achat " +
                                                "WHERE code = pd.code " +
                                                "AND numero IN(SELECT numero FROM panier WHERE[date] = p.date)) AS montant, " +
                "pd.prixAchat * (SELECT SUM(quantite) FROM achat " +
                                                "WHERE code = pd.code " +
                                                "AND numero IN(SELECT numero FROM panier WHERE[date] = p.date)) AS montantTotalAchat, " +
                "(SELECT SUM(quantite) FROM achat " +
                                  "WHERE code = pd.code " +
                                  "AND numero IN(SELECT numero FROM panier WHERE[date] = p.date))*(pd.prixVente - pd.prixAchat) AS benefice, " +
                "p.date " +
                "FROM produit pd " +
                "LEFT OUTER JOIN achat a ON a.code = pd.code " +
                "LEFT OUTER JOIN panier p ON p.numero = a.numero " +
                $"WHERE p.date = '{date}' ";
            return Read<Historique>(query, GetParameter(historique), GetHistorique, false);
        }


        private Historique GetHistorique(System.Data.Common.DbDataReader datareader) {

            return new Historique(
                datareader["code"].ToString(),
                int.Parse(datareader["quantiteProduit"].ToString()),
                double.Parse(datareader["prixAchat"].ToString()),
                double.Parse(datareader["prixVente"].ToString()),
                double.Parse(datareader["montant"].ToString()),
                double.Parse(datareader["montantTotalAchat"].ToString()),
                int.Parse(datareader["benefice"].ToString()),
                datareader["date"].ToString(),
                datareader["designation"].ToString()) ;
        }

        private IEnumerable<Parameter> GetParameter(Historique historique)
        {
            return new Parameter[]
            {
                new Parameter("quantiteProduit", System.Data.DbType.Int64, historique.QuantiteProduit == 0?DBNull.Value:(object)historique.QuantiteProduit ),
                new Parameter("prixAchatProduit", System.Data.DbType.Double,historique.PrixAchatProduit == 0?DBNull.Value:(object)historique.PrixAchatProduit ),
                new Parameter("prixVenteProduit", System.Data.DbType.Double,historique.PrixVenteProduit == 0?DBNull.Value:(object)historique.PrixVenteProduit ),
                new Parameter("montantAchat", System.Data.DbType.Double,historique.MontantAchat == 0?DBNull.Value:(object)historique.PrixVenteProduit ),
                new Parameter("montantTotalAchat", System.Data.DbType.Double,historique.MontantVente == 0?DBNull.Value:(object)historique.PrixVenteProduit ),
                new Parameter("benefice", System.Data.DbType.Double,historique.Benefice == 0?DBNull.Value:(object)historique.Benefice),
                new Parameter("date", System.Data.DbType.String,historique.Date == null?DBNull.Value:(object)historique.Date  , System.Data.ParameterDirection.Output),
                new Parameter("designation", System.Data.DbType.String,historique.Designation == null?DBNull.Value:(object)historique.Designation)

            };
        }
    }
}


using CaisseEnregistreuse.BO;
using Junior.DAL;
using System;
using System.Collections.Generic;

namespace CaisseEnregistreuse.DAL
{
    public class ProduitDAO
    {
        private Sql sql;
        public ProduitDAO()
        {
            sql = new Sql("SqlServer");
        }

        public Produit Get(Produit p)
        {
            var dataReader = sql.Read("sp_produit_select", GetParameter(p), true);
            return GetProduit(dataReader);
        }

        private Produit GetProduit(System.Data.Common.DbDataReader dataReader)
        {
            return new Produit
            (
                dataReader["code"].ToString(),
                dataReader["designation"].ToString(),
                double.Parse(dataReader["prixAchat"].ToString()),
                double.Parse(dataReader["prixVente"].ToString())
            );
        }

        private IEnumerable<Sql.Parameter> GetParameter(Produit p)
        {
            return new Sql.Parameter[]
            {
                new Sql.Parameter("code", System.Data.DbType.String, (object)p.Code??DBNull.Value, System.Data.ParameterDirection.Output),
                new Sql.Parameter("designation", System.Data.DbType.String, (object)p.Designation ?? DBNull.Value),
                new Sql.Parameter("prixAchat", System.Data.DbType.Double, p.PrixAchat == 0?DBNull.Value:(object)p.PrixAchat),
                new Sql.Parameter("prixVente", System.Data.DbType.Double, p.PrixVente == 0?DBNull.Value:(object)p.PrixVente)

            };
        }
    }
}

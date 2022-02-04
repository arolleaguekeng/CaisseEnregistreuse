using CaisseEnregistreuse.BO;
using CaisseEnregistreuse.common;
using Junior.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaisseEnregistreuse.DAL
{
    public class AchatDAO : IRepository<Achat>
    {
        private Sql sql;
        public AchatDAO()
        {
            sql = new Sql("SqlServer");
        }

        public Achat Add(Achat achat)
        {
            var output = sql.Execute("sp_achat_insert", GetParmeter(achat), true);
            return achat;
        }

        public Achat Get(Achat achat)
        {
            return sql.Read<Achat>("sp_achat_select", GetParmeter(achat), GetAchat, true)?.FirstOrDefault();
            
        }

        private Achat GetAchat(System.Data.Common.DbDataReader datareader)
        {
            var produit = new ProduitDAO();
            return new Achat
            (
                produit.Get(new Produit { Code = datareader["code"].ToString()}),
                int.Parse(datareader["quantite"].ToString()),
                int.Parse(datareader["numeroPanier"].ToString())
            ) ;
        }

        public IEnumerable<Achat> Find(Achat achat)
        {
            return sql.Read<Achat>("sp_achat_select", GetParmeter(achat), GetAchat, true);
        }

        private IEnumerable<Sql.Parameter> GetParmeter(Achat achat)
        {
            return new Sql.Parameter[]
            {
                new Sql.Parameter("code", System.Data.DbType.String, (object)achat._Produit.Code??DBNull.Value, System.Data.ParameterDirection.Output),
                new Sql.Parameter("quantite", System.Data.DbType.Int64, achat.Quantite == 0?DBNull.Value:(object)achat.Quantite),
                new Sql.Parameter("montant", System.Data.DbType.Double, achat.Montant == 0?DBNull.Value:(object)achat.Montant),
                new Sql.Parameter("numero", System.Data.DbType.Int64, achat.NumeroPanier == 0?DBNull.Value:(object)achat.NumeroPanier)

            };
        }
    }
}

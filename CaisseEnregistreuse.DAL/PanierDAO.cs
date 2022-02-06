
using CaisseEnregistreuse.BO;
using CaisseEnregistreuse.common;
using Junior.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaisseEnregistreuse.DAL
{
    public class PanierDAO : IRepository<Panier>
    {
        private Sql sql;
        public PanierDAO()
        {
            sql = new Sql("SqlServer");
        }

        public Panier Add(Panier panier)
        {
            Dictionary<string, string> outPuts = new Dictionary<string, string>();
            outPuts.Add("numero", sql.Execute(" ", GetParameter(panier), true).ToString());
            panier.Numero = int.Parse(outPuts["numero"]);
            return panier;
        }
        public Panier Get(Panier panier)
        {
            return sql.Read<Panier>("sp_panier_select", GetParameter(panier), GetPanier, true)?.FirstOrDefault();
        }
        public IEnumerable<Panier> GetAll()
        {
            return sql.Read<Panier>("sp_panier_select", null, GetPanier, true);
        }
        public IEnumerable<Panier> GetAllWhitDate()
        {
            return sql.Read<Panier>("sp_panier_select_withdate", null, GetPanierdate, true);
        }
        private Panier GetPanier(System.Data.Common.DbDataReader datareader)
        {
            var achat = new AchatDAO();
            var Panier = new Panier(
                DateTime.Parse(datareader["date"].ToString()),
                achat.Find(new Achat { NumeroPanier = int.Parse(datareader["numero"].ToString()) }).ToList()
                );
            return Panier;
        }


        private Panier GetPanierdate(System.Data.Common.DbDataReader datareader)
        {
            var achat = new AchatDAO();
            var Panier = new Panier(
                DateTime.Parse(datareader["date"].ToString()),
                achat.Find(new Achat { NumeroPanier = int.Parse(datareader["numero"].ToString()) }).ToList()
                );
            return Panier;
        }


        public IEnumerable<Panier> Find(Panier p)
        {
            return sql.Read<Panier>("sp_panier_select", GetParameter(p), GetPanier, true);
        }
        private IEnumerable<Sql.Parameter> GetParameter(Panier panier)
        {
            return new Sql.Parameter[]
            {
                new Sql.Parameter("numero", System.Data.DbType.Int64, panier.Numero == 0? DBNull.Value:(object)panier.Numero, System.Data.ParameterDirection.Output),
                new Sql.Parameter("date", System.Data.DbType.DateTime, panier.Date == DateTime.MinValue? DBNull.Value:(object)panier.Date),
                new Sql.Parameter("solde", System.Data.DbType.Double, panier.Solde == 0? DBNull.Value:(object)panier.Solde)
            };
        }
    }
}

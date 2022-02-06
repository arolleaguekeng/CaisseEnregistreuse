using System;
using System.Collections.Generic;

namespace CaisseEnregistreuse.BO
{
    public class Panier
    {
        public int Numero { get; set; }
        public DateTime Date { get; set; }
        public List<Achat> Achats { get; set; }
        public double Solde { get; set; }
        public Panier()
        {
            Achats = new List<Achat>();
        }

        public Panier(DateTime date, List<Achat> achats)
        {
            Date = date;
            Achats = achats;
            Solde = 0;
            Achats = new List<Achat>();
        }

        public Panier(DateTime date, List<Achat> achats, double solde)
        {
            Numero++;
            Date = date;
            Achats = achats;
            Solde = solde;
            Achats = new List<Achat>();
        }




        public override bool Equals(object obj)
        {
            return obj is Panier panier &&
                   Date == panier.Date;
        }

        public override int GetHashCode()
        {
            return 884517729 + Date.GetHashCode();
        }
    }
}

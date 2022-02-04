using System;
using System.Collections.Generic;

namespace CaisseEnregistreuse.BO
{
    public class Panier
    {
        public  static int Numero { get; set; }
        public DateTime Date { get; set; }
        public List<Achat> Achats { get; set; }
        public double Solde { get; set; }
        public Panier()
        {
            Achats = new List<Achat>();
            Numero++;
        }

        public Panier(DateTime date, List<Achat> achats)
        {
            Numero ++;
            Date = date;
            Achats = achats;
            Solde = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.BO
{
    public class Panier
    {
        public static int Numero { get; set; }
        public DateTime Date { get; set; }
        public List<Achat> Achats { get; set; }
        public double Solde { get; set; }
        public Panier()
        {
            Achats = new List<Achat>();
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

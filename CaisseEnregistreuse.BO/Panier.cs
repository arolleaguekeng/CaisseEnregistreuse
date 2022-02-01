using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Panier(int numero, DateTime date, List<Achat> achats, double solde)
        {
            Numero = numero;
            Date = date;
            Achats = achats;
            Solde = solde;
        }
    }
}

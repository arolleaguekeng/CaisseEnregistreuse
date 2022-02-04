using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.BO
{
    public class Tiket
    {
        public Panier _Panier { get; set; }
        public double Remise { get; set; }
        public double NetAPayer { get; set; }
        public Caissier _Caissier { get; set; }
        
        public Tiket()
        {
            _Panier = new Panier();
            _Caissier = new Caissier();
        }

        public Tiket(Panier panier, double remise, double netAPayer, Caissier caissier)
        {
            _Panier = panier;
            Remise = remise;
            NetAPayer = netAPayer;
            _Caissier = caissier;
        }
    }
}

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
        public float Remise { get; set; }
        public double NetAPayer { get; set; }
        public Caissier _Caissier { get; set; }
        public Tiket()
        {

        }

        public Tiket(Panier panier, float remise, double netAPayer, Caissier caissier)
        {
            _Panier = panier;
            Remise = remise;
            NetAPayer = netAPayer;
            _Caissier = caissier;
        }
    }
}

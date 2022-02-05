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

        public override bool Equals(object obj)
        {
            return obj is Tiket tiket &&
                   EqualityComparer<Panier>.Default.Equals(_Panier, tiket._Panier) &&
                   EqualityComparer<Caissier>.Default.Equals(_Caissier, tiket._Caissier);
        }

        public override int GetHashCode()
        {
            int hashCode = -792801848;
            hashCode = hashCode * -1521134295 + EqualityComparer<Panier>.Default.GetHashCode(_Panier);
            hashCode = hashCode * -1521134295 + EqualityComparer<Caissier>.Default.GetHashCode(_Caissier);
            return hashCode;
        }
    }
}

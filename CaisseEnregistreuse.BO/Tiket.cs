using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.BO
{
    public class Tiket
    {
        private int id_ticket;
        public Panier _Panier { get; set; }
        public float Remise { get; set; }
        public double NetAPayer { get; set; }
        public Caissier _Caissier { get; set; }
        public int IdTicket
        {
            private set { }
            get => id_ticket;
        }
        public Tiket()
        {
            _Panier = new Panier();
            _Caissier = new Caissier();
        }

        public Tiket(int id_ticket, Panier panier, float remise, double netAPayer, Caissier caissier)
        {
            IdTicket = id_ticket;
            _Panier = panier;
            Remise = remise;
            NetAPayer = netAPayer;
            _Caissier = caissier;
        }
    }
}

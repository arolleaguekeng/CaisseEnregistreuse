using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.BO
{
    public class Achat
    {

        public Produit _Produit { get; set; }
        public int Quantite { get; set; }
        public double Montant { get; set; }
       

        public Achat()
        {

        }

        public Achat(Produit produit, int quantite, double montant)
        {
            _Produit = produit;
            Quantite = quantite;
            Montant = montant;
        }
    }
}

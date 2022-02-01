using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.BO
{
    public class Achat
    {

        private int id_achat;
        public Produit _Produit { get; set; }
        public int Quantite { get; set; }
        public double Montant { get; set; }
        public int IdAchat
        {
            private set { }
            get => id_achat;
        }

        public Achat()
        {

        }

        public Achat(int id_achat, Produit produit, int quantite, double montant)
        {
            IdAchat = id_achat;
            _Produit = produit;
            Quantite = quantite;
            Montant = montant;
        }
    }
}

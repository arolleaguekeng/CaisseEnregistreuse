using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.BO
{
    public class Produit
    {
        public string Code { get; set; }
        public string Designation { get; set; }
        public double PrixAchat { get; set; }
        public double PrixVente { get; set; }
        public Produit()
        {

        }

        public Produit(string code, string designation, double prixAchat, double prixVente)
        {
            Code = code;
            Designation = designation;
            PrixAchat = prixAchat;
            PrixVente = prixVente;
        }
    }
}

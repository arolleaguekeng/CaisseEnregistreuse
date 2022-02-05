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

        public override bool Equals(object obj)
        {
            return obj is Produit produit &&
                   Code == produit.Code &&
                   Designation == produit.Designation;
        }

        public override int GetHashCode()
        {
            int hashCode = 443220136;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Code);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Designation);
            return hashCode;
        }
    }
}

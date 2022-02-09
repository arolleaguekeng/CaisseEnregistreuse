using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.BO
{
    public class Historique
    {
        public string CodeProduit { get; set; }
        public int QuantiteProduit { get; set; }
        public double PrixAchatProduit { get; set; }
        public double PrixVenteProduit { get; set; }
        public double Benefice { get; set; }
        public string Date { get; set; }
        public double MontantAchat { get; set; }
        public double MontantVente { get; set; }
        public string  Designation { get; set; }


        public Historique()
        {

        }

        public Historique(string codeProduit, int quantiteProduit, double prixAchatProduit, double prixVenteProduit, double montantAchat, double montantVente, double benefice, string date,string designation)
        {
            CodeProduit = codeProduit;
            QuantiteProduit = quantiteProduit;
            PrixAchatProduit = prixAchatProduit;
            PrixVenteProduit = prixVenteProduit;
            Benefice = benefice;
            Date = date;
            MontantAchat = montantAchat;
            MontantVente = montantVente;
            Designation = designation;
        }
    }
}

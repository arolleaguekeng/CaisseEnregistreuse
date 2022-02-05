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
        public DateTime Date { get; set; }
        public double MontantAchat { get; set; }
        public double MontantTotalAchat { get; set; }


        public Historique()
        {

        }

        public Historique(string codeProduit, int quantiteProduit, double prixAchatProduit, double prixVenteProduit, double montantAchat, double montantTotalAchat, double benefice, DateTime date)
        {
            CodeProduit = codeProduit;
            QuantiteProduit = quantiteProduit;
            PrixAchatProduit = prixAchatProduit;
            PrixVenteProduit = prixVenteProduit;
            Benefice = benefice;
            Date = date;
            MontantAchat = montantAchat;
            MontantTotalAchat = montantTotalAchat;
        }

        public Historique(string code)
        {
            CodeProduit = code;
        }

        public Historique(string codeProduit, int quantiteProduit, double prixAchatProduit, double prixVenteProduit, double montant, DateTime date) : this(codeProduit)
        {
            QuantiteProduit = quantiteProduit;
            PrixAchatProduit = prixAchatProduit;
            PrixVenteProduit = prixVenteProduit;
            Date = date;
            MontantAchat = montant;
        }
    }
}

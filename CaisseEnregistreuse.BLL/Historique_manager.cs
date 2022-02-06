using CaisseEnregistreuse.BO;
using CaisseEnregistreuse.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.BLL
{
    public class Historique_manager
    {
        private PanierManager manager;
        private AchatManager achatManager;
        public Historique_manager()
        {
            manager = new PanierManager();
            achatManager = new AchatManager();
        }
        public List<Historique> GetHistorique(DateTime date)
        {
            double montantTotalAchat = 0;
            List<Historique> historiques = new List<Historique>();
            var paniers = manager.GetAll();
            Historique historique = new Historique();
            //foreach (var panier in paniers)
            //{
                foreach (var achat in paniers[1].Achats)
                {
                    historique.Date = paniers[0].Date;
                    historique.CodeProduit = achat._Produit.Code;
                    historique.QuantiteProduit = achat.Quantite;
                    historique.PrixAchatProduit = achat._Produit.PrixAchat;
                    historique.PrixVenteProduit = achat._Produit.PrixVente;
                    historique.Benefice = achat._Produit.PrixVente - achat._Produit.PrixAchat;
                    historique.MontantAchat = achat.Montant;
                    foreach (var produit in paniers[0].Achats)
                    {
                        montantTotalAchat += produit.Montant;
                    }
                    historique.MontantTotalAchat = montantTotalAchat;

                    historiques.Add(historique);

                }
                historique.Date = paniers[0].Date;
            //}

            return historiques;
        }


        public void AfficherHistorique(List<Historique> historiques)
        {
            int tablesize = 139;
            int leftpad = 6;
            int rightpad = 12;
            int nombreLine = 0;
            //Console.WriteLine(pd.Get(new Produit { Code = "PD01CE" }).Designation);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("+".PadRight(tablesize, '-') + "+");

            Console.WriteLine("|".PadRight(leftpad, ' ') + "Date".PadRight(25, ' ') +
                              "|".PadRight(leftpad, ' ') + "Code ".PadRight(     rightpad, ' ') +
                              "|".PadRight(leftpad, ' ') + "Quantite ".PadRight( rightpad, ' ') +
                              "|".PadRight(leftpad, ' ') + "P_Vente".PadRight(   rightpad, ' ') +
                              "|".PadRight(leftpad, ' ') + "P_achat".PadRight(   rightpad, ' ') +
                              "|".PadRight(leftpad, ' ') + "T_Achat".PadRight(   rightpad, ' ') +
                              "|".PadRight(leftpad, ' ') + "benefice".PadRight(  rightpad, ' ') + '|');

            Console.WriteLine("+".PadRight(tablesize, '-') + "+");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var history in GetHistorique(DateTime.Parse("02/10/2022")))
            {
                Console.WriteLine(" ".PadRight(leftpad, ' ') + history.Date.ToString().PadRight(25, ' ') +
                                  "|".PadRight(leftpad, ' ') + history.CodeProduit.PadRight(rightpad, ' ') +
                                  "|".PadRight(leftpad, ' ') + history.QuantiteProduit.ToString().PadRight(rightpad, ' ') +
                                  "|".PadRight(leftpad, ' ') + history.PrixVenteProduit.ToString().PadRight(rightpad, ' ') +
                                  "|".PadRight(leftpad, ' ') + history.MontantAchat.ToString().PadRight(rightpad, ' ') +
                                  "|".PadRight(leftpad, ' ') + history.MontantTotalAchat.ToString().PadRight(rightpad, ' ') +
                                  "|".PadRight(leftpad, ' ') + history.Benefice.ToString().PadRight(rightpad, ' ') + '|');
                Console.WriteLine("+".PadRight(tablesize, '-') + "+");
                nombreLine++;
            }
            Console.WriteLine("\n\n\n" + nombreLine);
        }
    }
}
 
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
            int nombreLine = 0;
            //Console.WriteLine(pd.Get(new Produit { Code = "PD01CE" }).Designation);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("+".PadRight(139, '-') + "+");

            Console.WriteLine("|".PadRight(6, ' ') + "Date".PadRight(25, ' ') +
                              "|".PadRight(6, ' ') + "Code ".PadRight(12, ' ') +
                              "|".PadRight(6, ' ') + "Quantite ".PadRight(12, ' ') +
                              "|".PadRight(6, ' ') + "P_Vente".PadRight(12, ' ') +
                              "|".PadRight(6, ' ') + "P_achat".PadRight(12, ' ') +
                              "|".PadRight(6, ' ') + "T_Achat".PadRight(12, ' ') +
                              "|".PadRight(6, ' ') + "benefice".PadRight(12, ' ') + '|');

            Console.WriteLine("+".PadRight(139, '-') + "+");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var history in GetHistorique(DateTime.Parse("02/10/2022")))
            {
                Console.WriteLine(" ".PadRight(6, ' ') + history.Date.ToString().PadRight(25, ' ') +
                                  "|".PadRight(6, ' ') + history.CodeProduit.PadRight(12, ' ') +
                                  "|".PadRight(6, ' ') + history.QuantiteProduit.ToString().PadRight(12, ' ') +
                                  "|".PadRight(6, ' ') + history.PrixVenteProduit.ToString().PadRight(12, ' ') +
                                  "|".PadRight(6, ' ') + history.MontantAchat.ToString().PadRight(12, ' ') +
                                  "|".PadRight(6, ' ') + history.MontantTotalAchat.ToString().PadRight(12, ' ') +
                                  "|".PadRight(6, ' ') + history.Benefice.ToString().PadRight(12, ' ') + '|');
                Console.WriteLine("+".PadRight(139, '-') + "+");
                nombreLine++;
            }
            Console.WriteLine("\n\n\n" + nombreLine);
        }
    }
}

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
        private HistoriqueDAO historiqueDAO;
        private List<Historique> historiques;
        public Historique_manager()
        {
            manager = new PanierManager();
            achatManager = new AchatManager();
            historiqueDAO = new HistoriqueDAO();
            historiques = new List<Historique>();
        }
        public List<Historique> GetHistorique(Historique historique, string date)
        {
            return historiqueDAO.Get(historique,date).ToList();
        }


        public string[,] AfficherHistorique(string date)
        {
            historiques = GetHistorique(new Historique { Date = date }, date);
            string[,] TabHistory = new string[historiques.Count,8];
            for(int i=0; i<TabHistory.GetLength(0); i++)
            {
                for(int j=0; j<TabHistory.GetLength(1); j++)
                {
                    TabHistory[i, 0] = historiques[i].Date;
                    TabHistory[i, 1] = historiques[i].CodeProduit;
                    TabHistory[i, 2] = historiques[i].QuantiteProduit.ToString();
                    TabHistory[i, 3] = historiques[i].PrixAchatProduit.ToString();
                    TabHistory[i, 4] = historiques[i].PrixVenteProduit.ToString();
                    TabHistory[i, 5] = historiques[i].MontantAchat.ToString();
                    TabHistory[i, 6] = historiques[i].MontantTotalAchat.ToString();
                    TabHistory[i, 7] = historiques[i].Benefice.ToString();
                    break;
                }
            }

            return TabHistory;
            //int tablesize = 139;
            //int leftpad = 6;
            //int rightpad = 12;
            //int nombreLine = 0;
            ////Console.WriteLine(pd.Get(new Produit { Code = "PD01CE" }).Designation);
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine("+".PadRight(tablesize, '-') + "+");

            //Console.WriteLine("|".PadRight(leftpad, ' ') + "Date".PadRight(25, ' ') +
            //                  "|".PadRight(leftpad, ' ') + "Code ".PadRight(     rightpad, ' ') +
            //                  "|".PadRight(leftpad, ' ') + "Quantite ".PadRight( rightpad, ' ') +
            //                  "|".PadRight(leftpad, ' ') + "P_Vente".PadRight(   rightpad, ' ') +
            //                  "|".PadRight(leftpad, ' ') + "P_achat".PadRight(   rightpad, ' ') +
            //                  "|".PadRight(leftpad, ' ') + "T_Achat".PadRight(   rightpad, ' ') +
            //                  "|".PadRight(leftpad, ' ') + "benefice".PadRight(  rightpad, ' ') + '|');

            //Console.WriteLine("+".PadRight(tablesize, '-') + "+");
            //Console.ForegroundColor = ConsoleColor.White;
            //foreach (var history in GetHistorique(new Historique { Date = date },date))
            //{
            //    Console.WriteLine(" ".PadRight(leftpad, ' ') + history.Date.ToString().PadRight(25, ' ') +
            //                      "|".PadRight(leftpad, ' ') + history.CodeProduit.PadRight(rightpad, ' ') +
            //                      "|".PadRight(leftpad, ' ') + history.QuantiteProduit.ToString().PadRight(rightpad, ' ') +
            //                      "|".PadRight(leftpad, ' ') + history.PrixVenteProduit.ToString().PadRight(rightpad, ' ') +
            //                      "|".PadRight(leftpad, ' ') + history.MontantAchat.ToString().PadRight(rightpad, ' ') +
            //                      "|".PadRight(leftpad, ' ') + history.MontantTotalAchat.ToString().PadRight(rightpad, ' ') +
            //                      "|".PadRight(leftpad, ' ') + history.Benefice.ToString().PadRight(rightpad, ' ') + '|');
            //    Console.WriteLine("+".PadRight(tablesize, '-') + "+");
            //    nombreLine++;
            //}
            //Console.WriteLine("\n\n\n" + nombreLine);
        }
    }
}
 
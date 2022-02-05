using CaisseEnregistreuse.BLL;
using CaisseEnregistreuse.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.console
{
    class Program
    {
        private static ProduitManager pd = new ProduitManager();
        private static AchatManager ac = new AchatManager();
        private static CaissierManager cs = new CaissierManager();
        private static Historique_manager hm = new Historique_manager();
       
        public static Affichage affichage = new Affichage();
        static void Main(string[] args)
        {
            List<Achat> achats = new List<Achat>();
            List<Produit> produits1 = new List<Produit>();
            produits1 = pd.GetAll(new Produit());
            achats = ac.GetAll();

            affichage.PrintEntete();
            string[,] produitTab = new string[produits1.Count(),4];
            for (int i = 0; i < produitTab.GetLength(0); i++)
            {
                for (int j = 0; j < produitTab.GetLength(1); j++)
                {
                   
                        produitTab[i, 0] = produits1[i].Code; 
                    
                        produitTab[i, 1] = produits1[i].Designation;
                   
                        produitTab[i, 2] = produits1[i].PrixAchat.ToString();
                   
                        produitTab[i, 3] = produits1[i].PrixAchat.ToString();
                    break;
                    
                }
            }

            foreach(var ac in achats)
            {
                Console.WriteLine(ac._Produit.PrixAchat);
            }
           


            //foreach(var produit in produits1)
            //{
            //    Console.WriteLine(produit.Code + " " + produit.Designation + " " + produit.PrixAchat + " " + produit.PrixVente);
            //}
            //AfficherTableau(produitTab);
            Console.ReadKey();
            

        }
        public static void AfficherTableau(string[,] tableau)
        {
            try
            {
                //Tableau pour conserver la taille maximale de chaque colonne.
                int[] colTailMax = new int[tableau.GetLength(1)];

                //Remplissage du tableau des tailles max.
                for (int i = 0; i < tableau.GetLength(1); i++)
                {
                    int tailleMax = tableau[0, i].Length; 

                    for (int j = 0; j < tableau.GetLength(0); j++)
                    {
                        if (tableau[j, i].Length > tailleMax)
                        {
                            tailleMax = tableau[j, i].Length;
                        }
                    }
                    colTailMax[i] = tailleMax*2;
                }

                //Affichage proprement dit.
                for (int i = 0; i < tableau.GetLength(0); i++)
                {
                    int etapeAffichage;
                    if (i == 0)
                        etapeAffichage = 3;
                    else
                        etapeAffichage = 2;

                    while (etapeAffichage > 0)
                    {
                        if (etapeAffichage == 3 || etapeAffichage == 1)
                        {
                            
                            Console.Write("+");
                            int j = 0;
                            for (j = 0; j < colTailMax.Length; j++)
                            {
                                int compteur = 0;
                                while (compteur != colTailMax[j])
                                {
                                    Console.Write('-');
                                    System.Threading.Thread.Sleep(30);
                                    compteur++;
                                }
                                Console.Write((j == colTailMax.Length - 1) ? "+\n" : "+");
                            }
                            if (etapeAffichage == 1 && i == 0)
                                etapeAffichage -= 2;
                            else
                                etapeAffichage--;
                        }
                        if (etapeAffichage == 2)
                        {
                           
                            Console.Write('|');
                            for (int j = 0; j < tableau.GetLength(1); j++)
                            {
                                while (tableau[i, j].Length < colTailMax[j])
                                {
                                    tableau[i, j] += " ";
                                }
                                Console.Write((j == colTailMax.Length - 1) ? tableau[i, j] + "|\n" : tableau[i, j] + "|");
                            }
                            etapeAffichage--;
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("The array is empty!");
            }
        }
    }
}

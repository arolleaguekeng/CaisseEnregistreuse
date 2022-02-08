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
        private static PanierManager pn = new PanierManager();
        private static AchatManager ac = new AchatManager();
        private static CaissierManager cs = new CaissierManager();
        public static Caissier currentCaissier;
       
        
        public static Affichage affichage = new Affichage();
        static void Main(string[] args)
        {
            Console.Clear();
            string matricule;
            List<Panier> paniers = new List<Panier>();
            List<Achat> achats = new List<Achat>();
            affichage.AfficherSplash();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Application console de caisse enregistreuse !");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Entrez le matricule du caissier....");
            matricule = Console.ReadLine();
            try
            {
                var caissier = cs.Get(new Caissier { Matricule = matricule });
                if(caissier !=null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nConnexion reussie !!");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Bonjour  { caissier.Nom.ToUpper()}!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Appuyer sur une touche pour continuer...");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    currentCaissier = caissier;
                    affichage.PrintEntete();
                    affichage.printMenu();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\ncet utilisateur  n'existe pas veuillez reesayez\n Appuyez sur une touche pour réessayer.....");
                    Console.ReadKey();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Main(args);
                }

            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("\nUne erreur c'est produite Appuyez sur une touche pour réessayer");
                Console.ReadKey();
                Main(args);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
               
            }
            


         


            
          
            Console.ReadKey();


        }
        public static void AfficherTableau(string[,] tableau)
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
                                  //  System.Threading.Thread.Sleep(1);
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
                                    if(double.TryParse(tableau[i, j],out _))
                                    {
                                        tableau[i, j] = tableau[i, j].PadLeft(colTailMax[j]);
                                    }
                                    else
                                    {
                                        tableau[i, j] = tableau[i, j].PadRight(colTailMax[j]);
                                    }
                                }
                                Console.Write((j == colTailMax.Length - 1) ? tableau[i, j] + "|\n" : tableau[i, j] + "|");
                            }
                            etapeAffichage--;
                        }
                    }
                }
            
          
        }

        public static void AfficherTableauFacture(string[,] tableau)
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
                    colTailMax[i] = tailleMax ;
                }
            Console.Write("|\t\t");
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
                                    System.Threading.Thread.Sleep(1);
                                    compteur++;
                                }
                                Console.Write((j == colTailMax.Length - 1) ? "+".PadRight(23, ' ') + "|\n|\t\t" : "+");
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
                                    if (double.TryParse(tableau[i, j], out _))
                                    {
                                        tableau[i, j] = tableau[i, j].PadLeft(colTailMax[j]);
                                    }
                                    else
                                    {
                                        tableau[i, j] = tableau[i, j].PadRight(colTailMax[j]);
                                    }
                                }
                                Console.Write((j == colTailMax.Length - 1) ? tableau[i, j] + "|".PadRight(23, ' ') +"|\n|\t\t" : tableau[i, j] + "|");
                            }
                            etapeAffichage--;
                        }
                    }
                }
            Console.Write("\n");
        }
        
    }
}

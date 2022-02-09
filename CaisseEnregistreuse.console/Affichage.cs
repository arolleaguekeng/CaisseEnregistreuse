using CaisseEnregistreuse.BLL;
using CaisseEnregistreuse.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.console
{
    public class Affichage
    {
        public static double Compteur = 0;
        List<Panier> paniers;
        PanierManager panierManager;
        private static Historique_manager hm = new Historique_manager();
        public static fonctionnalite fn = new fonctionnalite();
        public Affichage()
        {
            paniers = new List<Panier>();
            panierManager = new PanierManager();
            

        }

        public void PrintEntete()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('*', 133));
            for(int i=0; i<=2; i++)
            {
                for (int j = 0; j < 132; j++)
                {


                   
                    if (j == 0)
                    {
                        Console.Write("*");

                    }
                    else if (j == 55 && i == 1)
                    {
                        Console.Write("APP CAISSE ENREGISTREUSE");
                        j = 78;
                    }
                    else if (j == 120 && i == 2)
                    {
                        Console.Write("v1.0.0.0");
                        j = 127;
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
                Console.WriteLine("*");
            }
            Console.WriteLine(new string('*', 133));
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            
        }



        public void printMenu()
        {
            Compteur = 0;
            paniers = panierManager.Find(new Panier { Date = DateTime.Now });
            foreach (var p in paniers)
            {
                Compteur += p.Solde;
            }

            Console.Write("\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t");
            Console.WriteLine(new string('*', 100));
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j < 99; j++)
                {

                    if (j == 0)
                    {
                        Console.Write("\t\t*");

                    }
                    else if (j == 50 && i == 1)
                    {
                        Console.Write("MENU");
                        j = 53;
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
                Console.WriteLine("*");
            }
            //Console.Write("\t\t");
            //Console.WriteLine(new string('*', 100));
            //Console.Write("\n\n\t\t\t");
            //Console.Write("1) Enregistrer produit\t\t\t\t\t2) Afficher une historique");
            //Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\t\t\tMONTANT TOTAL CAISSE ");
            //Console.WriteLine("\n\t\t\t\t\t\t\t1000000 \tFCFA");
            //Console.Write("\n\n\t\t");
            //Console.WriteLine(new string('*', 100));

            Console.Write("\t\t");
            Console.Write(new string('*', 100));
            Console.Write("\t\t\t\t");
            for (int i = 0; i <= 10; i++)
            {
                
                for (int j = 0; j < 99; j++)
                {
                    
                    if (j == 0)
                    {
                        Console.Write("*");

                    }
                    else if (j == 8 && i == 2)
                    {
                        Console.Write("1) Enregistrer achats\t\t\t\t\t2) Afficher une historique");
                        j = 89;
                    }
                    else if(j == 40 && i == 6)
                    {
                        Console.Write("MONTANT TOTAL EN CAISSE");
                        j = 62;
                    }
                    else if(j == 48 && i == 8)
                    {
                        Console.Write($"{Compteur}\tFCFA");
                        j = 59;
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
                Console.WriteLine("*");
                Console.Write("\t\t");
                
            }
            
            Console.WriteLine(new string('*', 100));
            Console.Write("\t\t\t\t\t\t\t\t\t\t\t  CAISSIER : "+ Program.currentCaissier.Nom);
            Console.WriteLine("\n\n");
            string choix = "";
            Console.WriteLine("veuillez entrez votre choix (appuyez sur 1 ou 2)");
            choix = Console.ReadLine();
            if (choix == "1")
            {
                fn.Enreigistre();

            }
            else if (choix == "2")
            {
                Console.Clear();
                this.PrintEntete();
                Console.Write("\n\n\nentrer une date [yyyy-mm-dd] : \t\t");
                string date = Console.ReadLine();
                if (hm.AfficherHistorique(date).Length > 0)
                {
                    Console.WriteLine("\n\n\n");
                    Program.AfficherTableau(hm.AfficherHistorique(date));
                }
                else
                {
                    Console.WriteLine("\n\nAucun achat n'a ete effectuer a cette date ");
                }
                
            }
            else
            {
                Console.WriteLine("\n\nchoix non correct!!!");
            }
        }



        public  void AfficherSplash()
        {
            int tread = 150;
            Console.ForegroundColor = ConsoleColor.Gray;
            System.Threading.Thread.Sleep(tread);
            Console.WriteLine("|********************|          |****|                 |****|         |*************************|");
            System.Threading.Thread.Sleep(tread);
            Console.WriteLine("|********************|          |****|                 |****|         |*************************|");
            System.Threading.Thread.Sleep(tread);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("      |*****|                   |****|                 |****|         |****|");
            System.Threading.Thread.Sleep(tread);
            Console.WriteLine("      |*****|                   |****|                 |****|         |****|");
            System.Threading.Thread.Sleep(tread);
            Console.WriteLine("      |*****|                   |****|                 |****|         |****|");
            System.Threading.Thread.Sleep(tread);
            Console.WriteLine("      |*****|                   |****|                 |****|         |****|");
            System.Threading.Thread.Sleep(tread);
            Console.WriteLine("      |*****|                   |****|                 |****|         |****|");
            System.Threading.Thread.Sleep(tread);
            Console.WriteLine("      |*****|                   |****|                 |****|         |****|");
            System.Threading.Thread.Sleep(tread);
            Console.WriteLine("      |*****|                   |****|                 |****|         |****|");
            System.Threading.Thread.Sleep(tread);
            Console.WriteLine("      |*****|                   |****|                 |****|         |****|");
            System.Threading.Thread.Sleep(tread);
            Console.WriteLine("      |*****|                   |****|                 |****|         |****|");
            System.Threading.Thread.Sleep(tread);
            Console.WriteLine("      |*****|                   |****|                 |****|         |****|");
            System.Threading.Thread.Sleep(tread);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|********************|          |***************************|         |*************************|");
            System.Threading.Thread.Sleep(tread);
            Console.WriteLine("|********************|          |***************************|         |*************************|");


            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n");
            Console.WriteLine("\t\t\t\t ************   ************   **************   *************");
            Console.WriteLine("\t\t\t\t          ***        ***       ***        ***   ***");
            Console.WriteLine("\t\t\t\t          ***        ***       ***        ***   ***");
            Console.WriteLine("\t\t\t\t ************        ***       **************   ***");
            Console.WriteLine("\t\t\t\t          ***        ***       ***        ***   ***");
            Console.WriteLine("\t\t\t\t          ***        ***       ***        ***   ***");
            Console.WriteLine("\t\t\t\t ************   ************   ***        ***   *************");

        }
    }
}

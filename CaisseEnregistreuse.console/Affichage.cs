﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.console
{
    public class Affichage
    {

        public Affichage()
        {

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
            Console.ForegroundColor = ConsoleColor.White;
            
        }



        public void printMenu()
        {
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
                        Console.Write("1) Enregistrer produit\t\t\t\t\t2) Afficher une historique");
                        j = 89;
                    }
                    else if(j == 40 && i == 6)
                    {
                        Console.Write("MONTANT TOTAL EN CAISSE");
                        j = 62;
                    }
                    else if(j == 48 && i == 8)
                    {
                        Console.Write("10000\tFCFA");
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
            Console.WriteLine("\n");
        }

    }
}

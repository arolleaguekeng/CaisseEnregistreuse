using System;
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
            Console.ReadLine();
        }

    }
}

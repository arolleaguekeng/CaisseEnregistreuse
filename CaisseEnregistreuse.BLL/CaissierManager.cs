using CaisseEnregistreuse.BO;
using CaisseEnregistreuse.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.BLL
{
    public class CaissierManager
    {
        public string Commande;
        Panier panier;
        private CaissierDAO caissierDAO;
        public CaissierManager()
        {
            caissierDAO = new CaissierDAO();
            panier = new Panier();
            Commande = $"print {panier.Numero}.pdf";
        }


        public Caissier Get(Caissier caissier)
        {
            return caissierDAO.Get(caissier);
        }
        public void ImprimerTiket(string nomImprimente)
        {

        }
        public List<string> GetImprimante()
        {
            Process.Start("cmd.exe", Commande);


            List<string> results = new List<string>();
            using (Process p = new Process())
            {
                //executer un processuse windows avec le c#
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.Arguments = "mode LPT1";
                p.StartInfo.FileName = "cmd.exe";
                p.Start();
                string line;
                while ((line = p.StandardOutput.ReadLine()) != null)
                {
                    if (line != "")
                    {
                        var lineArr = line.Trim().Split(' ').Select(n => n).Where(n => !string.IsNullOrEmpty(n)).ToArray();
                        results.Add(lineArr[0]);
                    }
                    else
                    {
                        Console.WriteLine("Aucune imprimente détecté");
                    }
                }
                p.WaitForExit();
            }
            foreach (var a in results)
            {
                Console.WriteLine(a[0].ToString());
            }
            Console.ReadKey();
            return results;
        }


    }
}

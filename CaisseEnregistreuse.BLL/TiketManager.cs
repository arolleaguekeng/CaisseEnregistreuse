using CaisseEnregistreuse.BO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.BLL
{
    public class TiketManager
    {
        Panier panier;
        PanierManager manager;
        public TiketManager()
        {
        }
        public void OpenTiket(string path, string printerName)
        {
            string command = $"print";
            Process.Start("cmd.exe", command);
        }
    }
}

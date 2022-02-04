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
        static void Main(string[] args)
        {
            CaissierManager manager = new CaissierManager();
            manager.AddCaissier(new Caissier("EM01CE", "jojo ferol"));
            Console.WriteLine("enreigistrement ok");


        }
    }
}

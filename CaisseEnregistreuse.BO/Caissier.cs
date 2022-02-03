using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.BO
{
    public class Caissier
    {
        public int Matricule { get; set; }
        public string Nom { get; set; }
        public Caissier()
        {

        }

        public Caissier(int matricule, string nom)
        {
            Matricule = matricule;
            Nom = nom;
        }
    }
}

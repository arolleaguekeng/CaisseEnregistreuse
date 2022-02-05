using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.BO
{
    public class Caissier
    {
        public string Matricule { get; set; }
        public string Nom { get; set; }
        public Caissier()
        {

        }

        public Caissier(string matricule, string nom) 
        {
            Matricule = matricule;
            Nom = nom;
        }

        public override bool Equals(object obj)
        {
            return obj is Caissier caissier &&
                   Matricule == caissier.Matricule;
        }

        public override int GetHashCode()
        {
            return 797189699 + EqualityComparer<string>.Default.GetHashCode(Matricule);
        }
    }
}

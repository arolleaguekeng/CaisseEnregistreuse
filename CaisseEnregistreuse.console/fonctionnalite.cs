using CaisseEnregistreuse.BLL;
using CaisseEnregistreuse.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.console
{
    public class fonctionnalite
    {
        PanierManager panierManager;
        ProduitManager produitManager;
        AchatManager achatManager;
        Affichage Affichage;
        public fonctionnalite()
        {
            produitManager = new ProduitManager();
            panierManager = new PanierManager();
            achatManager = new AchatManager();
            achatManager = new AchatManager();
            Affichage = new Affichage();
        }

        public static int PanierCourant;
        public void Enreigistre()
        {
           
            string code = "";
            int quantite = 0;
            double Montant = 0;
            bool continuer = true;
            Panier panier = new Panier();
            string choix = String.Empty;
            List<Achat> achats = new List<Achat>();
            bool Remiser = true;
            double valeurRemise=0;
            Panier numPanier;
            double Montant_Percu=0;
            double Remboursement = 0;


            while (continuer)
            {
                Console.Clear();
                Affichage.PrintEntete();
                //var numPanier = panierManager.Add(new Panier(DateTime.Now));
                Console.Write("saisissez le code du produit : \t\t ");
                code = Console.ReadLine();
                var produit = produitManager.Get(new Produit { Code = code });
               
                if(produit != null)
                { 
                    Console.WriteLine($"\n\ndesignation du produit : \t\t{produit.Designation}\n\n\nprix de vente du produit : \t\t{produit.PrixVente}");
                   
                    do
                    {
                        Console.Write("\n\nentrer la quantite de produit de l'achat : \t");
                        quantite = int.Parse(Console.ReadLine());
                    }
                    while (quantite < 1);
                    Console.WriteLine("\n\nCode\t\t\tDesignation\t\t\t\t\tQuantite de produit\t\t\tMontant Total");
                    Console.WriteLine($"\n{code}\t\t\t{produit.Designation}\t\t\t\t\t{quantite}\t\t\t\t{produit.PrixVente * quantite}");
                    Console.WriteLine("\n\nvoulez vous validez l'achat ? (appuyer sur O ou N)");
                    choix = Console.ReadLine();
                    if(choix == "O" || choix == "o")
                    {
                       // var num = achatManager.Add(new Achat { Quantite = quantite, Numero = Panier.Numero, _Produit = produit , Montant = quantite*produit.PrixVente });
                        achats.Add(new Achat(produit, quantite, quantite * produit.PrixVente));
                    }
                }
                else
                {
                    Console.WriteLine("\n\nce code ne correspond a aucun produit");
                    
                }

                Console.WriteLine("\n\nvoulez vous continuer les ahats ? (appuyer sur O ou N)");
                choix = Console.ReadLine();
                if (choix == "O" || choix == "o")
                {
                    continuer = true;
                }
                else
                {
                    continuer = false;
                    foreach (var list in achats)
                    {
                        Montant += list.Montant;
                    }
                    
                }

            }
           
            if (achats.Count() >= 1)
            {
                Console.WriteLine("\n\nles achats total de ce panier sont de : \t\t" + Montant);
                Console.WriteLine("\n\nvoulez vous applique une remise a ce panier ??? (Appuyer sur O ou N)");
                choix = Console.ReadLine();
                if (choix == "O" || choix == "o")
                {
                    Console.WriteLine("\n\nChoix de la remise a appliquer");
                    Console.WriteLine("\n\n1)remise par pourcentage\t\t\t2)remise par valeur ");
                    choix = Console.ReadLine();
                    if (choix == "1")
                    {
                        do
                        {
                            Console.Write("\n\nentre une valeur en pourcentage pour la remise : \t\t");
                            valeurRemise = double.Parse(Console.ReadLine());
                        }
                        while (valeurRemise > 100 || valeurRemise < 0);
                        Console.WriteLine($"\n\nRemise de {(Montant * valeurRemise) / 100} FCFA appliquez avec succes");
                        valeurRemise = (Montant * valeurRemise) / 100;
                        numPanier = panierManager.Add(new Panier(DateTime.Now, null, Montant, valeurRemise));
                        for (int i = 0; i < achats.Count(); i++)
                        {
                            achats[i].Numero = numPanier.Numero;
                            PanierCourant = numPanier.Numero;
                            achatManager.Add(achats[i]);
                        }
                    }
                    else if (choix == "2")
                    {
                        do
                        {
                            Console.WriteLine("\n\nentre une valeur  pour la remise");
                            valeurRemise = double.Parse(Console.ReadLine());
                        }
                        while (valeurRemise > Montant || valeurRemise < 0);
                        Console.WriteLine($"\n\nRemise de {valeurRemise} FCFA appliquez avec succes");
                        numPanier = panierManager.Add(new Panier(DateTime.Now, null, Montant, valeurRemise));
                        for (int i = 0; i < achats.Count(); i++)
                        {
                            achats[i].Numero = numPanier.Numero;
                            PanierCourant = numPanier.Numero;
                            achatManager.Add(achats[i]);
                        }
                    }

                }
                else
                {
                    numPanier = panierManager.Add(new Panier(DateTime.Now, null, Montant));
                    for (int i = 0; i < achats.Count(); i++)
                    {
                        achats[i].Numero = numPanier.Numero;
                        PanierCourant = numPanier.Numero;
                        achatManager.Add(achats[i]);
                    }
                   
                }

                Console.Write("\n\nentrer le montant percu du client: \t\t");
                Montant_Percu = double.Parse(Console.ReadLine());
                while (Montant_Percu < Montant)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nle montant doit etre superieur ou egal au montant total des achats");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nveuillez entrer un autre montant !!!");
                    Montant_Percu = double.Parse(Console.ReadLine());
                }
                Remboursement = Montant_Percu - Montant + valeurRemise;
                Console.WriteLine("\n#########################################################");
                Console.WriteLine("\n\tmontant total achat :\t"+Montant + " FCFA");
                Console.WriteLine("\n\tmontant du client   :\t" + Montant_Percu + " FCFA");
                Console.WriteLine("\n\tRemise applique     :\t" + valeurRemise + " FCFA");
                Console.WriteLine("\n\tRemboursement       :\t" + Remboursement + " FCFA");
                Console.ReadKey();
                Console.WriteLine("\n\n+".PadRight(108, '-') +"+");
                string column2 = "|".PadRight(106, ' ') + "|\n";
                string column = "|".PadRight(53, ' ') + "Tiket".PadRight(53, ' ') + "|";
                Console.WriteLine(column);
                Console.WriteLine("+".PadRight(106, '-') + "+");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(column2);
                Console.Write("|\t\tNom du caissier : " + Program.currentCaissier.Nom + "\t\t\tDate: " + DateTime.Now.ToShortDateString().PadRight(28, ' ') + "|\n");
                Console.Write(column2);
                Program.AfficherTableauFacture(AfficherTiket(achats));
                Console.Write("|\t\t********************************************************************\t\t".PadRight(52, ' ') + "          |\n");
                Console.Write(column2);
                Console.Write("|\t\tmontant total achat : \t\t\t\t" + Montant +" \tFCFA".PadRight(36, ' ') + "|\n");
                Console.Write(column2);
                Console.Write("|\t\tremise applique     : \t\t\t\t" + valeurRemise + "  \tFCFA".PadRight(37, ' ') + "|\n");
                Console.Write(column2);
                Console.Write("|\t\tnet a payer         : \t\t\t\t" + (Montant - valeurRemise) + " \tFCFA".PadRight(36, ' ') + "|\n");
                Console.Write(column2);
                Console.Write("|\t\tencaissement        : \t\t\t\t" + Montant_Percu + " \tFCFA".PadRight(36, ' ') + "|\n");
                Console.Write(column2);
                Console.Write("|\t\tremboursement       : \t\t\t\t" + Remboursement + " \tFCFA".PadRight(36, ' ') + "|\n");
                Console.Write(column2);
                Console.Write("+".PadRight(106, '-') + "+");
            }
            
            Console.ReadKey();
            Console.WriteLine("\n\nQuitter l'enregistrement des achats");
            Console.ReadKey();
            Console.Clear();
            Affichage.PrintEntete();
            Affichage.printMenu();
        }

        private string[,] AfficherTiket(List<Achat> achats)
        {

            string[,] produits = new string[achats.Count+1, 5];
           
            for (int i = 0; i < produits.GetLength(0); i++)
            {
                
                for (int j = 0; j < 5; j++)
                {
                    if (i == 0)
                    {
                        produits[i, 0] = "Produits";
                        produits[i, 1] = "Designation";
                        produits[i, 2] = "PrixVente";
                        produits[i, 3] = "Quantite";
                        produits[i, 4] = "Montant";
                        break;
                    }
                    else
                    {
                        produits[i, 0] = achats[i-1]._Produit.Code.ToString();
                        produits[i, 1] = achats[i-1]._Produit.Designation.ToString();
                        produits[i, 2] = achats[i-1]._Produit.PrixVente.ToString();
                        produits[i, 3] = achats[i-1].Quantite.ToString();
                        produits[i, 4] = achats[i - 1].Montant.ToString();
                        break;
                    }
                    
                   
                }
            }
            return produits;
        }
    }
}

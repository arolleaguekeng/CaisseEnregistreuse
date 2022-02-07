﻿using CaisseEnregistreuse.BLL;
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
            double valeurRemise;
            Panier numPanier;


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
                        achats.Add(new Achat(new Produit(produit.Code, produit.Designation, produit.PrixAchat, produit.PrixVente), quantite, quantite * produit.PrixVente));
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
                        numPanier = panierManager.Add(new Panier(DateTime.Now, null, Montant, valeurRemise));
                        for (int i = 0; i < achats.Count(); i++)
                        {
                            achats[i].Numero = numPanier.Numero;
                            PanierCourant = numPanier.Numero;
                            achatManager.Add(achats[i]);
                        }
                        AfficherTiket(achats);
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
                        AfficherTiket(achats);
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
                    AfficherTiket(achats);
                }


            }
            Console.WriteLine("\n\nQuitter l'enregistrement des achats");
            Console.ReadKey();
            Console.Clear();
            Affichage.PrintEntete();
            Affichage.printMenu();
        }

        private static void AfficherTiket(List<Achat> achats)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("+".PadRight(100, '-') + "+");
            string column = "".PadRight(50, ' ') + "Tiket".PadRight(50, ' ') + "|";
            Console.WriteLine(column);
            Console.WriteLine("+".PadRight(100, '-') + "+");
            Console.ForegroundColor = ConsoleColor.White;
            string[,] produits = new string[achats.Count, 4];
            produits[0, 0] = "Produits";
            produits[0, 1] = "Designation";
            produits[0, 2] = "PrixVente";
            produits[0, 3] = "Montant";
            for (int i = 1; i < achats.Count+1; i++)
            {
                
                for (int j = 1; i < 6; j++)
                {

                    produits[i, 0] = achats[i]._Produit.Code.ToString();
                    produits[i, 1] = achats[i]._Produit.Designation.ToString();
                    produits[i, 2] = achats[i]._Produit.PrixVente.ToString();
                    produits[i, 3] = achats[i].Montant.ToString();
                    break;
                }
                Console.WriteLine("Nom du caissier : " + Program.currentCaissier);
                Program.AfficherTableau(produits);

            }
        }
    }
}

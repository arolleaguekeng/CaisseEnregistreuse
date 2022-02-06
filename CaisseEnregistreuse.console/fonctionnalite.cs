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


        public void Enreigistre()
        {
            //Affichage.PrintEntete();
            string code = "";
            int quantite = 0;
            double Montant = 0;
            bool continuer = true;
            Panier panier = new Panier();
            string choix = String.Empty;
            List<Achat> achats = new List<Achat>(); ; 

            while (continuer)
            {
                Console.Clear();
               
                //var numPanier = panierManager.Add(new Panier(DateTime.Now));
                Console.WriteLine("saisissez le code du produit ");
                code = Console.ReadLine();
                var produit = produitManager.Get(new Produit { Code = code });
               
                if(produit != null)
                {
                    Console.WriteLine($"\n\ndesignation du produit : {produit.Designation}\n\nprix de vente du produit : {produit.PrixVente}");
                   
                    do
                    {
                        Console.WriteLine("\nentrer la quantite de produit de l'achat");
                        quantite = int.Parse(Console.ReadLine());
                    }
                    while (quantite < 1);
                    Console.WriteLine("\nCode\t\t\tDesignation\t\t\tQuantite\t\t\tMontant Total");
                    Console.WriteLine($"\n{code}\t\t\t{produit.Designation}\t\t\t{quantite}\t\t\t{produit.PrixVente * quantite}");
                    Console.WriteLine("\nvoulez vous validez l'achat ? (appuyer sur O ou N)");
                    choix = Console.ReadLine();
                    if(choix == "O" || choix == "o")
                    {
                       // var num = achatManager.Add(new Achat { Quantite = quantite, Numero = Panier.Numero, _Produit = produit , Montant = quantite*produit.PrixVente });
                        achats.Add(new Achat(new Produit(produit.Code, produit.Designation, produit.PrixAchat, produit.PrixVente), quantite, quantite * produit.PrixAchat));
                    }
                }
                else
                {
                    Console.WriteLine("ce code ne correspond a aucun produit");
                    
                }

                Console.WriteLine("vous les vous continuer les ahats ? (appuyer sur O ou N)");
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
                    Panier numPanier = panierManager.Add(new Panier(DateTime.Now, null, Montant));
                    for(int i = 0; i<achats.Count(); i++)
                    {
                        achats[i].Numero = numPanier.Numero;
                        achatManager.Add(achats[i]);
                    }
                    
                    Console.WriteLine("Quitter l'enregistrement de l'achat");
                    Console.ReadKey();
                    Console.Clear();
                    Affichage.PrintEntete();
                    Affichage.printMenu();
                }

            }
        }
    }
}

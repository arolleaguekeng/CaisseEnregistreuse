using CaisseEnregistreuse.BLL;
using CaisseEnregistreuse.BO;
using System;
using System.Collections.Generic;
using System.IO;
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
                Console.WriteLine("saisissez le code du produit : ");
                Console.Write(Program.fleche);
                code = Console.ReadLine();
                var produit = produitManager.Get(new Produit { Code = code });
                Console.ForegroundColor = ConsoleColor.White;
                if (produit != null)
                {
                    Console.Write("\n\ndesignation du produit                   : \t\t");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(produit.Designation);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nprix de vente du produit                 : \t\t");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(produit.PrixVente);
                    Console.ForegroundColor = ConsoleColor.White;
                    do
                    {
                        Console.WriteLine("\nentrer la quantite de produit de l'achat : ");
                        Console.Write(Program.fleche);
                        quantite = int.Parse(Console.ReadLine());
                    }
                    while (quantite < 1);
                    string[,] TabProduit = new string[2,4];
                    for(int i=0; i<TabProduit.GetLength(0); i++)
                    {
                        for(int j=0; j<TabProduit.GetLength(1); j++)
                        {
                            if (i == 0)
                            {
                                TabProduit[i, 0] = "Code";
                                TabProduit[i, 1] = "Designation";
                                TabProduit[i, 2] = "Quantite de produit";
                                TabProduit[i, 3] = "Montant total";
                            }
                            else
                            {
                                TabProduit[i, 0] = produit.Code;
                                TabProduit[i, 1] =produit.Designation;
                                TabProduit[i, 2] =  quantite.ToString();
                                TabProduit[i, 3] = (produit.PrixVente * quantite).ToString();
                            }
                        }
                    }
                    Program.AfficherTableauDetail(TabProduit);
                    //Console.WriteLine("\n\nCode\t\t\tDesignation\t\t\t\t\tQuantite de produit\t\t\tMontant Total");
                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.WriteLine($"\n{code}\t\t\t{produit.Designation}\t\t\t\t\t{quantite}\t\t\t\t{produit.PrixVente * quantite}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\nvoulez vous validez l'achat ? (appuyer sur O ou N)");
                    Console.Write(Program.fleche);
                    choix = Console.ReadLine();
                    if(choix == "O" || choix == "o")
                    {
                       // var num = achatManager.Add(new Achat { Quantite = quantite, Numero = Panier.Numero, _Produit = produit , Montant = quantite*produit.PrixVente });
                        achats.Add(new Achat(produit, quantite, quantite * produit.PrixVente));
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nce code ne correspond a aucun produit");
                    Console.ForegroundColor = ConsoleColor.White;

                }

                Console.WriteLine("\n\nvoulez vous continuer les ahats ? (appuyer sur O ou N)");
                Console.Write(Program.fleche);
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
            Console.ForegroundColor = ConsoleColor.White;
            if (achats.Count() >= 1)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n\nles achats total de ce panier sont de : \t\t");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(Montant);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" FCFA");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\nvoulez vous applique une remise a ce panier ??? (Appuyer sur O ou N)");
                Console.Write(Program.fleche);
                choix = Console.ReadLine();
                if (choix == "O" || choix == "o")
                {
                    Console.Clear();
                    Affichage.PrintEntete();
                    Console.WriteLine("\n\nChoix du type de remise a appliquer");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\n1)remise par pourcentage\t\t\t2)remise par valeur ");
                    Console.Write(Program.fleche);
                    choix = Console.ReadLine();
                    if (choix == "1")
                    {
                        do
                        {
                            Console.WriteLine("\n\nentre une valeur en pourcentage pour la remise : ");
                            Console.Write(Program.fleche);
                            valeurRemise = double.Parse(Console.ReadLine());
                        }
                        
                        while (valeurRemise > 100 || valeurRemise < 0);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n\nRemise de {(Montant * valeurRemise) / 100} FCFA appliquez avec succes");
                        Console.ForegroundColor = ConsoleColor.White;
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
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n\nentre une valeur  pour la remise");
                            Console.Write(Program.fleche);
                            valeurRemise = double.Parse(Console.ReadLine());
                        }
                        while (valeurRemise > Montant || valeurRemise < 0);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n\nRemise de {valeurRemise} FCFA appliquez avec succes");
                        Console.ForegroundColor = ConsoleColor.White;
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

                Console.Write("\n\nentrer le montant du client : \t\t");
                Console.ForegroundColor = ConsoleColor.White;
                Montant_Percu = double.Parse(Console.ReadLine());
                Console.Write(Program.fleche);
                while (Montant_Percu < Montant)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nle montant doit etre superieur ou egal au montant total des achats");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nveuillez entrer un autre montant !!!");
                    Console.Write(Program.fleche);
                    Montant_Percu = double.Parse(Console.ReadLine());
                }
                Remboursement = Montant_Percu - Montant + valeurRemise;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\nrecapitulatif sur achat");
                Console.WriteLine("#########################################################");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\tmontant total achat :\t"+Montant + " FCFA");
                Console.WriteLine("\n\tmontant du client   :\t" + Montant_Percu + " FCFA");
                Console.WriteLine("\n\tRemise applique     :\t" + valeurRemise + " FCFA");
                Console.WriteLine("\n\tRemboursement       :\t" + Remboursement + " FCFA");
                Console.WriteLine("\nContinuer pour voir la facture ...");
                Console.ReadKey();
                Console.Clear();
                Affichage.PrintEntete();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t\t\t\t\t\tfacturation de l'achat");
                Console.WriteLine("\t\t\t\t\t#########################################################\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\n\t+".PadRight(117, '-') + "+");
                string column2 = "\t|".PadRight(115, ' ') + "|\n";
                string column = "\t|".PadRight(57, ' ') + "Ticket".PadRight(58, ' ') + "|";
                Console.WriteLine(column);
                Console.WriteLine("\t+".PadRight(115, '-') + "+");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(column2);
                Console.Write("\t|\t\t\tNom du caissier : " + Program.currentCaissier.Nom + "\t\tDate: " + DateTime.Now.ToShortDateString().PadRight(36, ' ') + "|\n");
                Console.Write(column2);
                Program.AfficherTableauFacture(AfficherTiket(achats));
                Console.Write("\t|\t\t\t********************************************************************\t\t".PadRight(51, ' ') + "          |\n");
                Console.Write(column2);
                Console.Write("\t|\t\t\tmontant total achat : \t\t\t\t" + Montant + " FCFA".PadRight(37, ' ') + "|\n");
                Console.Write(column2);
                Console.Write("\t|\t\t\tremise applique     : \t\t\t\t" + valeurRemise + " FCFA".PadRight(38, ' ') + "   |\n");
                Console.Write(column2);
                Console.Write("\t|\t\t\tnet a payer         : \t\t\t\t" + (Montant - valeurRemise) + " FCFA".PadRight(37, ' ') + "|\n");
                Console.Write(column2);
                Console.Write("\t|\t\t\tencaissement        : \t\t\t\t" + Montant_Percu + " FCFA".PadRight(37, ' ') + "|\n");
                Console.Write(column2);
                Console.Write("\t|\t\t\tremboursement       : \t\t\t\t" + Remboursement + " FCFA".PadRight(37, ' ') + " |\n");
                Console.Write(column2);
                Console.Write("\t|\t\t\t********************************************************************\t\t".PadRight(51, ' ') + "          |\n");
                Console.Write(column2);
                Console.Write("\t|".PadRight(50, ' ') + "MERCI POUR VOS ACHATS !!!".PadRight(65, ' ') + "|\n");
                Console.Write(column2);
                Console.Write("\t+".PadRight(115, '-') + "+");
                string path = "..facture.txt";
                PrintFile(path, achats, Montant, valeurRemise, Montant_Percu, Remboursement);
                Console.Write("\n\n\t1) Imprimer le ticket \t\t\t\t\t\t\t\t\t2) Terminer");
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

        private void PrintFile(string path, List<Achat> achats, double Montant, double valeurRemise, double Montant_Percu, double Remboursement)
        {
            //1. Get the name of the output file
            var fileName = path;
            //2. Create the file
            var file = new FileStream(fileName, FileMode.Create);
            //3. Save the standard output
            var standardOutput = Console.Out;
            //4. Create a StreamWriter
            using (var writer = new StreamWriter(file))
            {
                //5. Set the new output
                Console.SetOut(writer);
                //6. Write something
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t\t\t\t\t\tfacturation de l'achat");
                Console.WriteLine("\t\t\t\t\t#########################################################\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\n\t+".PadRight(117, '-') + "+");
                string column2 = "\t|".PadRight(115, ' ') + "|\n";
                string column = "\t|".PadRight(57, ' ') + "Ticket".PadRight(58, ' ') + "|";
                Console.WriteLine(column);
                Console.WriteLine("\t+".PadRight(115, '-') + "+");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(column2);
                Console.Write("\t|\t\t\tNom du caissier : " + Program.currentCaissier.Nom + "\t\tDate: " + DateTime.Now.ToShortDateString().PadRight(36, ' ') + "|\n");
                Console.Write(column2);
                Program.AfficherTableauFacture(AfficherTiket(achats));
                Console.Write("\t|\t\t\t********************************************************************\t\t".PadRight(51, ' ') + "          |\n");
                Console.Write(column2);
                Console.Write("\t|\t\t\tmontant total achat : \t\t\t\t" + Montant + " FCFA".PadRight(37, ' ') + "|\n");
                Console.Write(column2);
                Console.Write("\t|\t\t\tremise applique     : \t\t\t\t" + valeurRemise + " FCFA".PadRight(38, ' ') + "   |\n");
                Console.Write(column2);
                Console.Write("\t|\t\t\tnet a payer         : \t\t\t\t" + (Montant - valeurRemise) + " FCFA".PadRight(37, ' ') + "|\n");
                Console.Write(column2);
                Console.Write("\t|\t\t\tencaissement        : \t\t\t\t" + Montant_Percu + " FCFA".PadRight(37, ' ') + "|\n");
                Console.Write(column2);
                Console.Write("\t|\t\t\tremboursement       : \t\t\t\t" + Remboursement + " FCFA".PadRight(37, ' ') + " |\n");
                Console.Write(column2);
                Console.Write("\t|\t\t\t********************************************************************\t\t".PadRight(51, ' ') + "          |\n");
                Console.Write(column2);
                Console.Write("\t|".PadRight(50, ' ') + "MERCI POUR VOS ACHATS !!!".PadRight(65, ' ') + "|\n");
                Console.Write(column2);
                Console.Write("\t+".PadRight(115, '-') + "+");
                //7. Change the ouput again
                Console.SetOut(standardOutput);
            }
            PrinterClass pt = new PrinterClass();
            pt.PrintDoc(fileName);
        }

    }
}

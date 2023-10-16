/*
 * Created by SharpDevelop.
 * User: n.favier
 * Date: 13/10/2023
 * Time: 11:45
 */
 
using System;

namespace morpion_console
{
    class Program
    {
        public static int[,] grille = new int[3, 3]; // matrice pour stocker les coups joués

        // Fonction permettant l'affichage du Morpion
        public static void AfficherMorpion(int j, int k)
        {
            for (j = 0; j < grille.GetLength(0); j++)	// parcour la première dimension de la grille
            {
                Console.Write("\n|===|===|===|\n");
                Console.Write("|");
                for (k = 0; k < grille.GetLength(1); k++)	// parcour la deuxième dimension de la grille
                {
                	if(grille[j,k] == 1)
                	{
                		Console.Write(" X ");
                	}
                	else if(grille[j,k] == 2)
                	{
                		Console.Write(" O ");
                	}
                	else
                	{
                		Console.Write("   ");
                	}
                    Console.Write("|");
                }
                
            }
            Console.Write("\n|===|===|===|\n");
        }

        // Fonction permettant de changer
        // dans le tableau quelle est le 
        // joueur qui à jouer
        // Bien vérifier que le joueur ne sort
        // pas du tableau et que la position
        // n'est pas déjà jouée
        public static bool AJouer(int j, int k, int joueur)
        {
        	if(0 <= j && j < 3 && 0 <= k && k < 3)
        	{
        		if(grille[j,k] ==10)
        		{
        			grille[j,k] = joueur;
        			return true;
        		}
        	}
            return false;
        }

        // Fonction permettant de vérifier
        // si un joueur à gagner
        public static bool Gagner(int l, int c, int joueur)
        {
        	
        }

        // Programme principal
        static void Main(string[] args)
        {
            //--- Déclarations et initialisations --
            int LigneDébut = Console.CursorTop;     // par rapport au sommet de la fenêtre
            int ColonneDébut = Console.CursorLeft; // par rapport au sommet de la fenêtre

            int essais = 0;    // compteur d'essais
	        int joueur = 1 ;   // 1 pour la premier joueur, 2 pour le second
	        int l, c = 0;      // numéro de ligne et de colonne
            int j, k = 0;      // Parcourir le tableau en 2 dimensions
            bool gagner = false; // Permet de vérifier si un joueur à gagné 
            bool bonnePosition = false; // Permet de vérifier si la position souhaité est disponible

	        //--- initialisation de la grille ---
            // On met chaque valeur du tableau à 10
	        for (j=0; j < grille.GetLength(0); j++)
		        for (k=0; k < grille.GetLength(1); k++)
			        grille[j,k] = 10;
            while(!gagner && essais != 9)
            {
                // A compléter
                Console.Clear();
                Console.WriteLine("Le joueur "+joueur+" doit jouer !");
                AfficherMorpion(j,k);
                
                try
                {
                    Console.WriteLine("Ligne   =    ");
                    Console.WriteLine("Colonne =    ");
                    // Peut changer en fonction de comment vous avez fait votre tableau.
                    Console.SetCursorPosition(LigneDébut + 10, ColonneDébut + 9); // Permet de manipuler le curseur dans la fenêtre 
                    l = int.Parse(Console.ReadLine()) - 1; 
                    // Peut changer en fonction de comment vous avez fait votre tableau.
                    Console.SetCursorPosition(LigneDébut + 10, ColonneDébut + 10); // Permet de manipuler le curseur dans la fenêtre 
                    c = int.Parse(Console.ReadLine()) - 1;

                    // A compléter
                    bonnePosition = AJouer(l,c,joueur);
                    gagner = Gagner(l,c,joueur);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                // Changement de joueur
                if(bonnePosition && !gagner)
                {
                	essais += 1;
	                if(joueur == 1)
	                {
	                	joueur = 2;
	                }
	                else
	                {
	                	joueur = 1;
	                }
                }
                else
                {
                	Console.WriteLine("Le placement est incorrecte!");
                	Console.ReadKey(true);
                }
                // A compléter

            } // Fin TQ

            // Fin de la partie
            // A compléter
            if(!gagner && essais == 9)
            {
            	Console.WriteLine("Match nul!!");
            }
            else
            {
            	Console.WriteLine("Le joueur {0} a gagné !", joueur);
            }
            Console.ReadKey();
    }
  }
}

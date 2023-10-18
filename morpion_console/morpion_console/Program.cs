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
        	Console.Write("\n  | 1 | 2 | 3 |");
            for (j = 0; j < grille.GetLength(0); j++)	// parcour la première dimension de la grille
            {
                Console.Write("\n==|===|===|===|\n");
                Console.Write((j+1)+" |");
                for (k = 0; k < grille.GetLength(1); k++)	// parcour la deuxième dimension de la grille
                {
                	if(grille[j,k] == 1)	// si le joueur 1 à jouer ici
                	{
                		Console.Write(" X ");
                	}
                	else if(grille[j,k] == 2)	// si le joueur 2 à jouer ici
                	{
                		Console.Write(" O ");
                	}
                	else	// si personne à jouer ici
                	{
                		Console.Write("   ");
                	}
                    Console.Write("|");
                }
                
            }
            Console.Write("\n==|===|===|===|\n");
        }

        // Fonction permettant de changer
        // dans le tableau quelle est le 
        // joueur qui à jouer
        // Bien vérifier que le joueur ne sort
        // pas du tableau et que la position
        // n'est pas déjà jouée
        public static bool AJouer(int j, int k, int joueur)
        {
        	if(0 <= j && j < 3 && 0 <= k && k < 3)	// si la ligne et la colonne sont dans la grille
        	{
        		if(grille[j,k] == 10)	// si personne à jouer ici
        		{
        			grille[j,k] = joueur;	// le joueur à maintenant jouer ici
        			return true;
        		}
        	}
            return false;	// pas dans le tableau ou quelqu'un à déjà joué ici
        }

        // Fonction permettant de vérifier
        // si un joueur à gagner
        public static bool Gagner(int l, int c, int joueur)
        {
        	if(grille[l,0] == grille[l,1] && grille[l,1] == grille[l,2] && grille[l,1] != 10)	// si la ligne où le joueur a joué est gagnante
        	{
        		return true;
        	}
        	if(grille[0,c] == grille[1,c] && grille[1,c] == grille[2,c] && grille[2,c] != 10)	// si la colonne où le joueur a joué est gagnante
        	{
        		return true;
        	}
        	if(((grille[0,0] == grille[1,1] && grille[1,1] == grille[2,2]) || (grille[2,0] == grille[1,1] && grille[1,1] == grille[0,2])) && grille[1,1] != 10)	// si une des diagonales est gagnante
        	{
        		return true;
        	}
            return false;	// pas de gagnant
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
                Console.Clear();	// vide la console
                Console.WriteLine("Le joueur "+joueur+" doit jouer !");
                AfficherMorpion(j,k);	// affiche la grille de jeu
                
                try
                {
                    Console.WriteLine("Ligne   =    ");
                    Console.WriteLine("Colonne =    ");
                    // Peut changer en fonction de comment vous avez fait votre tableau.
                    Console.SetCursorPosition(LigneDébut + 10, ColonneDébut + 10); // Permet de manipuler le curseur dans la fenêtre 
                    l = int.Parse(Console.ReadLine()) - 1; 
                    // Peut changer en fonction de comment vous avez fait votre tableau.
                    Console.SetCursorPosition(LigneDébut + 10, ColonneDébut + 11); // Permet de manipuler le curseur dans la fenêtre 
                    c = int.Parse(Console.ReadLine()) - 1;

                    bonnePosition = AJouer(l,c,joueur);	// tente de rentrer le coup du joueur dans la grille et récupère si cela a eu lieu
                    gagner = Gagner(l,c,joueur);	// regarde si le joueur à gagné

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                // Changement de joueur
                if(gagner)	// si le joueur a gagné
                {
                	break;
                }
                if(bonnePosition && !gagner)	// si le joueur a bien joué mais n'a pas gagné
                {
                	// changement de joueur et augmente le nombre d'essai
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
                else	// si le joueur a mal joueur -> on ne change pas de joueur ni augmente le nombre d'essai et on recommence le tour
                {
                	Console.WriteLine("Le placement est incorrecte!");
                	Console.ReadKey(true);
                }
            } // Fin TQ

            // Fin de la partie
            // gère l'affichage de fin
            Console.Clear();
            AfficherMorpion(j,k);
            
            if(!gagner && essais == 9)	// si il y a match nul
            {
            	Console.WriteLine("Match nul!!");
            }
            else	// sinon il y a un gagnant + affichage du gagnant
            {
            	Console.WriteLine("Le joueur {0} a gagné !", joueur);
            }
            Console.ReadKey();
    }
  }
}

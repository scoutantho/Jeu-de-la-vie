using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeu_de_la_vie
{
    class Program
    {
        static void Main(string[] args)
        {
            int generation = 0;
           
            Console.WriteLine("indiquer la taille du plateau de jeu ");
            int taille =  int.Parse(Console.ReadLine());
            Console.WriteLine("indiquer le nombre de pourcentage");
            int pourcentage = int.Parse(Console.ReadLine());
            Console.WriteLine("indiquer si jeu1 ou jeu2 avec 1 ou 2");
            int jeu = int.Parse(Console.ReadLine());
            bool Jeu = false; if (jeu == 1) { Jeu = true; } //true niveau 1
            Console.WriteLine("indiquer le temps en millisecondes entre 2 affichages ");
            int temps = int.Parse(Console.ReadLine());
            Console.Clear();

            Grille grille = new Grille(taille, pourcentage);


            do {
                for(int i = 0; i < 5; i++) { Console.WriteLine(); }
                grille.AfficheGrille();
                System.Threading.Thread.Sleep(temps); //permet d'attendre 1000 millisecondes (petite recherche sur internet : how wait c#) 
                Console.Clear();                       //permet d'effacer la console
                grille = grille.jouer(Jeu);
                generation++;
            }
            while ( grille.getChanged);
            Console.WriteLine("il y a eu {0} générations ", generation);
            Console.ReadKey();
        }
    }
}

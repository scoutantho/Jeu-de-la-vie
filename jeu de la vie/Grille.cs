using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeu_de_la_vie
{
    class Grille
    {
        private Cellule[,] grille;
        private int taille;
        private Boolean changed = true;
        private static int AGE_MORT=5;
        private static int ENERGIE_REPRODUCTION = 10;

        public Grille(int taille)
        {
            this.taille = taille;
            grille = new Cellule[taille, taille];

            int i = 0, j = 0;
            foreach (Cellule c in grille)       //remplacable par un double for
            {
                if (j - taille == 0) { j = 0; i++; }
                grille[i, j] = new Cellule(i, j);
                j++;
            }
        }
        public Grille(int taille, int pourcentage)  
        {
            this.taille = taille;
            int nbCell = (pourcentage * (taille*taille) / 100);
            Random cellVivante = new Random();
            grille = new Cellule[taille, taille];

            

            //déclaration de mes autres cellules
            int i = 0, j = 0;
            foreach (Cellule c in grille)       //remplacable par un double for
            {
                if (c == null)
                {
                    grille[i, j] = new Cellule(i, j);
                }
                j++;                                    //colonne suivante 
                if (j - taille == 0) { j = 0; i++; }   //si  colonnes = taille alors fin de la matrice donc passage ligne suivante
            }

            //déclaration de mes cellules vivantes aléatoire 
            for (int a = 0; a < nbCell; a++)
            {

                int x = cellVivante.Next(taille);
                int y = cellVivante.Next(taille);
                if (grille[x, y].getEtat) { a--; } //si la cellule est vivante, on recommence
                else
                {
                   // grille[x, y] = new Cellule(x, y);
                    grille[x, y].setEtat = true;
                }
            }
        }
        public Grille(int taille, int pourcentage, string libelle, int age, int energie) { }
        public Grille(string file) { }

        public int getTaille { get { return taille; } }
        public Cellule getCell(int x, int y) { return grille[x, y]; }
        public void AfficheGrille()
        {
            foreach (Cellule c in grille)
            {   
                c.Affiche();
                if (c.getY == taille - 1) { Console.WriteLine(); }

            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void EcritureGrille(string fichier) { }
        public Cellule VoisinNord(Cellule macase)
        {
            int x = macase.getX, y = macase.getY;
            if (x == 0) { return grille[taille - 1, y]; }//taille -1 car indice de 0à4 pour taille =5
            return grille[x - 1, y];
        }
        public Cellule VoisinNordEst(Cellule macase)
        {
            int x = macase.getX, y = macase.getY;
            if (x == 0)
            {
                if (y == taille - 1) { return grille[taille - 1, 0]; } //si extrémité droite alros coin en bas à gauche
                else return grille[taille - 1, y + 1];
            }
            else if (y == taille - 1) { return grille[x - 1, 0]; }


            return grille[x - 1, y + 1];
        }
        public Cellule VoisinNordOuest(Cellule macase)
        {
            int x = macase.getX, y = macase.getY;
            if (x == 0)
            {
                if (y == 0) { return grille[taille - 1, taille - 1]; } //si extrémité gauche alros coin en bas à droite
                else return grille[taille - 1, y - 1];
            }
            else if (y == 0) { return grille[x - 1, taille - 1]; }


            return grille[x - 1, y - 1];
        }
        public Cellule VoisinSud(Cellule macase)
        {
            int x = macase.getX, y = macase.getY;
            if (x == taille - 1) { return grille[0, y]; }
            return grille[x + 1, y];
        }
        public Cellule VoisinSudEst(Cellule macase)
        {
            int x = macase.getX, y = macase.getY;
            if (x == taille - 1)
            {
                if (y == taille - 1) { return grille[0, 0]; }
                else return grille[0, y + 1];
            }
            else if (y == taille - 1) { return grille[x + 1, 0]; }


            return grille[x + 1, y + 1];
        }
        public Cellule VoisinSudOuest(Cellule macase)
        {
            int x = macase.getX, y = macase.getY;
            if (x == taille - 1)
            {
                if (y == 0) { return grille[0, taille - 1]; }
                else return grille[0, y - 1];
            }
            else if (y == 0) { return grille[x + 1, taille - 1]; }


            return grille[x + 1, y - 1];
        }
        public Cellule VoisinOuest(Cellule macase)
        {
            int x = macase.getX, y = macase.getY;
            if (y == 0) { return grille[x, taille - 1]; }
            return grille[x, y - 1];
        }
        public Cellule VoisinEst(Cellule macase)
        {
            int x = macase.getX, y = macase.getY;
            if (y == taille - 1) { return grille[x, 0]; }
            return grille[x, y + 1];
        }


        public int getNombreVoisinEnVie(Cellule macase)
        {
            int nbvoisin = 0;
            if (VoisinNord(macase).getEtat) { nbvoisin++; } //.getetat renvoie true ou false, donc si c'est true ça rentre dans la boucle
            if (VoisinEst(macase).getEtat) { nbvoisin++; }
            if (VoisinNordEst(macase).getEtat) { nbvoisin++; }
            if (VoisinNordOuest(macase).getEtat) { nbvoisin++; }
            if (VoisinOuest(macase).getEtat) { nbvoisin++; }
            if (VoisinSud(macase).getEtat) { nbvoisin++; }
            if (VoisinSudEst(macase).getEtat) { nbvoisin++; }
            if (VoisinSudOuest(macase).getEtat) { nbvoisin++; }
            return nbvoisin;

        }

        public Cellule JeuNiveau1(Cellule macase, int cellulesVoisines)
        {
            Cellule cellReturn = new Cellule();
            cellReturn.Clone(macase); //clone la cellule de macase

            if (cellulesVoisines == 3) { cellReturn.setEtat = true; } //==3 naissance ou survie
            if (cellulesVoisines <= 1 || cellulesVoisines >= 4) { cellReturn.setEtat = false; }

            return cellReturn;
        }

        public Cellule JeuNiveau2(Cellule macase, int cellulesVoisines) {

            Cellule cellReturn = new Cellule();
            cellReturn.Clone(macase); //clone la cellule de macase
            //chaque tour nrj + 4 age +1
            //ajouter les regels de veillesse et d'energie 
            if (macase.getAge==AGE_MORT || macase.getEnergie>=ENERGIE_REPRODUCTION) {
                if (macase.getAge == 5) { macase.Reset(); }
                else if (macase.getEnergie>=ENERGIE_REPRODUCTION && macase.getAge < 5)
                {
                    if (VoisinNord(macase).getEtat == false) { VoisinNord(grille[macase.getX,macase.getY]).setEtat = true; if (macase.getEnergie >= ENERGIE_REPRODUCTION) macase.setEnergie =( macase.getEnergie - ENERGIE_REPRODUCTION); }
                    if (VoisinNordEst(macase).getEtat == false) { VoisinNord(grille[macase.getX, macase.getY]).setEtat = true; if (macase.getEnergie >= ENERGIE_REPRODUCTION) macase.setEnergie = (macase.getEnergie - ENERGIE_REPRODUCTION); }
                    if (VoisinNordOuest(macase).getEtat == false) { VoisinNord(grille[macase.getX, macase.getY]).setEtat = true; if (macase.getEnergie >= ENERGIE_REPRODUCTION) macase.setEnergie = (macase.getEnergie - ENERGIE_REPRODUCTION); }
                    if (VoisinSud(macase).getEtat == false) { VoisinNord(grille[macase.getX, macase.getY]).setEtat = true; if (macase.getEnergie >= ENERGIE_REPRODUCTION) macase.setEnergie = (macase.getEnergie - ENERGIE_REPRODUCTION); }
                    if (VoisinSudEst(macase).getEtat == false) { VoisinNord(grille[macase.getX, macase.getY]).setEtat = true; if (macase.getEnergie >= ENERGIE_REPRODUCTION) macase.setEnergie = (macase.getEnergie - ENERGIE_REPRODUCTION); }
                    if (VoisinSudOuest(macase).getEtat == false) { VoisinNord(grille[macase.getX, macase.getY]).setEtat = true; if (macase.getEnergie >= ENERGIE_REPRODUCTION) macase.setEnergie = (macase.getEnergie - ENERGIE_REPRODUCTION); }
                    if (VoisinOuest(macase).getEtat == false) { VoisinNord(grille[macase.getX, macase.getY]).setEtat = true; if (macase.getEnergie >= ENERGIE_REPRODUCTION) macase.setEnergie = (macase.getEnergie - ENERGIE_REPRODUCTION); }
                    if (VoisinEst(macase).getEtat == false) { VoisinNord(grille[macase.getX, macase.getY]).setEtat = true; if (macase.getEnergie >= ENERGIE_REPRODUCTION) macase.setEnergie = (macase.getEnergie - ENERGIE_REPRODUCTION); }

                }
            }
            else {
                if (cellulesVoisines == 3) { cellReturn.setEtat = true; } //==3 naissance ou survie
                if (cellulesVoisines <= 1 || cellulesVoisines >= 4) { cellReturn.setEtat = false; }
            }
            return cellReturn;
        }

        public void Clone(Grille Clonee)
        {
            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    grille[i, j].Clone(Clonee.getCell(i, j)); //clone cell de clonee dans actuel, clone fais la meme chose. 
                }
            }
        }
        public Boolean isAlive()
        {
            foreach (Cellule c in grille)
            {
                if (c.getEtat) return true;

            }
            return false;
        }
        public Boolean isChanged(Grille test)
        {
            foreach (Cellule c in grille)
            {
                if (c.isDifferent(test.getCell(c.getX, c.getY))) { return true; }
            }
            return false;
        }
        public Boolean getChanged { get { return changed; } }

        public Grille jouer(bool jeu)
        {
            Grille temp = new Grille(this.taille);
            temp.Clone(this);

            for(int i = 0; i < taille; i++) { for (int j = 0; j < taille; j++)
                {
                    if (jeu) { grille[i, j] = JeuNiveau1(temp.getCell(i, j), getNombreVoisinEnVie(temp.getCell(i, j))); }
                   else  grille[i, j] = JeuNiveau2(temp.getCell(i, j), getNombreVoisinEnVie(temp.getCell(i, j)));
                } }
            if (!this.isChanged(temp)) { changed = false; }
            return this;

            

        }
    }
}

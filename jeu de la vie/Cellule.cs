using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeu_de_la_vie
{
    class Cellule
    {
        private int x;
        private int y;
        private Boolean etat;
        private int Age =0;
        private int Energie=1;


        public Cellule(int x, int y)
        {
            this.x = x;
            this.y = y;
            etat = false;
        }
        public Cellule(int x, int y,Boolean etat)
        {
            this.x = x;
            this.y = y;
            this.etat = etat;
        }
        public Cellule() { x = -1;y = -1;etat = false; }

        public int getX { get { return x; } }
        public int getY { get { return y; } }
        public int getAge { get { return Age; } }
        public int getEnergie { get { return Energie; } }
        public bool getEtat { get { return etat; } }
        public bool setEtat { set { etat = value; } }
        public int setEnergie { set { Energie = value; } }

        public void Clone(Cellule myCell)
        {
            x = myCell.getX;
            y = myCell.getY;
            etat = myCell.getEtat;
        }

        public override string ToString()
        {
            string phrase = string.Format("la cellule en position {0} ; {1} est ",this.x,this.y);
            if (this.etat) { phrase += "vivante"; } else phrase += "morte";

            return phrase;
        }

        public void Affiche()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            string str = "  ";
            if (etat) {Console.BackgroundColor= ConsoleColor.Red; str = "  "; }
            Console.Write(str);
        }

       public void Reset() { Age = 0;Energie = 1;etat = false; }

        public bool isDifferent(Cellule cellTest) { if (cellTest.getEtat != this.getEtat) { return true; }return false; }
    }
}

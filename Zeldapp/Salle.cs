using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeldapp
{
    class Salle
    {

        //Les salles seront qualifiées par une lettre et un numéro (A0 pour la salle de départ)
        private int letter; //Lettre de la salle
        private int number; //Numéro de la salle
        private Key myKey = null;

        //Booléen qui vont gérer si il peut aller au Nord, Sud, Est ou Ouest
        private bool isNorthOut, isSouthOut, isEastOut, isWeastOut;

        //Création des orientations des salles (N, E, S, W)
        bool[,] mySalles = {
            { true, true, false, false }, //Orientations de la salle A0 00
            { true, false, true, false }, //A1 01
            { false, true, true, false }, //A2 02 
            { false, false, false, false }, //A3 (elle n'existe pas d'ou les falses partout) 03
            { false, true, false, false }, //A4 (Salle du BOSS) 04
            { false, true, false, true }, //B0 10
            { false, false, false, false }, //B1 (n'existe pas) 11
            { true, true, false, true }, //B2 12
            { true, false, true, false }, //B3 13
            { false, false, true, true }, //B4 14
            { true, false, false, true }, //C0 20
            { true, true, true, false }, //C1 21
            { false, false, true, true }, //C2 22
            { false, false, false, false }, //C3 (n'exite pas) 23
            { false, false, false, false }, //C4 (n'exite pas) 24
            { false, false, false, false }, //D0 (n'exite pas) 30
            { false, false, false, true } //D1 (Salle de la KEY) 31
        };

        internal bool HasKey()
        {
            return !(myKey == null);
        }

        public Monster RoomMonster { get; internal set; }

        //Création de la salle en fonction d'un num et d'une lettre
        public Salle(int letter, int number)
        {
            //Attribution
            this.letter = letter;
            this.number = number;

            //AFFICHAGE DE LA MAP
            //Haut de map
            for (int i = 0; i < 120; i++)
            {
                if(i == 0)
                    Console.Write('╔'); //Corner gauche
                else if (i == 119)
                    Console.Write("╗\r"); //Corner droite
                else
                    Console.Write('═'); //Ligne
            }

            //2eme ligne à 21eme ligne de map
            for (int i = 0; i < 22; i++)
            {
                for (int y = 0; y < 120; y++)
                {
                    if (i == 10 && y == 60)
                        Console.Write('A'); //affichage du méchant
                    else if (i == 21 && y == 60)
                        Console.Write('P'); //affichage du héro
                    else if (y == 0 || y == 119)
                        Console.Write('║'); //affichage des bordures pour les cotés gauche et droite
                    else
                        Console.Write('░');
                }
            }

            //Last ligne de la map
            for (int i = 0; i < 120; i++)
            {
                if (i == 0)
                    Console.Write('╚'); //Corner gauche
                else if (i == 119)
                    Console.Write("╝\r"); //Corner droite
                else
                    Console.Write('═'); //Ligne
            }
        }

        //Méthode qui affiche le nom de la salle (A0)
        public void getSalleName()
        {
            Console.WriteLine("Salle " + this.letter.ToString() + this.number);
        }

        //Fonction qui retourne la lettre (transformée en int pour plus de facilité) de la salle
        public int getSalleLetter()
        {
            return this.letter;
        }

        //Fonction qui retourne le numéro de la salle
        public int getSalleNumber()
        {
            return this.number;
        }

        //Méthode qui affiche dans quelles directions on peut aller depuis la salle actuelle
        public void getOrientationsSalle()
        {
            
        }

        //Méthode qui va afficher une nouvelle salle
        public void changeSalle(string direction)
        {

            switch (direction)
            {
                case "North":
                    Console.WriteLine(mySalles[this.letter, 0]);
                    break;
                case "East":
                    Console.WriteLine(mySalles[this.letter, 1]);
                    break;
                case "South":
                    Console.WriteLine(mySalles[this.letter, 2]);
                    break;
                case "West":
                    Console.WriteLine(mySalles[this.letter, 3]);
                    break;
            }

            Console.WriteLine(mySalles[0, 0].ToString());
            Console.ReadLine();

        }


    }
}

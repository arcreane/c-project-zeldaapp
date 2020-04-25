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

        private bool isKeyInThisSalle; //Booléen qui gére si la clé est dans cette salle ou non
        private bool isBossInThisSalle; //Booléen qui gére si le boss est dans cette salle ou non

        public Monster RoomMonster { get; internal set; }


        //Création de la salle en fonction d'un num et d'une lettre
        public Salle(int letter, int number)
        {
            //Attribution
            this.letter = letter;
            this.number = number;

            //Par défaut, aucunes salles ne possède de clé et de boss
            this.isKeyInThisSalle = false;
            this.isBossInThisSalle = false;

        }

        //Méthode qui va afficher la salle actuelle
        public void displaySalle()
        {

            //on clear l'affichage de la console
            Console.Clear();

            //AFFICHAGE DE LA MAP
            //Haut de map
            for (int i = 0; i < 120; i++)
            {
                if (i == 0)
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
                    {
                        if(this.isKeyInThisSalle) //Si il y a la clé dans cette salle alors on l'affiche
                            Console.Write('K');
                        else if(this.isBossInThisSalle) //si il y a le boss dans cette salle alors on l'affiche
                            Console.Write('B');
                        else //Sinon on affiche le méchant 
                            Console.Write('A'); //affichage du méchant
                    }   
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

        //Méthode qui met le boss dans une certaine salle
        internal void setBoss()
        {
            this.isBossInThisSalle = true; //on change le booléen pour qu'il soit vrai
        }

        //Fonction qui retourne vrai si le boss est dans cette salle
        public bool getBoss()
        {
            return this.isBossInThisSalle;
        }

        //méthode qui va stocker la clé dans une certaine salle
        internal void setKey()
        {
            this.isKeyInThisSalle = true; //on met donc le booléen de la clé à vrai
        }

        //Fonction qui renvoit si la salle actuelle possède la clé ou non
        public bool getKey()
        {
            return this.isKeyInThisSalle;
        }

        //Méthode qui affiche le nom de la salle actuelle
        public string getSalleName()
        {
            return (this.letter.ToString() + this.number.ToString());
        }

    }
}

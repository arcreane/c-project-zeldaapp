using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeldapp
{
    class Dungeon
    {

        //Constantes qui vont gérer la taille max du donjon
        private const int maxX = 3, maxY = 3;

        int x, y; //X et Y utilisés pour les coordonées des salles

        //Booléen qui gérent si les sorties d'une salle sont possibles ou non
        private bool isNorthOpened = false, isEastOpened = false, isSouthOpened = false, isWestOpened = false;

        Random rnd = new Random(); //création du random qui gérera les nombres aléatoires pour créer ma clé et le boss

        //Créations des salles 
        public Salle[,] Rooms { get; set; } = new Salle[3, 3];

        //Constructeur du donjon
        public Dungeon()
        {
            for (int i = 0; i <maxX; i++)
            {
                for (int j = 0; j < maxY; j++)
                {
                    Rooms[i, j] = new Salle(i,j);
                }
            }

            //Lors de la création du donjon, le personnage arrive dans la salle 0,0 (en bas a gauche)
            x = 0;
            y = 0;

            //----------------GENERATION DE LA CLÉ--------------------
            //Creer 2 nombre random entre 0 et 3 pour savoir quelle salle a la clé
            int xKeyCoord = rnd.Next(maxX); //création d'un nombre aléatoire pour générer la clé (en x)
            int yKeyCoord = rnd.Next(maxY); //création d'un nombre aléatoire pour générer la clé (en y)

            Rooms[xKeyCoord, xKeyCoord].setKey(); //on set la clé dans la salle ayant pour coordonnées les valeurs générées précédement

            //----------------GENERATION DU BOSS----------------------
            //on fait également la même chose pour le boss MAIS il faut que les valeurs ne soient pas les mêmes
            int xBossCoord = 0, yBossCoord = 0;

            do
            {

                xBossCoord = rnd.Next(maxX); //Génération du boss en x
                yBossCoord = rnd.Next(maxY); //génération du boss en y

            } while (xKeyCoord != xBossCoord && yKeyCoord != yBossCoord); //tant que les valeurs de la clé et du boss sont les memes on boucle

            Rooms[xBossCoord, yBossCoord].setBoss();

        }

        //Méthode qui host le personnage
        internal void Host(Player link)
        {

            string possibleDirections = "( "; //String qui contiendra les directions possibles a emprunter quand il sera dans une salle
            int newX, newY;

            link.enterRoom(Rooms[x, y]);

            //En fonction de la salle ou il est, les sorties West et East sont condannées ou non
            if(x == 0){ //Dans le cas ou la salle est vers la gauche, la sortie West est condannée
                isWestOpened = false;
                isEastOpened = true;
            }else if(x == maxX-1){ //Dans le cas ou il est dans une salle le plus a droite, alors l'est devient condanée
                isWestOpened = true;
                isEastOpened = false;
            }else{ //Dans le cas ou il n'est dans aucun des cas du dessus alors il est possible qu'il aille a l'est et a l'ouest
                isWestOpened = true;
                isEastOpened = true;
            }
               
            //on fait pareil mais avec la sortie North et South pour Y
            if(y == 0){ //si il est dans les salles les plus en bas
                isNorthOpened = true;
                isSouthOpened = false;
            }else if(y == maxY-1){ //si il est dans les salles les plus en haut
                isNorthOpened = false;
                isSouthOpened = true;
            }else{ //si il est vers le millieu
                isNorthOpened = true;
                isSouthOpened = true;
            }

            //en fonction des sorties possible, on adapte le string qui affichera les sorties possibles
            if (isNorthOpened)
                possibleDirections += "North ";

            if (isEastOpened)
                possibleDirections += "East ";

            if (isSouthOpened)
                possibleDirections += "South ";

            if (isWestOpened)
                possibleDirections += "West ";

            possibleDirections += ")"; //on ferme la parenthèse des directions possibles

            string userDirection = ""; //String qui contiendra la réponse de l'user sur la direction a prendre
            bool isDirectionOpened = false; //booléen qui va gérer si la direction que prend l'user est bel est bien ouverte

            //on vérifie si il peut effectivement aller dans une certaine direction
            do
            {
                string[] directionOpened = possibleDirections.Split(' '); //on divise les directions possible pour en avoir un tableau

                //Affichage des infos de l'user

                //Input de l'user
                Console.WriteLine("Ou voulez-vous aller ? " + possibleDirections);
                Console.Write(">");

                userDirection = Console.ReadLine(); //on demande la direction à l'user

                //on teste pour chaque direction
                foreach(string direction in directionOpened)
                {
                    if (userDirection == direction) //si la direction qu'il a tapé est bien dans les directions possible alors on passe le booléen a true
                        isDirectionOpened = true;
                }

                

            } while (!isDirectionOpened);

            //en fonction de son choix, on augmente soit x soit y, ou on les diminue
            switch (userDirection)
            {
                case "North":
                    y++; //Si il va au nord on augmente y
                    break;

                case "East":
                    x++; //si il va a l'est on augmente x
                    break;

                case "South":
                    y--; //si il va au sud on diminue y
                    break;

                case "West":
                    x--; //si il va a l'ouest on diminue x
                    break;
            }

            //attribution des nouvelles coordonnées de x et y
            newX = x;
            newY = y;

            //on fait rentre le personnage dans le future salle avec les nouvelles coordonnées
            link.enterRoom(Rooms[newX, newY]);

        }
    }
}

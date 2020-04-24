using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeldapp
{
    class Dungeon
    {

        private const int maxX = 3, maxY = 3;

        public Salle[,] Rooms { get; set; } = new Salle[3, 3];
        int x;
        int y;
        public Dungeon()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Rooms[i, j] = new Salle(i,j);    
                }
            }
            x = 0;
            y = 0;
        //Creer 2 nombre random entre 0 et 3 pour savoir quelle salle a la clé
        //Crééer 2 autres random (différents) qui sera la salle avec le bosse
        //Ajouter dans la class salle les méthodes pour ajouter une clé et affecter un boss

        }

        internal void Host(Player zelda)
        {
//Tant que zelda n'est pas mort et qu'il n'a pas tué le boss on boucle 
           //Lister les direction disponible en fonction de x et y et de savoir si c'est la salle du bosse et que zelda a la clé
            //Demander à l'utilisateur ou il veut aller
            //en fonction de sa décision le faire changer de salle et mettre à jour les X, Y
           
            //Input de l'user
            Console.WriteLine("Ou voulez-vous aller ? (North, East, South, West)");
            Console.Write(">");
            string direction = Console.ReadLine();
              zelda.enterRoom(Rooms[x,y]);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeldapp
{
    class Player
    {

        private string name; //Nom de l'user
        private string type; //Type de classe du joueur

        private int health; //Vie du joueur
        private int attack; //Attaque du joueur

        private Key myKey = null;


        //Constructeur du player
        public Player(string name, string type)
        {

            this.name = name;
            this.type = type;

            switch (type)
            {
                case "Mage":
                    health = 10;
                    attack = 10;
                    break;

                case "Guerrier":
                    health = 15;
                    attack = 5;
                    break;
            }

        }

        internal void enterRoom(Salle salle)
        {

            //Affichage de la salle
            salle.displaySalle();

            this.fight(salle.RoomMonster);
            if(salle.HasKey())
            {
                Console.WriteLine("Congrats t'as choppé la clé");
            }

        }

        //Fonction qui renvoit la vie du joueur
        public int getHealth()
        {
            return this.health;
        }

        private void fight(Monster roomMonster)
        {
            
        }
    }
}

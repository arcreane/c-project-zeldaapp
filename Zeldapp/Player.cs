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

        private bool myKey; //booléen qui indique si le joueur possède la clé ou non


        //Constructeur du player
        public Player(string name, string type)
        {

            this.name = name;
            this.type = type;
            this.myKey = false; //il ne possède pas la clé lors de sa création

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

        }

        //méthode qui renvoit vrai si le joueur possède la clé
        public bool hasKey()
        {
            return this.myKey;
        }

        //Méthode qui est appelée lorsque le joueur trouve la clé 
        public void foundKey()
        {
            Console.WriteLine("Vous avez trouve la cle !");
            Console.WriteLine("Vous pouvez entrer dans la salle du boss !");
            this.myKey = true; //on met le booléen à true
        }

        //Fonction qui renvoit la vie du joueur
        public int getHealth()
        {
            return this.health;
        }


        //Méthode qui va afficher les stats du joueur
        public void displayStats()
        {
            //sa vie et si il possède la clé ou non
            Console.WriteLine("---Life: " + getHealth().ToString() + "--- | --- Key " + hasKey().ToString() + "---");
        }


        private void fight(Monster roomMonster)
        {
            
        }
    }
}

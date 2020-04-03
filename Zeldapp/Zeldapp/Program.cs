using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Zeldapp
{
    class Program
    {
        //Déclaration des variables qui vont empecher l'user de resize la console
        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_SIZE = 0xF000;
        public static object Integer { get; private set; }
        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        Player zelda = null; //Création momentanée du player

        static void Main(string[] args)
        {

            //Suppression du resize de la console
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero)
            {
                DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
            }


            //Affichage du menu du jeu et des instructions
            displayInstructions();

            //AFFICHAGE DE LA MAP
            //Haut de map
            for (int i = 0; i < 120; i++)
            {

                if (i == 0)
                    Console.Write('╔'); //Corner gauche
                else if(i == 119)
                    Console.Write("╗\r"); //Corner droite
                else
                    Console.Write('═'); //Ligne
            }

            //2eme ligne à 21eme ligne de map
            for (int i = 0; i < 22; i++)
            {
                for (int y = 0; y < 120; y++)
                {   
                    if(i == 10 && y == 60)
                        Console.Write('A'); //affichage du méchant
                    else if(i == 21 && y == 60)
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

            //Input de l'user
            Console.Write(">");
            Console.ReadLine();

        }


        //Méthode qui va demander les infos au joueur
        public static void displayInstructions()
        {
            //Avant d'afficher tout le bordel, on en profite pour bloquer la taille de la console
            

            //Affichage du nom de l'app
            Console.Write(@"                                         _____       _      _                                                           ");
            Console.Write(@"                                        / _  /  ___ | |  __| |  __ _  _ __   _ __                                       ");
            Console.Write(@"                                        \// /  / _ \| | / _` | / _` || '_ \ | '_ \                                      ");
            Console.Write(@"                                         / //\|  __/| || (_| || (_| || |_) || |_) |                                     ");
            Console.Write(@"                                        /____/ \___||_| \__,_| \__,_|| .__/ | .__/                                      ");
            Console.Write(@"                                                                     |_|    |_|                                         ");

            Console.WriteLine("\n\n");

            //Affichage du menu
            displayMenu();

        }


        //Méthode qui affiche le menu
        public static void displayMenu()
        {

            Console.WriteLine("1 - Play");
            Console.WriteLine("2 - Graphics Options");
            Console.WriteLine("3 - Quit");

            string userRespons = "0";

            do
            {

                //Tant qu'il ne rentre pas un chiffre valable on lui redemande
                Console.Write("\n>");
                userRespons = Console.ReadLine();

            } while (!(userRespons == "1" || userRespons == "2" || userRespons == "3")); //tant qu'il ne répond pas un des 3 cas on boucle


            //En fonction de son choix, on lance la méthode qui va bien
            switch (userRespons)
            {
                //Pour le cas ou il veut lancer la partie
                case "1":
                    chooseCharacter();
                    break;

                //Pour le cas ou il veut modifier les paramètres graphiques
                case "2":
                    
                    break;

                //Pour le cas ou il veut quitter le jeu
                case "3":
                    System.Environment.Exit(0);
                    break;
            }
           
        }

        //Méthode qui va demander a l'user le type de personnage qu'il veut
        private static void chooseCharacter()
        {
            Console.WriteLine("\nQuelle classe souhaitez-vous ?\n");
            Console.WriteLine("Mage - 10♥ / 10attack");
            Console.WriteLine("Guerrier - 15♥ / 5attack");

            string userCharacter = ""; //string qui va contenir son choix

            //Boucle do while pour éviter qu'il tape de la merde
            do
            {

                Console.Write("\n>");
                userCharacter = Console.ReadLine();

            } while (!(userCharacter == "Guerrier" || userCharacter == "Mage"));


            Player zelda = new Player("Link", userCharacter);


        }

    }
}

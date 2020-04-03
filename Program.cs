using System;

namespace Zeldapp
{
    class Program
    {
        static void Main(string[] args)
        {
            String NamePlayers;
            Console.WriteLine("Qu'elle est ton nom?");
   
            NamePlayers = Console.ReadLine();
           System.Environment.Exit(0); 

            do
                {
               
                   
                        Console.Write(" Choix de la classe : ");
                        switch (NamePlayers)
                         {
                            case "Mage":
                                break;
                            case "Guerrier":
                              break;
                        }
                    

                }
             
            while (NamePlayers == "Mage" || NamePlayers == "Guerrier");



        }

    }
}

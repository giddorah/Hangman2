using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman2
{
    class Menus
    {
        static bool mainMenuLoop;

        public static bool MainMenuLoop
        {
            get { return mainMenuLoop; }
            set { mainMenuLoop = value; }
        }

        public static void MainMenu() // Huvudmenyn till spelet. - MAIN 
        {
            //bool menuLoop = true; // En loop för att huvudmenyn ska finnas tillgänglig så länge spelaren befinner sig utanför spelet.
            mainMenuLoop = true;
            int mainMenuSwitch;
            string checkInput;
            while (mainMenuLoop)
            {
                Console.Clear(); // Rensar konsollen från tidigare kommandon.
                GUI.MainMenu(); // Visar gränssnittet för MainMenu.
                checkInput = Console.ReadLine();

                if (checkInput == "1" || checkInput == "2" || checkInput == "3")
                {
                    mainMenuSwitch = int.Parse(checkInput);
                }

                else
                {
                    mainMenuSwitch = 0;
                }

                switch (mainMenuSwitch) // Initierar en switch-meny med tre olika alternativ.
                {
                    case 1:
                        Game.Difficulty();
                        break;

                    case 2:
                        HowTo(); // Visar HowTo'n om spelaren trycker på 2.
                        break;

                    case 3:
                        Console.WriteLine("Avslutar spelet."); // Avslutar spelet om spelaren trycker på 3.
                        Program.Timer(1);
                        Environment.Exit(0);
                        break;


                    default:
                        Console.WriteLine("Använd enbart 1, 2 eller 3."); // Visas om spelaren trycker på någon annan knapp än tillåtet.
                        Console.WriteLine("Tryck enter för att gå tillbaka och försöka igen.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public static void HowTo() // Metod för att visa HowTo'n. - GUI 
        {
            while (true)
            {
                GUI.HowTo(); // Visar gränssnittet för HowTo'n.

                Console.WriteLine("Var vänlig och skriv in 1 eller 2");
                int menuSwitchHowTo;

                string checkInput = Console.ReadLine();
                int inputCheckLength = checkInput.Length;

                if (checkInput == "1" || checkInput == "2") // Kontrollfunktion för checkInput.
                {

                    menuSwitchHowTo = int.Parse(checkInput);

                }

                else
                {
                    menuSwitchHowTo = 0;

                }

                switch (menuSwitchHowTo) // Ytterligare en switchmeny men utan loop eftersom att menyn inte behöver visas igen.
                {
                    case 1:
                        // Låter spelaren återgå till mainmenu utan att ändra stringen för spelarnamn.
                        return;

                    case 2:
                        Game.Difficulty();
                        return;

                    default:
                        Console.WriteLine("Du måste ange 1 eller 2.");
                        Console.ReadLine();
                        break;

                }
            }
        }

    }
}

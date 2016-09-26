using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
                        Console.WriteLine(Language.Languages[49]); // Avslutar spelet om spelaren trycker på 3.
                        Program.Timer(1);
                        Environment.Exit(0);
                        break;


                    default:
                        Console.WriteLine(Language.Languages[20]); // Visas om spelaren trycker på någon annan knapp än tillåtet.
                        Console.WriteLine(Language.Languages[21]);
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

                Console.WriteLine(Language.Languages[18]);
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
                        Console.WriteLine(Language.Languages[19]);
                        Console.ReadLine();
                        break;

                }
            }
        }

        public static void LanguageSelecion()
        {
            while (true)
            {
                Console.WriteLine("Please select language for the game.");
                Console.WriteLine("1. English");
                Console.WriteLine("2. Norrländska");
                Console.WriteLine("3. Svenska");
                Console.Write("Val: ");

                int languageSelectionMenu = int.Parse(Console.ReadLine());

                switch (languageSelectionMenu)
                {
                    case 1: Language.Languages = File.ReadAllLines(@"c:\users\public\hangmandata\english.txt", Encoding.GetEncoding("iso-8859-1")); return;
                    case 2: Language.Languages = File.ReadAllLines(@"c:\users\public\hangmandata\northlandish.txt", Encoding.GetEncoding("iso-8859-1")); return;
                    case 3: Language.Languages = File.ReadAllLines(@"c:\users\public\hangmandata\swedish.txt", Encoding.GetEncoding("iso-8859-1")); return;

                    default: break;
                }
            }
        }
           
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman2
{
    class Program
    {
        #region Klassvariabler
        static int playerLives; // Lagrar spelarens antal liv
        static string playerName; // Lagrar spelarens namn
        static string playerGuess; // Lagrar spelaerns gissning
        static string wordGeneratorWord; // Lagrar ordgeneratorns ord
        static string wordGeneratorWordEasy;
        static string wordGeneratorWordNormal;
        static string wordGeneratorWordHard;
        static int seconds; // Ej i bruk än
        static int wordLength; // Lagrar ordets antal bokstäver
        static string guessHistory; // Lagrar tidigare gissningar
        static int numberOfGuesses; // Lagrar hur många gissningar som gjorts
        #endregion

        static void Main(string[] args)
        {
            TakeName(); // Metod för att hämta in spelarens namn!.
        }

        private static void ForDeveloper()
        {
            /*
            TakeName(); // Metod för att hämta in spelarens namn.
            MainMenu(""); // Metod för att visa startmenyn.

            HowTo(); // Metod för att visa en guide.
            
            StartGame(); // Metod för att starta spelet.
            WordGenerator(); // Metod för att generera (Hämta) ord till spelet.
            Lives(); // Metod för att visa och räkna spelarens liv.
            History(); // Metod för att samla in spelarens historiska gissningar.
            WordLength(); // Metod för att räkna ut och visa ordets antal bokstäver.
            
            GameLoop(); // Metod för att loopa spelets gränssnitt.
            GameInterface(); // Metod för att visa nödvändig information.
            Guess(); // Metod för att ta emot en gissning ifrån användaren.
            CompareWord(); // Metod för att jämföra gissning med ordet.
            CheckEndGame(); // Metod för att kolla om spelarens liv tagit slut eller spelets ord gissats.
            
            WinGame(); // Metod om man vinner spelet.
            LoseGame(); // Metod om man förlorar spelet.
            
            MainMenuGui(); // Metod för att visa gränssnittet för huvudmenyn.
            HowToGui(); // Metod för att visa gränssnittet för how to'n.*/
        } // Visar information om vilka metoder vi har att arbeta med.

        private static void TakeName() // Metod för att insamla spelarens namn.
        {
            Console.WriteLine("Skriv in namn.");
            playerName = Console.ReadLine();

            if (playerName.Length >= 3 && playerName.Length <= 25)
            { 
                Console.WriteLine("välkommen " + playerName);
                MainMenu();
            }
            else
            {
                Console.WriteLine("Skriv minst 3 bokstäver och inte mer än 25 bokstäver");
                TakeName();
            }
        }

        private static void MainMenu() // Huvudmenyn till spelet.
        {
            bool menuLoop = true; // En loop för att huvudmenyn ska finnas tillgänglig så länge spelaren befinner sig utanför spelet.
            int mainMenuSwitch;
            while (menuLoop)
            {
                Console.Clear(); // Rensar konsollen från tidigare kommandon.
                MainMenuGui(); // Visar gränssnittet för MainMenu.

                mainMenuSwitch = int.Parse(Console.ReadLine());

                /*try // Hanterar tom input.
                {
                    mainMenuSwitch = int.Parse(Console.ReadLine()); // En funktion för switch-satsen att samla in knapptryckning.
                }
                catch (Exception) // Felmeddelande som kastas om spelaren försöker gå vidare utan att välja någonting ifrån menyn.
                {
                    Console.WriteLine("Du valde ingenting. Försök igen.");
                    mainMenuSwitch = 0;

                }*/
                switch (mainMenuSwitch) // Initierar en switch-meny med tre olika alternativ.
                {
                    case 1:

                        //Difficulty();
                        //WordGenerator(); // Startar spelet om spelaren trycker på 1.
                        menuLoop = false;
                        break;

                    case 2:
                        HowTo(); // Visar HowTo'n om spelaren trycker på 2.
                        menuLoop = false;
                        break;

                    case 3:
                        Console.WriteLine("Avslutar spelet."); // Avslutar spelet om spelaren trycker på 3.
                        Console.Read();
                        menuLoop = false;
                        break;

                    default:
                        Console.WriteLine("Använd enbart 1, 2 eller 3."); // Visas om spelaren trycker på någon annan knapp än tillåtet.
                        Console.WriteLine("Tryck enter för att gå tillbaka och försöka igen.");
                        Console.ReadLine();
                        MainMenu();
                        break;
                }
            }
        }

        private static void HowTo() // Metod för att visa HowTo'n.
        {
            HowToGui(); // Visar gränssnittet för HowTo'n.
            int menuSwitchHowTo;

            menuSwitchHowTo = int.Parse(Console.ReadLine());

            /*try
            {
                menuSwitchHowTo = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Du har inte gjort något val. Tryck enter för att gå tillbaka och försöka igen.");
                menuSwitchHowTo = 0;
                Console.ReadLine();
                HowTo();
            }*/


            switch (menuSwitchHowTo) // Ytterligare en switchmeny men utan loop eftersom att menyn inte behöver visas igen.
            {
                case 1:
                    Console.WriteLine("Återvänder till MainMenu()");
                    MainMenu(); // Låter spelaren återgå till mainmenu utan att ändra stringen för spelarnamn.
                    break;

                case 2:
                    Console.WriteLine("StartGame()");
                    //Difficulty();
                    break;
            }
        }

        private static void WinGame() // Avslutar spelet beroende på hur spelaren presterat.
        {
            Console.WriteLine("Grattis. Du är awesome!.");
            Console.ReadLine();
            MainMenu();
        }

        private static void LoseGame() // Förolämpar spelaren om denne inte är så bra.
        {
            Console.WriteLine("Du... Dra.");
            Console.ReadLine();
            MainMenu();
        }

        private static void CheckEndGame() // Håller reda på om spelaren har gissat rätt ord eller om antal liv är 0.
        {
            Console.WriteLine("CheckEndGame");
        }

        private static void CompareWord() // Metod för att jämföra Guess med WordGenerator.
        {
            Console.Clear();
            numberOfGuesses++;
            if (playerGuess.Equals(wordGeneratorWord))
                WinGame();

            else if (playerLives == 0 || playerLives < 2)
                LoseGame();
            else if (playerLives < 4)
            {
                Console.WriteLine("\nDu gissade fel, försök igen!");
                playerLives--;
                
                Console.Write("\nDu har: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(playerLives);
                Console.ResetColor();
                Console.Write(" liv kvar ");
                

                Guess();
            }
            else
            {

                Console.WriteLine("\nDu gissade fel, försök igen!");
                playerLives--;
                Console.WriteLine("\nDu har: " + playerLives + " liv kvar");
                Guess();
            }
        }

        private static void Guess() // Metod för att samla in gissning från spelaren.
        {
            Console.WriteLine("\nDu har gissat på:" + guessHistory);
            WordLength();
            Console.Write("Gissa ord: ");
            playerGuess = Console.ReadLine().ToLower();
            History();
            CompareWord();
        }

        private static void GameInterface() // Visar "gränssnittet" för spelaren.
        {
            Console.WriteLine("GameInterface");
        }

        private static void GameLoop() // Loopen som spelet körs inom. Startar om efter varje gissning och uppdaterar andra metoder.
        {
            Console.WriteLine("GameLoop");
            GameInterface();
            Guess();
            CompareWord();
            CheckEndGame();
        }

        private static void WordLength() // Metod för att ta reda på nuvarande ords antal bokstäver.
        {
            wordLength = wordGeneratorWord.Length;
            Console.WriteLine("Ordet är {0} bokstäver långt.", wordLength);
        }

        private static void History() // Metod för att visa historiken över gissade ord.
        {
            if (guessHistory.Equals(""))
            {
                guessHistory += " " + playerGuess;
            }
            else guessHistory += ", " + playerGuess;
        }

        private static void Lives() // Metod för att hålla reda på antal liv.
        {
            int lives = 3;
            Console.WriteLine("Liv: {0}", lives);
        }

        private static void WordGenerator() // Metod för att välja ord från ordlistan.
        {

            Console.Clear();
            playerLives = 4;
            wordGeneratorWordEasy = "kungen".ToLower();
            wordGeneratorWordNormal = "askungen".ToLower();
            wordGeneratorWordHard = "kontinental".ToLower();
            numberOfGuesses = 0;
            guessHistory = "";
            Guess();
        }
        

        private static void StartGame() // Metod för att starta spelet.
        {
            Console.Clear();
            Console.WriteLine("Spel startat");
            WordGenerator();
            Lives();
            History();
            WordLength();
            Console.ReadLine();
        }

        private static void HowToGui()
        {
            Console.Clear();
            Console.WriteLine("             `..`         ");
            Console.WriteLine("            .:::`                                                  `-..         ");
            Console.WriteLine("           `.:-:`                                                  `//-         ");
            Console.WriteLine("       `````.:.:`                ````                              `/+.         ");
            Console.WriteLine("      .-//:/:/+...`````....::::////::---------:::--::..........````-/+-`        ");
            Console.WriteLine("      `---::/+/:://////:::::::--..:.``````````..---::----::::::-:/+++/::::---`  ");
            Console.WriteLine("       ``...//+s/-.......................-------------.....``....../+/:::--.-   ");
            Console.WriteLine("        ``..-.---..````````     ``  `                       ``...``:+:.```      ");
            Console.WriteLine("        ```.-.-..`                                           `````-/+-`         ");
            Console.WriteLine("         ```.--.      För att spela spelet måste du gissa ord.     ++-          ");
            Console.WriteLine("         ```.-+-`     Om du gissar fel så kommer du att förlora    //-          ");
            Console.WriteLine("         `` -/o-`     ett liv.                                     /::          ");
            Console.WriteLine("             /o-                                                  +/-           ");
            Console.WriteLine("         `   :o-      Välj ett av följande:                      `++-           ");
            Console.WriteLine("         ``  /o-`     1. Återvänd till huvudmenyn                .++-           ");
            Console.WriteLine("             ++-      2. Starta spelet                         ` .++.           ");
            Console.WriteLine("            .o+-                                               ``-/+`           ");
            Console.WriteLine("            -o+-                ``                            ```-/+`           ");
            Console.WriteLine("      `````./o/:-----------::::://:::::::::::::------......-`....::+-`          ");
            Console.WriteLine("  `-:::///+oso/:+::::---------...-:..................----::::::::/:---/::--`    ");
            Console.WriteLine("   -:/o+/::oss/:.```````````````                            ``..-/+o:.-://:`    ");
            Console.WriteLine("  `-:::/:-.`/o/.````                                        ```.--++.    ``     ");
            Console.WriteLine("  `..``....`:o:.`                                             `...+/.           ");
            Console.WriteLine("            `..`                                               `..+:.           ");
            Console.WriteLine("                                                    	            `-`            ");
        } // Metod för att visa gränssnittet för How To'n

        private static void MainMenuGui()
        {
            Console.WriteLine("             `..`");
            Console.WriteLine("            .:::`                                                  `-..         ");
            Console.WriteLine("           `.:-:`                                                  `//-         ");
            Console.WriteLine("       `````.:.:`                ````                              `/+.         ");
            Console.WriteLine("      .-//:/:/+...`````....::::////::---------:::--::..........````-/+-`        ");
            Console.WriteLine("      `---::/+/:://////:::::::--..:.``````````..---::----::::::-:/+++/::::---`  ");
            Console.WriteLine("       ``...//+s/-.......................-------------.....``....../+/:::--.-   ");
            Console.WriteLine("        ``..-.---..````````     ``  `                       ``...``:+:.```      ");
            Console.WriteLine("        ```.-.-..`                                           `````-/+-`         ");
            Console.WriteLine("         ```.--.                                                   ++-          ");
            Console.Write("         ```.-+-`");

            for (int i = 0; i < 12 - playerName.Length / 2; i++)
            {
                Console.Write(" ");
            }
            Console.Write("Välkommen {0} till Hangr 0.1", playerName); // Byter ut {0} mot vad spelaren angivit i TakeName.
            if (playerName.Length % 2 == 0)
            {


                for (int i = 0; i < 13 - playerName.Length / 2; i++)
                {
                    Console.Write(" ");
                }
            }
            else
            {
                for (int i = 0; i < 13 - playerName.Length / 2 - 1; i++)
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine("//-          ");
            Console.WriteLine("         `` -/o-`                                                  /::          ");
            Console.WriteLine("         `  -:o.                                                   /::          ");
            Console.WriteLine("         `  -/o.                                                  `+:-          ");
            Console.WriteLine("            ./o.                                                  .o/-          ");
            Console.WriteLine("            `/o.         Välj något av följande:                  :o/.          ");
            Console.WriteLine("             /o-         1. Starta spel.                          /o/`          ");
            Console.WriteLine("             /o-         2. How to.                               ++:`          ");
            Console.WriteLine("             /o-         3. Avsluta spel.                         +/-           ");
            Console.WriteLine("         `   :o-                                                 `++-           ");
            Console.WriteLine("         ``  /o-`                                                .++-           ");
            Console.WriteLine("             ++-                                               ` .++.           ");
            Console.WriteLine("            .o+-                                               ``-/+`           ");
            Console.WriteLine("            -o+-                ``                            ```-/+`           ");
            Console.WriteLine("      `````./o/:-----------::::://:::::::::::::------......-`....::+-`          ");
            Console.WriteLine("  `-:::///+oso/:+::::---------...-:..................----::::::::/:---/::--`    ");
            Console.WriteLine("   -:/o+/::oss/:.```````````````                            ``..-/+o:.-://:`    ");
            Console.WriteLine("  `-:::/:-.`/o/.````                                        ```.--++.    ``     ");
            Console.WriteLine("  `..``....`:o:.`                                             `...+/.           ");
            Console.WriteLine("            `..`                                               `..+:.           ");
            Console.WriteLine("                                                    	            `-`            ");
        } // Metod för att visa gränssnittet för huvudmenyn
        
    }
}


using System;
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
        static int wordLength; // Lagrar ordets antal bokstäver
        static string guessHistory; // Lagrar tidigare gissningar
        static int numberOfGuesses; // Lagrar hur många gissningar som gjorts
        static int menuSwitchHowTo;
        static char[] maskedWord;
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
            do
            {

                Console.WriteLine("Skriv in namn.");
                playerName = Console.ReadLine();

                if (playerName.Length >= 3 && playerName.Length <= 25)
                {
                    Console.WriteLine("välkommen " + playerName);
                    MainMenu();
                    return;
                }
                else
                {
                    Console.WriteLine("Skriv minst 3 bokstäver och inte mer än 25 bokstäver");
                   
                } 
            } while (true);
        }

        private static void MainMenu() // Huvudmenyn till spelet.
        {
            //bool menuLoop = true; // En loop för att huvudmenyn ska finnas tillgänglig så länge spelaren befinner sig utanför spelet.
            int mainMenuSwitch;
            string checkInput;
            while (true)
            {
                Console.Clear(); // Rensar konsollen från tidigare kommandon.
                MainMenuGui(); // Visar gränssnittet för MainMenu.
                checkInput = Console.ReadLine();

                if (checkInput.Equals("1") || checkInput.Equals("2") || checkInput.Equals("3"))
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
                        Difficulty();
                        break;

                    case 2:
                        HowTo(); // Visar HowTo'n om spelaren trycker på 2.
                        break;

                    case 3:
                        Console.WriteLine("Avslutar spelet."); // Avslutar spelet om spelaren trycker på 3.
                        Timer(1);
                        //Environment.Exit(0);
                        //menuLoop = false;
                        return;
                        //break;

                    default:
                        Console.WriteLine("Använd enbart 1, 2 eller 3."); // Visas om spelaren trycker på någon annan knapp än tillåtet.
                        Console.WriteLine("Tryck enter för att gå tillbaka och försöka igen.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static void Difficulty()
        {
            while (true)
            {
                int difficultySwitch;

                Console.WriteLine("Svårighetsgrad");
                Console.WriteLine("Vill du köra på lätt nivå? Tryck 1:");
                Console.WriteLine("Vill du köra på medel nivå? Tryck 2:");
                Console.WriteLine("Vill du köra på svår nivå? Tryck 3:");

                string[] easy = new string[1];
                string[] medium = new string[1];
                string[] hard = new string[1];

                easy[0] = "kungen";
                medium[0] = "askungen";
                hard[0] = "kontinental";

                string checkInput = Console.ReadLine();
                int inputCheckLength = checkInput.Length;

                if (checkInput.Equals("1") || checkInput.Equals("2") || checkInput.Equals("3"))
                {

                    difficultySwitch = int.Parse(checkInput);

                }

                else
                {
                    difficultySwitch = 0;

                }

                switch (difficultySwitch)
                {
                    case 1:
                        Console.WriteLine("Du valde lätt nivå!");
                        wordGeneratorWord = easy[0];
                        WordGenerator();
                       
                        return;
                    case 2:
                        Console.WriteLine("Du valde medel nivå");
                        wordGeneratorWord = medium[0];
                        WordGenerator();
                        return;
                    case 3:
                        Console.WriteLine("Du valde svår nivå");
                        wordGeneratorWord = hard[0];
                        WordGenerator();
                        return;
                    default:
                        Console.WriteLine("Var vänlig och skriv in 1,2 eller 3");
                        break;
                }
            }
        }

        private static void WordGenerator() // Metod för att välja ord från ordlistan.
        {

            Console.Clear();
            playerLives = 4;
            numberOfGuesses = 0;
            guessHistory = "";
            wordLength = wordGeneratorWord.Length;
            maskedWord = new char[wordLength];
            
            for (int i = 0; i < wordLength; i++)

            {
                
                maskedWord[i] = '_';

            }
            GameLoop();
        }

        private static void GameLoop() // Loopen som spelet körs inom. Startar om efter varje gissning och uppdaterar andra metoder.
        {
            while (true)
            {

                GameInterface();
                Guess();
                History();


                //metoden CompareWord Anropas och om den är sann och då går man ur loopen.
                //den är sann om man har vunnit eller förlorat som kollas i metoden
                if (CompareWord()) return;  
                
            }
        }

        private static void GameInterface() // Visar "gränssnittet" för spelaren.
        {
            Console.WriteLine("\nDu har gissat på:" + guessHistory);
            WordLength();
        }

        private static void WordLength() // Metod för att ta reda på nuvarande ords antal bokstäver.
        {
            wordLength = wordGeneratorWord.Length;
            Console.Write("Ordet är: ");
            for (int i = 0; i < wordLength; i++)
               
            {
                Console.Write(maskedWord[i]);

            }

            Console.WriteLine("");
        }

        private static void Guess() // Metod för att samla in gissning från spelaren.
        {

            Console.Write("Gissa ord: ");
            playerGuess = Console.ReadLine().ToLower();
        }

        private static void History() // Metod för att visa historiken över gissade ord.
        {
            if (guessHistory.Equals(""))
            {
                guessHistory += " " + playerGuess;
            }
            else guessHistory += ", " + playerGuess;
        }     

        private static bool CompareWord() // Metod för att jämföra Guess med WordGenerator.
        {
            bool changeMade = false;

            for (int i = 0; i < wordLength; i++)
            {
                if (playerGuess[0].Equals(wordGeneratorWord[i]))
                {
                    maskedWord[i] = playerGuess[0];
                    changeMade = true;
                }
                
            }
            if (changeMade == false)
            {
                playerLives--;
            }

            Console.Clear();
            numberOfGuesses++;
            if (playerGuess.Equals(wordGeneratorWord))
            {
                WinGame();
                return true;
            }

            playerLives--;

            if (playerLives == 0)
            {
                LoseGame();
                return true;
            }

            if (playerLives < 4)
            {
                Console.WriteLine("\nDu gissade fel, försök igen!");
                

                Console.Write("\nDu har: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(playerLives);
                Console.ResetColor();
                Console.Write(" liv kvar ");
                Console.Beep();
                Console.Beep();
                Console.Beep();

            }
            else
            {

                Console.WriteLine("\nDu gissade fel, försök igen!");
                Console.WriteLine("\nDu har: " + playerLives + " liv kvar");

            }

            return false;
        }

        private static void WinGame() // Avslutar spelet beroende på hur spelaren presterat.
        {
            Console.WriteLine("Grattis. Du är awesome!.");
            Console.ReadLine();

        }

        private static void LoseGame() // Förolämpar spelaren om denne inte är så bra.
        {
            Console.WriteLine(" ________________ ");
            Console.WriteLine(" |  | ");
            Console.WriteLine(" | ( ) ");
            Console.WriteLine(" | /|\\ ");
            Console.WriteLine(" |  | ");
            Console.WriteLine(" | / \\ ");
            Console.WriteLine(" | ");
            Console.WriteLine(" | ");
            Console.WriteLine(" |_______ ");
            Console.WriteLine("Du... Dra.");
            Console.ReadLine();

        }

        private static void HowTo() // Metod för att visa HowTo'n.
        {
            while (true)
            {
                HowToGui(); // Visar gränssnittet för HowTo'n.
                Console.WriteLine("Var vänlig och skriv in 1 eller 2");
                int menuSwitchHowTo;

                string checkInput = Console.ReadLine();
                int inputCheckLength = checkInput.Length;

                if (checkInput.Equals("1") || checkInput.Equals("2"))
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
                        Difficulty();
                        return;
                }
            }
        }

        //Anropas aldrig
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
        
        //anropas aldrig
        private static void Lives() // Metod för att hålla reda på antal liv.
        {
            int lives = 3;
            Console.WriteLine("Liv: {0}", lives);
        }

        //används aldrig
        private static void CheckEndGame() // Håller reda på om spelaren har gissat rätt ord eller om antal liv är 0.
        {

        }

        private static void HowToGui() // Metod för att visa gränssnittet för How To'n
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
            Console.WriteLine("         ```.--.      För att spela spelet måste du                ++-          ");
            Console.WriteLine("         ```.-+-`    gissa ett ord. Om du gissar fel så            //-          ");
            Console.WriteLine("         `` -/o-`     kommer du att förlora ett liv                /::          ");
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
        } 

        private static void MainMenuGui() // Metod för att visa gränssnittet för huvudmenyn
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
            Console.WriteLine("            `/o.             Välj något av följande:              :o/.          ");
            Console.WriteLine("             /o-             1. Starta spel.                      /o/`          ");
            Console.WriteLine("             /o-             2. How to.                           ++:`          ");
            Console.WriteLine("             /o-             3. Avsluta spel.                     +/-           ");
            Console.WriteLine("         `   :o-                                                 `++-           ");
            Console.WriteLine("         ``  /o-`                                                .++-           ");
            Console.WriteLine("             ++-           förra spelet tog {0} gissningar       ` .++.           ", numberOfGuesses);
            Console.WriteLine("            .o+-                                               ``-/+`           ");
            Console.WriteLine("            -o+-                ``                            ```-/+`           ");
            Console.WriteLine("      `````./o/:-----------::::://:::::::::::::------......-`....::+-`          ");
            Console.WriteLine("  `-:::///+oso/:+::::---------...-:..................----::::::::/:---/::--`    ");
            Console.WriteLine("   -:/o+/::oss/:.```````````````                            ``..-/+o:.-://:`    ");
            Console.WriteLine("  `-:::/:-.`/o/.````                                        ```.--++.    ``     ");
            Console.WriteLine("  `..``....`:o:.`                                             `...+/.           ");
            Console.WriteLine("            `..`                                               `..+:.           ");
            Console.WriteLine("                                                    	            `-`            ");
        } 

        public static void Timer(double seconds)
        {
            {
                double sec = seconds;
                var t = Task.Run(async delegate
                {
                    await Task.Delay(TimeSpan.FromSeconds(sec));
                    return;
                });
                t.Wait();

            }
        }

    }
}


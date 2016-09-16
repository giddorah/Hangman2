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

        private static void Difficulty() // En metod för att välja svårighetsgrad.
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

                if (checkInput == "1" || checkInput == "2" || checkInput == "3")
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
                        playerLives = 10;
                        WordGenerator();

                        return;
                    case 2:
                        Console.WriteLine("Du valde medel nivå!");
                        wordGeneratorWord = medium[0];
                        playerLives = 5;
                        WordGenerator();
                        return;

                    case 3:
                        Console.WriteLine("Du valde svår nivå!");
                        wordGeneratorWord = hard[0];
                        playerLives = 2;
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

                GameInterface(); // Kör metoden för att visa ett spelgränssnitt.
                Guess(); // Kör metoden för att ta emot gissning från spelaren.
                History(); // Kör metoden för att visa historiska gissningar.


                //metoden CompareWord Anropas och om den är sann och då går man ur loopen.
                //den är sann om man har vunnit eller förlorat som kollas i metoden
                if (CompareWord() == true) return;

            }
        }

        private static void GameInterface() // Visar "gränssnittet" för spelaren.
        {
            Console.WriteLine("\nDu har gissat på:" + guessHistory);
            Console.Write("Ordet är: ");
            for (int i = 0; i < wordLength; i++) // Lägger till mellanslag i maskedWord.

            {
                Console.Write(maskedWord[i] + " ");

            }

            Console.WriteLine("");
        }

        private static void Guess() // Metod för att samla in gissning från spelaren.
        {
            bool playerGuessLoop = true; // Gör en bool till en loop för att kontrollera så att användaren skriver något.
            Console.Write("Gissa bokstav/ord: ");
            while (playerGuessLoop) // En loop för att kontrollera användarens input.
            {
                playerGuess = Console.ReadLine().ToLower(); // Gör om spelarens gissning till liten bokstav.
                if (playerGuess.Length == 0) // Om spelarens input inte innehåller någonting.
                {
                    Console.WriteLine("Du måste skriva in en gissning.");
                    Console.Write("Ange gissning: ");
                }
                else // Annars avslutas kontrolloopen.
                {
                    playerGuessLoop = false;
                }
            }

        }

        private static void History() // Metod för att visa historiken över gissade ord.
        {
            if (guessHistory == "")
            {
                guessHistory += " " + playerGuess;
            }
            else guessHistory += ", " + playerGuess;
        }

        private static bool CompareWord() // Metod för att jämföra Guess med WordGenerator.
        {
            bool changeMade = false; // Ändras till sant om en ändring sker i maskedword.

            for (int i = 0; i < wordLength; i++) // En loop för att kolla igenom playerGuess och wordGeneratorword.
            {
                if (playerGuess[0] == wordGeneratorWord[i]) // Om första bokstaven i användarens gissning är samma som wordgeneratorword på plats i.
                {
                    maskedWord[i] = playerGuess[0]; // Så sätts maskedword position i till spelarens gissning.
                    changeMade = true; // Gör så att changemade sätts till true.
                }

            }
            if (changeMade == false) // Om changemade inte är sant och inget gissat ord är rätt.
            {
                playerLives--; // Så spelaren ett liv.
            }
            Console.Clear(); // Rensar konsollen från text.

            if (changeMade == true) // Om changemade är sant
            {
                Console.WriteLine("Du gissade rätt bokstav, fortsätt så!"); // Lite uppmuntring skrivs ut.
                Console.WriteLine("\nDu har: " + playerLives + " liv kvar"); // Information om hur många liv som finns kvar visas.
            }

            int ifEqualsToWordLengthPlayerWins = 0; // Gör en integer för att lagra antal rätt gissade bokstäver.
            for (int i = 0; i < wordLength; i++)
            {
                
                if (maskedWord[i] == wordGeneratorWord[i]) // Varje gång en bokstav i wordgeneratorword matchar ett ord i maskedword så får spelaren ett poäng.
                {
                    ifEqualsToWordLengthPlayerWins++;
                }
            }
            numberOfGuesses++; // Antal gissningar ifrån spelaren går upp
            if (ifEqualsToWordLengthPlayerWins == wordLength || playerGuess == wordGeneratorWord) // Om integern är lika stor som wordlength eller om spelaren gissar på rätt ord direkt så vinner spelaren.
                {
                WinGame(); // Vinstskärm.
                return true; // Avslutar metoden med ett truevärde.
                }

            if (playerLives == 0) // Om spelarliv är 0
            {
                LoseGame(); // Förlustskärm.
                return true; // Avslutar metoden med ett truevärde.
            }

            if (playerLives < 4 && changeMade == false) // Om spelarens liv är mindre än 4 och changemade är falsk
            {
                Console.WriteLine("\nDu gissade fel, försök igen!");

                Console.Write("\nDu har: ");
                Console.ForegroundColor = ConsoleColor.Red; // Texten blir röd.
                Console.Write(playerLives);
                Console.ResetColor();
                Console.Write(" liv kvar ");
            }
            else if (playerLives >= 4 && changeMade == false) // Om spelarens liv är 4 eller över.
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
            Console.WriteLine(" | /|\\");
            Console.WriteLine(" |  |  ");
            Console.WriteLine(" | / \\");
            Console.WriteLine(" | ");
            Console.WriteLine(" | ");
            Console.WriteLine(" |_______________ ");
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
                        Difficulty();
                        return;

                    default:
                        Console.WriteLine("Du måste ange 1 eller 2.");
                        Console.ReadLine();
                        break;

                }
            }
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


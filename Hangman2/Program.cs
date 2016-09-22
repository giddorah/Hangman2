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
        public static int playerLives; // Lagrar spelarens antal liv
        static string playerGuess; // Lagrar spelaerns gissning
        static string wordGeneratorWord; // Lagrar ordgeneratorns ord
        static int wordLength; // Lagrar ordets antal bokstäver
        static string guessHistory; // Lagrar tidigare gissningar
        static bool mainMenuLoop;
        static bool takeNameLoop = true;
        public static int numberOfGuesses; // Lagrar hur många gissningar som gjorts
        static char[] maskedWord;
        public static Player player;

        #endregion

        static void Main(string[] args)
        {
            while (true)
            {
                TakeName(); // Metod för att hämta in spelarens namn!.
            } 
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
            Console.Clear();
            
            while (true)
            {
                Console.WriteLine("Skriv in namn.");
                string input = Console.ReadLine();
                player = new Player(input); 


                if (player.name.Length >= 3 && player.name.Length <= 25)
                {
                    Console.WriteLine("välkommen " + player.name);
                    MainMenu();
                    return;
                }

                else
                {
                    Console.WriteLine("Skriv minst 3 bokstäver och inte mer än 25 bokstäver");
                }

            }
        }

        private static void MainMenu() // Huvudmenyn till spelet.
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
                        Difficulty();
                        break;

                    case 2:
                        HowTo(); // Visar HowTo'n om spelaren trycker på 2.
                        break;

                    case 3:
                        Console.WriteLine("Avslutar spelet."); // Avslutar spelet om spelaren trycker på 3.
                        Timer(1);
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

        private static void Difficulty() // En metod för att välja svårighetsgrad.
        {
            while (true)
            {
                int difficultySwitch;

                Console.WriteLine("Svårighetsgrad");
                Console.WriteLine("Vill du köra på lätt nivå? Tryck 1:");
                Console.WriteLine("Vill du köra på medel nivå? Tryck 2:");
                Console.WriteLine("Vill du köra på svår nivå? Tryck 3:");

                string[] easy = new string[5];
                string[] medium = new string[5];
                string[] hard = new string[5];

                easy[0] = "kungen";
                easy[1] = "banan";
                easy[2] = "drottning";
                easy[3] = "princessan";
                easy[4] = "prinsen";
                medium[0] = "askungen";
                medium[1] = "Bahamas";
                medium[2] = "danmark";
                medium[3] = "sverige";
                medium[4] = "finland";
                hard[0] = "kontinental";
                hard[1] = "sundbyberg";
                hard[2] = "ibrahimovic";
                hard[3] = "korvstroganoff";
                hard[4] = "pax";

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
            EndGameChoices();
        }

        private static void EndGameChoices() // Om spelaren vunnit eller förlorat körs denna metod.
        {
            Console.WriteLine("Åh, du är så fin. Vad skulle du önska att du fick göra nu?");
            bool korvLoopen = true;
            while (korvLoopen)
            {
                Console.WriteLine("Vill du:");
                Console.WriteLine("1. Spela igen.");
                Console.WriteLine("2. Byta spelare.");
                Console.WriteLine("3. Avsluta spelet.");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    return;
                }
                else if (input == "2")
                {
                    mainMenuLoop = false;
                    takeNameLoop = true;
                    return;
                }
                else if (input == "3")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Fy");
                }
            }
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
            EndGameChoices();
        }

        private static void HowTo() // Metod för att visa HowTo'n.
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
                        Difficulty();
                        return;

                    default:
                        Console.WriteLine("Du måste ange 1 eller 2.");
                        Console.ReadLine();
                        break;

                }
            }
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


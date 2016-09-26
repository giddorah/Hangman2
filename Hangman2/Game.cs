using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangman2
{
    class Game
    {
        static int playerLives; // Lagrar spelarens antal liv
        static string playerGuess; // Lagrar spelaerns gissning
        static string wordGeneratorWord; // Lagrar ordgeneratorns ord
        static int wordLength; // Lagrar ordets antal bokstäver
        static string guessHistory; // Lagrar tidigare gissningar
        static int numberOfGuesses; // Lagrar hur många gissningar som gjorts
        static char[] maskedWord;
        static int levelPoint;
        static int lifePoint;

        public int LevelPoint
        {
            get { return levelPoint; }
            set { levelPoint = value; }
        }

        public int LifePoint
        {
            get { return lifePoint; }
            set { lifePoint = value; }
        }



        public static char[] MaskedWord
        {
            get { return maskedWord; }
            set { maskedWord = value; }
        }

        public int PlayerLives
        {
            get { return playerLives; }
           private set { playerLives = value; }
        }

        public static int WordLength
        {
            get { return wordLength; }
            private set { wordLength = value; }
        }

        public static int NumberOfGuesses
        {
            get { return numberOfGuesses; }
            private set { numberOfGuesses = value; }
        }

        public static string GuessHistory
        {
            get { return guessHistory; }
            private set { guessHistory = value; }
        }

        public static void Difficulty() // En metod för att välja svårighetsgrad. - GAME
        {
            while (true)
            {
                int difficultySwitch;

                Console.WriteLine("Svårighetsgrad");
                Console.WriteLine("Vill du köra på lätt nivå? Tryck 1:");
                Console.WriteLine("Vill du köra på medel nivå? Tryck 2:");
                Console.WriteLine("Vill du köra på svår nivå? Tryck 3:");

                Random random = new Random();
                string[] dictionary;


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
                        dictionary = File.ReadAllLines(@"c:\users\public\easy.txt");
                        wordGeneratorWord = dictionary[random.Next(dictionary.Length)].ToLower();
                        playerLives = 10;
                        levelPoint = 100;
                        lifePoint = 40;
                        WordGenerator();


                        return;
                    case 2:
                        Console.WriteLine("Du valde medel nivå!");
                        dictionary = File.ReadAllLines(@"c:\users\public\normal.txt");
                        wordGeneratorWord = dictionary[random.Next(dictionary.Length)].ToLower();
                        playerLives = 5;
                        levelPoint = 200;
                        lifePoint = 100;
                        WordGenerator();
                        return;

                    case 3:
                        Console.WriteLine("Du valde svår nivå!");
                        dictionary = File.ReadAllLines(@"c:\users\public\hard.txt");
                        wordGeneratorWord = dictionary[random.Next(dictionary.Length)].ToLower();
                        playerLives = 2;
                        levelPoint = 400;
                        lifePoint = 200;
                        WordGenerator();
                        return;

                    default:
                        Console.WriteLine("Var vänlig och skriv in 1,2 eller 3");
                        break;
                }
            }
        }

        static void WordGenerator() // Metod för att välja ord från ordlistan. - GAME (WORD?)
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

        static void GameLoop() // Loopen som spelet körs inom. Startar om efter varje gissning och uppdaterar andra metoder. - GAME
        {
            while (true)
            {

                GUI.GameInterface(); // Kör metoden för att visa ett spelgränssnitt.
                Guess(); // Kör metoden för att ta emot gissning från spelaren.
                History(); // Kör metoden för att visa historiska gissningar.


                //metoden CompareWord Anropas och om den är sann och då går man ur loopen.
                //den är sann om man har vunnit eller förlorat som kollas i metoden
                if (CompareWord() == true) return;

            }
        }

        static void Guess() // Metod för att samla in gissning från spelaren. - GAME
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

        static void History() // Metod för att visa historiken över gissade ord. - GAME
        {
            if (guessHistory == "")
            {
                guessHistory += " " + playerGuess;
            }
            else guessHistory += ", " + playerGuess;
        }

        static bool CompareWord() // Metod för att jämföra Guess med WordGenerator. - GAME (WORD?) 
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
                Player.Scores = levelPoint + (lifePoint * playerLives);
                GUI.WinGame(); // Vinstskärm.
                return true; // Avslutar metoden med ett truevärde.
            }

            if (playerLives == 0) // Om spelarliv är 0
            {
                Console.WriteLine("Ordet du sökte var {0}", wordGeneratorWord);
                GUI.LoseGame(); // Förlustskärm.
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

        public static void EndGameChoices() // Om spelaren vunnit eller förlorat körs denna metod. - GAME
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
                    Console.Clear();
                    Console.WriteLine("Skriv in namn.");
                    Player.Name = Console.ReadLine();
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

    }
}

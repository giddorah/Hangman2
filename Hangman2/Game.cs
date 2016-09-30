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

                Console.WriteLine(Language.Languages[22]);
                Console.WriteLine(Language.Languages[23]);
                Console.WriteLine(Language.Languages[24]);
                Console.WriteLine(Language.Languages[25]);

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
                        Console.WriteLine(Language.Languages[46]);
                        dictionary = File.ReadAllLines(FilesGenerator.PathString + @"\easy.txt");
                        wordGeneratorWord = dictionary[random.Next(dictionary.Length)].ToLower();
                        playerLives = 10;
                        levelPoint = 100;
                        lifePoint = 40;
                        WordGenerator();


                        return;
                    case 2:
                        Console.WriteLine(Language.Languages[47]);
                        dictionary = File.ReadAllLines(FilesGenerator.PathString + @"\normal.txt");
                        wordGeneratorWord = dictionary[random.Next(dictionary.Length)].ToLower();
                        playerLives = 5;
                        levelPoint = 200;
                        lifePoint = 100;
                        WordGenerator();
                        return;

                    case 3:
                        Console.WriteLine(Language.Languages[48]);
                        dictionary = File.ReadAllLines(FilesGenerator.PathString + @"\hard.txt");
                        wordGeneratorWord = dictionary[random.Next(dictionary.Length)].ToLower();
                        playerLives = 2;
                        levelPoint = 400;
                        lifePoint = 200;
                        WordGenerator();
                        return;

                    default:
                        Console.WriteLine(Language.Languages[18]);
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
            Console.Write(Language.Languages[29]);
            while (playerGuessLoop) // En loop för att kontrollera användarens input.
            {
                playerGuess = Console.ReadLine().ToLower(); // Gör om spelarens gissning till liten bokstav.
                if (playerGuess.Length == 0) // Om spelarens input inte innehåller någonting.
                {
                    Console.WriteLine(Language.Languages[30]);
                    Console.Write(Language.Languages[31]);
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
                if (playerGuess[0] == wordGeneratorWord[i] && playerGuess.Length == 1) // Om första bokstaven i användarens gissning är samma som wordgeneratorword på plats i.
                {
                    maskedWord[i] = playerGuess[0]; // Så sätts maskedword position i till spelarens gissning.
                    changeMade = true; // Gör så att changemade sätts till true.
                }

            }
            
            Console.Clear(); // Rensar konsollen från text.

            if (changeMade == true) // Om changemade är sant
            {
                Console.WriteLine(Language.Languages[35]); // Lite uppmuntring skrivs ut.
                Console.WriteLine("{0} {1} {2}", Language.Languages[33], playerLives, Language.Languages[34]); // Information om hur många liv som finns kvar visas.
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
                Player.Score = levelPoint + (lifePoint * playerLives);
                GUI.WinGame(); // Vinstskärm.
                return true; // Avslutar metoden med ett truevärde.

            }

            if (changeMade == false) // Om changemade inte är sant och inget gissat ord är rätt.
            {
                playerLives--; // Så spelaren ett liv.
            }

            if (playerLives == 0) // Om spelarliv är 0
            {
                Console.WriteLine("{0} {1}", Language.Languages[36], wordGeneratorWord);
                GUI.LoseGame(); // Förlustskärm.
                return true; // Avslutar metoden med ett truevärde.
            }

            if (playerLives < 4 && changeMade == false) // Om spelarens liv är mindre än 4 och changemade är falsk
            {
                Console.WriteLine(Language.Languages[32]);

                Console.Write(Language.Languages[33]);
                Console.ForegroundColor = ConsoleColor.Red; // Texten blir röd.
                Console.Write(playerLives);
                Console.ResetColor();
                Console.WriteLine(Language.Languages[34]);
            }
            else if (playerLives >= 4 && changeMade == false) // Om spelarens liv är 4 eller över.
            {

                Console.WriteLine(Language.Languages[32]);
                Console.WriteLine("{0} {1} {2}", Language.Languages[33], playerLives, Language.Languages[34]);

            }

            return false;
        }

        public static void EndGameChoices() // Om spelaren vunnit eller förlorat körs denna metod. - GAME
        {
            
            Console.WriteLine(Language.Languages[38]);
            bool korvLoopen = true;
            while (korvLoopen)
            {
                Console.WriteLine(Language.Languages[39]);
                Console.WriteLine(Language.Languages[40]);
                Console.WriteLine(Language.Languages[41]);
                Console.WriteLine(Language.Languages[50]);
                Console.WriteLine(Language.Languages[42]);
                string input = Console.ReadLine();

                if (input == "1")
                {
                    return;
                }
                else if (input == "2")
                {
                    Console.Clear();
                    Console.WriteLine(Language.Languages[0]);
                    Player.Name = Console.ReadLine();
                    return;
                }
                else if (input == "3")
                {
                    Console.Clear();
                    GUI.ShowHighScoreList();
                    return;
                }
                else if (input == "4")
                {
                    GUI.ByeBye();
                    Environment.Exit(3);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(Language.Languages[43]);
                }
            }
        }

    }
}

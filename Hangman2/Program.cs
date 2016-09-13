using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman2
{
    class Program
    {
        static int playerLives;
        static string playerName;
        static string playerGuess;
        static string wordGeneratorWord;
        static int seconds;
        int wordLength;


        static void Main(string[] args)
        {

            //string playerName = "";
            //MainMenu(""); // Metod för att visa startmenyn.
            TakeName(playerName); // Metod för att hämta in spelarens namn.
            /*HowTo(); // Metod för att visa en guide.
            
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
            
            EndGame(); // Metod för att avsluta spelet.
            */

            //Console.ReadLine();

        }
        private static void TakeName(string playerName) // Metod för att insamla spelarens namn.
        {
            Console.WriteLine("Skriv in namn.");
            playerName = Console.ReadLine();
            MainMenu(playerName);
        }


        private static void MainMenu(string playerName) // Huvudmenyn till spelet.
        {
            int menuLoop = 1; // En loop för att huvudmenyn ska finnas tillgänglig så länge spelaren befinner sig utanför spelet.
            while (menuLoop == 1)
            {

                Console.Clear(); // Rensar konsollen från tidigare kommandon.
                Console.WriteLine("Välkommen {0} till Hangr 0.1", playerName); // Byter ut {0} mot vad spelaren angivit i TakeName.
                Console.WriteLine(" ");
                Console.WriteLine("Välj något av följande:");
                Console.WriteLine("1. Starta spel.");
                Console.WriteLine("2. How to.");
                Console.WriteLine("3. Avsluta spel.");

                // ------------ Switch-meny. Ska ej användas innan vi gått igenom den. ---------------
                int mainMenuSwitch = int.Parse(Console.ReadLine()); // En funktion för switch-satsen att samla in knapptryckning.
                switch (mainMenuSwitch) // Initierar en switch-meny med tre olika alternativ.
                {
                    case 1:
                        WordGenerator(); // Startar spelet om spelaren trycker på 1.
                        menuLoop = 0;
                        break;

                    case 2:
                        HowTo(playerName); // Visar HowTo'n om spelaren trycker på 2.
                        menuLoop = 0;
                        break;

                    case 3:
                        Console.WriteLine("Avslutar spelet."); // Avslutar spelet om spelaren trycker på 3.
                        Console.Read();
                        menuLoop = 0;
                        break;

                    default:
                        Console.WriteLine("Only use 1, 2 or 3."); // Visas om spelaren trycker på någon annan knapp än tillåtet.
                        Console.WriteLine("Återvänder till huvudmenyn. Tryck på enter.");
                        Console.ReadLine();
                        break;
                        
                }
            }
        }

        private static void HowTo(string playerName) // Metod för att visa HowTo'n.
        {
            Console.Clear();
            Console.WriteLine("Visa howto..");
            Console.WriteLine("1. Återvänd till MainMenu()");
            Console.WriteLine("2. StartGame()");
            int menuSwitchHowTo = int.Parse(Console.ReadLine());
        
            switch (menuSwitchHowTo) // Ytterligare en switchmeny men utan loop eftersom att menyn inte behöver visas igen.
            {
                case 1:
                    Console.WriteLine("Återvänder till MainMenu()");
                    MainMenu(playerName); // Låter spelaren återgå till mainmenu utan att ändra stringen för spelarnamn.
                    break;

                case 2:
                    Console.WriteLine("StartGame()");
                    WordGenerator();
                    break;
            } 
        }



        private static void WinGame() // Avslutar spelet beroende på hur spelaren presterat.
        {
            Console.WriteLine("Congratulations. You won and you are awesome.");
            Console.ReadLine();

        }

        private static void LoseGame()
        {
            Console.WriteLine("Too bad, you lost.");
            Console.ReadLine();
            MainMenu(playerName);
        }

        private static void CheckEndGame() // Håller reda på om spelaren har gissat rätt ord eller om antal liv är 0.
        {
            Console.WriteLine("CheckEndGame");
        }

        private static void CompareWord() // Metod för att jämföra Guess med WordGenerator.
        {
            if (playerGuess.Equals(wordGeneratorWord))
            
                WinGame();
            
            else Guess();

            
        }

        private static void Guess() // Metod för att samla in gissning från spelaren.
        {
            Console.WriteLine("Guess Word: ");
            WordLength();
            playerGuess = Console.ReadLine().ToLower();
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
             //Console.WriteLine("WordLength");

             int wordLength = wordGeneratorWord.Length;

        }

        private static void History() // Metod för att visa historiken över gissade ord.
        {
            Console.WriteLine("History");
        }

        private static void Lives() // Metod för att hålla reda på antal liv.
        {
            int lives = 3;
            Console.WriteLine("Liv: {0}", lives);
        }

        private static void WordGenerator() // Metod för att välja ord från ordlistan.
        {
            wordGeneratorWord = "johan";
            Guess();
        }

        private static void StartGame() // Metod för att starta spelet.
        {
            Console.Clear();
            Console.WriteLine("Game started");
            WordGenerator();
            Lives();
            History();
            WordLength();
            Console.ReadLine();
        }
        }
    }


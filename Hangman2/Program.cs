﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman2
{
    class Program
    {
        static int playerLives; // Lagrar spelarens antal liv
        static string playerName; // Lagrar spelarens namn
        static string playerGuess; // Lagrar spelaerns gissning
        static string wordGeneratorWord; // Lagrar ordgeneratorns ord
        static int seconds; // Ej i bruk än
        static int wordLength; // Lagrar ordets antal bokstäver
        static string guessHistory; // Lagrar tidigare gissningar
        static int numberOfGuesses; // Lagrar hur många gissningar som gjorts


        static void Main(string[] args)
        {

            //string playerName = "";
            //MainMenu(""); // Metod för att visa startmenyn.
            TakeName(); // Metod för att hämta in spelarens namn.
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
            
            WinGame(); // Metod om man vinner spelet.
            LoseGame(); // Metod om man förlorar spelet.
            */

            //Console.ReadLine();

        }
        private static void TakeName() // Metod för att insamla spelarens namn.
        {
            Console.WriteLine("Skriv in namn.");
            playerName = Console.ReadLine();
            MainMenu();
        }


        private static void MainMenu() // Huvudmenyn till spelet.
        {
            int menuLoop = 1; // En loop för att huvudmenyn ska finnas tillgänglig så länge spelaren befinner sig utanför spelet.
            while (menuLoop == 1)
            {
                Console.Clear(); // Rensar konsollen från tidigare kommandon.
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("|                                                |");
                Console.Write("|");
                for (int i = 0; i < 10-playerName.Length/2; i++)
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
                    for (int i = 0; i < 13 - playerName.Length / 2-1; i++)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("|");
                Console.WriteLine("|                                                |");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("          Föregående spel tog {0} försök.         ", numberOfGuesses);
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("| Välj något av följande:                        |");
                Console.WriteLine("| 1. Starta spel.                                |");
                Console.WriteLine("| 2. How to.                                     |");
                Console.WriteLine("| 3. Avsluta spel.                               |");
                Console.WriteLine("--------------------------------------------------");

                // ------------ Switch-meny. Ska ej användas innan vi gått igenom den. ---------------
                int mainMenuSwitch = int.Parse(Console.ReadLine()); // En funktion för switch-satsen att samla in knapptryckning.
                switch (mainMenuSwitch) // Initierar en switch-meny med tre olika alternativ.
                {
                    case 1:
                        
                        WordGenerator(); // Startar spelet om spelaren trycker på 1.
                        menuLoop = 0;
                        
                        break;

                    case 2:
                        HowTo(); // Visar HowTo'n om spelaren trycker på 2.
                        menuLoop = 0;
                        break;

                    case 3:
                        Console.WriteLine("| Avslutar spelet.                               |"); // Avslutar spelet om spelaren trycker på 3.
                        Console.WriteLine("--------------------------------------------------");
                        Console.Read();
                        menuLoop = 0;
                        break;

                    default:
                        Console.WriteLine("| Använd enbart 1, 2 eller 3.                    |"); // Visas om spelaren trycker på någon annan knapp än tillåtet.
                        Console.WriteLine("| Återvänder till huvudmenyn.                    |");
                        Console.WriteLine("--------------------------------------------------");
                        Console.ReadLine();
                        break;    
                }
            }
        }

        private static void HowTo() // Metod för att visa HowTo'n.
        {
            Console.Clear();
            Console.WriteLine("------------------HOW TO--------------------------");
            Console.WriteLine("|                                                |");
            Console.WriteLine("| För att spela spelet måste du gissa ord. Om du |");
            Console.WriteLine("| gissar fel så kommer du bli av med liv.        |");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("| 1. Återvänd till MainMenu()                    |");
            Console.WriteLine("| 2. StartGame()                                 |");
            Console.WriteLine("--------------------------------------------------");
            int menuSwitchHowTo = int.Parse(Console.ReadLine());
        
            switch (menuSwitchHowTo) // Ytterligare en switchmeny men utan loop eftersom att menyn inte behöver visas igen.
            {
                case 1:
                    Console.WriteLine("Återvänder till MainMenu()");
                    MainMenu(); // Låter spelaren återgå till mainmenu utan att ändra stringen för spelarnamn.
                    break;

                case 2:
                    Console.WriteLine("StartGame()");
                    WordGenerator();
                    break;
            } 
        }



        private static void WinGame() // Avslutar spelet beroende på hur spelaren presterat.
        {
            Console.WriteLine("Grattis. Du är awesome!.");
            Console.ReadLine();
            MainMenu();

        }

        private static void LoseGame()
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
            numberOfGuesses++;
            if (playerGuess.Equals(wordGeneratorWord))

                WinGame();

            else if (playerLives == 0|| playerLives<2)
                LoseGame();



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
            Console.WriteLine("Du har gissat på:" + guessHistory);
            WordLength();
            Console.WriteLine("Gissa ord: ");
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
             //Console.WriteLine("WordLength");

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

            playerLives = 4;
            wordGeneratorWord = "xylofon";
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
        }
    }


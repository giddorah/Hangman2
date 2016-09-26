﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman2
{
    class GUI
    {

        public static void MainMenu() // Metod för att visa gränssnittet för huvudmenyn
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

            for (int i = 0; i < 12 - Player.Name.Length / 2; i++)
            {
                Console.Write(" ");
            }
            Console.Write("{0} {1} {2}", Language.Languages[1], Player.Name, Language.Languages[2]); // Byter ut {0} mot vad spelaren angivit i TakeName.
            if (Player.Name.Length % 2 == 0)
            {

                for (int i = 0; i < 13 - Player.Name.Length / 2; i++)
                {
                    Console.Write(" ");
                }
            }
            else
            {
                for (int i = 0; i < 13 - Player.Name.Length / 2 - 1; i++)
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine("//-          ");
            Console.WriteLine("         `` -/o-`                                                  /::          ");
            Console.WriteLine("         `  -:o.                                                   /::          ");
            Console.WriteLine("         `  -/o.                                                  `+:-          ");
            Console.WriteLine("            ./o.                                                  .o/-          ");
            Console.WriteLine("            `/o.             {0}              :o/.          ", Language.Languages[3]);
            Console.WriteLine("             /o-             {0}                      /o/`          ", Language.Languages[4]);
            Console.WriteLine("             /o-             {0}                           ++:`          ", Language.Languages[5]);
            Console.WriteLine("             /o-             {0}                     +/-           ", Language.Languages[6]);
            Console.WriteLine("         `   :o-                                                 `++-           ");
            Console.WriteLine("         ``  /o-`                                                .++-           ");
            Console.WriteLine("             ++-           {0} {1} {2}       ` .++.           ", Language.Languages[7], Game.NumberOfGuesses, Language.Languages[8]);
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

        public static void HowTo() // Metod för att visa gränssnittet för How To'n
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
            Console.WriteLine("         ```.--.      {0}                  ++-          ", Language.Languages[9]);
            Console.WriteLine("         ```.-+-`     {0}          //-          ", Language.Languages[10]);
            Console.WriteLine("         `` -/o-`     {0}      /::          ", Language.Languages[11]);
            Console.WriteLine("             /o-      {0}   +/-           ", Language.Languages[12]);
            Console.WriteLine("             /o-      {0}             +/-           ", Language.Languages[13]);
            Console.WriteLine("             /o-      {0}               +/-           ", Language.Languages[14]);
            Console.WriteLine("             /o-                                                  +/-           ");
            Console.WriteLine("         `   :o-      {0}                      `++-           ", Language.Languages[15]);
            Console.WriteLine("         ``  /o-`     {0}                .++-           ", Language.Languages[16]);
            Console.WriteLine("             ++-      {0}                         ` .++.           ", Language.Languages[17]);
            Console.WriteLine("            .o+-                                               ``-/+`           ");
            Console.WriteLine("            -o+-                ``                            ```-/+`           ");
            Console.WriteLine("      `````./o/:-----------::::://:::::::::::::------......-`....::+-`          ");
            Console.WriteLine("  `-:::///+oso/:+::::---------...-:..................----::::::::/:---/::--`    ");
            Console.WriteLine("   -:/o+/::oss/:.```````````````                            ``..-/+o:.-://:`    ");
            Console.WriteLine("  `-:::/:-.`/o/.````                                        ```.--++.    ``     ");
            Console.WriteLine("  `..``....`:o:.`                                             `...+/.           ");
            Console.WriteLine("            `..`                                               `..+:.           ");
            Console.WriteLine("                                                    	            `-`            ");
            return;

        }

        public static void GameInterface() // Visar "gränssnittet" för spelaren. - GAME
        {
            Console.WriteLine("{0} {1}", Language.Languages[27], Game.GuessHistory);
            Console.Write(Language.Languages[28]);
            for (int i = 0; i < Game.WordLength; i++) // Lägger till mellanslag i maskedWord.
            {
                Console.Write(Game.MaskedWord[i] + " ");

            }

            Console.WriteLine("");
        }

        public static void WinGame() // Avslutar spelet beroende på hur spelaren presterat. - GAME
        {
            Console.WriteLine("{0} {1} ", Language.Languages[44], Player.Scores);
            Game.EndGameChoices();
        }

        public static void LoseGame() // Förolämpar spelaren om denne inte är så bra. - GUI
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
            Console.WriteLine(Language.Languages[37]);
            Game.EndGameChoices();
        }
    }
}

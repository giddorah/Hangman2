using System;
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
            Console.Write("Välkommen {0} till Hangr 0.1", Player.Name); // Byter ut {0} mot vad spelaren angivit i TakeName.
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
            Console.WriteLine("            `/o.             Välj något av följande:              :o/.          ");
            Console.WriteLine("             /o-             1. Starta spel.                      /o/`          ");
            Console.WriteLine("             /o-             2. How to.                           ++:`          ");
            Console.WriteLine("             /o-             3. Avsluta spel.                     +/-           ");
            Console.WriteLine("         `   :o-                                                 `++-           ");
            Console.WriteLine("         ``  /o-`                                                .++-           ");
            Console.WriteLine("             ++-           förra spelet tog {0} gissningar       ` .++.           ", Game.NumberOfGuesses);
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
            Console.WriteLine("         ```.--.      För att spela spelet ska du                  ++-          ");
            Console.WriteLine("         ```.-+-`     gissa antingen på ord eller bokstav          //-          ");
            Console.WriteLine("         `` -/o-`     om du gissar fel blir du av med ett liv      /::          ");
            Console.WriteLine("             /o-      men om du gissar rätt så behåller du liv.   +/-           ");
            Console.WriteLine("             /o-      Antal liv bestäms genom villken             +/-           ");
            Console.WriteLine("             /o-      svårighetsgrad som man väljer               +/-           ");
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
            return;

        }

        public static void GameInterface() // Visar "gränssnittet" för spelaren. - GAME
        {
            Console.WriteLine("\nDu har gissat på:" + Game.GuessHistory);
            Console.Write("Ordet är: ");
            for (int i = 0; i < Game.WordLength; i++) // Lägger till mellanslag i maskedWord.
            {
                Console.Write(Game.MaskedWord[i] + " ");

            }

            Console.WriteLine("");
        }

        public static void WinGame() // Avslutar spelet beroende på hur spelaren presterat. - GAME
        {
            Console.WriteLine("Grattis. Du är awesome!.");
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
            Console.WriteLine("Du... Dra.");
            Game.EndGameChoices();
        }
    }
}

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

            for (int i = 0; i < 12 - Program.player.name.Length / 2; i++)
            {
                Console.Write(" ");
            }
            Console.Write("Välkommen {0} till Hangr 0.1", Program.player.name); // Byter ut {0} mot vad spelaren angivit i TakeName.
            if (Program.player.name.Length % 2 == 0)
            {

                for (int i = 0; i < 13 - Program.player.name.Length / 2; i++)
                {
                    Console.Write(" ");
                }
            }
            else
            {
                for (int i = 0; i < 13 - Program.player.name.Length / 2 - 1; i++)
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
            Console.WriteLine("             ++-           förra spelet tog {0} gissningar       ` .++.           ", Program.numberOfGuesses);
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
            return;

        }
    }
}

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
            SpacesHandlerCentered(Language.Languages[1] + " " + Player.Name + " " + Language.Languages[2], 50, 0, 0);
            Console.WriteLine("//-          ");

            Console.WriteLine("         `` -/o-`                                                  /::          ");
            Console.WriteLine("         `  -:o.                                                   /::          ");
            Console.WriteLine("         `  -/o.                                                  `+:-          ");
            Console.WriteLine("            ./o.                                                  .o/-          ");

            Console.Write("            `/o.");
            SpacesHandlerCentered(Language.Languages[3], 50, 0, 0);
            Console.WriteLine(":o/.          ");

            Console.Write("             /o-");
            SpacesHandlerLeftAligned(Language.Languages[4], Language.Languages[3], 50, 0, 0, 0, 0);
            Console.WriteLine("/o/`          ");

            Console.Write("             /o-");
            SpacesHandlerLeftAligned(Language.Languages[5], Language.Languages[3], 50, 0, 0, 0, 0);
            Console.WriteLine("++:`          ");


            Console.Write("             /o-");
            SpacesHandlerLeftAligned(Language.Languages[6], Language.Languages[3], 50, 0, 0, 0, 0);
            Console.WriteLine("+/-           ");

            Console.WriteLine("         `   :o-                                                 `++-           ");
            Console.WriteLine("         ``  /o-`                                                .++-           ");

            Console.Write("             ++-");
            SpacesHandlerCentered(Language.Languages[7] + " " + Game.NumberOfGuesses + " " + Language.Languages[8], 47, 0, 3);
            Console.WriteLine("` .++.           ");

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

            Console.Write("         ```.--.");
            SpacesHandlerLeftAligned(Language.Languages[9], Language.Languages[12], 50, 0, 1, 0, 2);   
            Console.WriteLine("++-          ");

            Console.Write("         ```.-+-`");
            SpacesHandlerLeftAligned(Language.Languages[10], Language.Languages[12], 50, 1, 1, 0, 2);
            Console.WriteLine("/-          "); 

            Console.Write("         `` -/o-`");
            SpacesHandlerLeftAligned(Language.Languages[11], Language.Languages[12], 50, 1, 1, 0, 2);
            Console.WriteLine("/::          ");

            Console.Write("             /o-");
            SpacesHandlerCentered(Language.Languages[12], 50, 0, 2);
            Console.WriteLine("+/-           ");

            Console.Write("             /o-");
            SpacesHandlerLeftAligned(Language.Languages[13], Language.Languages[12], 50, 0, 0, 0, 2);
            Console.WriteLine("+/-           ");

            Console.Write("             /o-");
            SpacesHandlerLeftAligned(Language.Languages[14], Language.Languages[12], 50, 0, 0, 0, 2);
            Console.WriteLine("+/-           ");

            Console.WriteLine("             /o-                                                  +/-           ");

            Console.Write("         `   :o-");
            SpacesHandlerLeftAligned(Language.Languages[15], Language.Languages[12], 50, 0, -1, 0, 2);
            Console.WriteLine("`++-           ");

            Console.Write("         ``  /o-`");
            SpacesHandlerLeftAligned(Language.Languages[16], Language.Languages[12], 50, 1, -1, 0, 2);
            Console.WriteLine(".++-           ");

            Console.Write("             ++-");
            SpacesHandlerLeftAligned(Language.Languages[17], Language.Languages[12], 50,0, -3, 0, 2);
            Console.WriteLine("` .++.           ");

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
            Console.Write(Language.Languages[28] + " ");
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

        private static void SpacesHandlerCentered(string text, int numberOfSpaces, int moveLeft, int moveRight)
        {
            int numberOfSpacesBeforeText = numberOfSpaces / 2 - (text.Length) / 2 - (text.Length) % 2;
            numberOfSpacesBeforeText += -moveLeft + moveRight;
            int numberOfSpacesAfterText = numberOfSpaces / 2 - (text.Length) / 2 - 2 * (text.Length) % 2;
            numberOfSpacesAfterText += moveLeft - moveRight;

            for (int i = 0; i < numberOfSpacesBeforeText; i++)
            {
                Console.Write(" ");
            }

            Console.Write(text);

            for (int i = 0; i < numberOfSpacesAfterText; i++)
            {
                Console.Write(" ");
            }

            if (numberOfSpaces % 2 == 1)
            {
                Console.Write(" ");
            }
        }

        private static void SpacesHandlerLeftAligned(string text, string LongestLineToAlignWith, int SpacesinLongestRow,
            int startComparedToLongestRow, int endComparedWithLongestRow, int moveLeft, int moveRight)
        {
            
            int numberOfSpacesBeforeText = SpacesinLongestRow / 2 - (LongestLineToAlignWith.Length) / 2 - (LongestLineToAlignWith.Length) % 2;
            numberOfSpacesBeforeText -= startComparedToLongestRow;
            numberOfSpacesBeforeText += -moveLeft + moveRight;

            int numberOfSpacesAfterText = SpacesinLongestRow / 2 - (LongestLineToAlignWith.Length) / 2 - 2 * (LongestLineToAlignWith.Length) % 2;
            numberOfSpacesAfterText += LongestLineToAlignWith.Length - text.Length + endComparedWithLongestRow;
            numberOfSpacesAfterText += moveLeft - moveRight;

            for (int i = 0; i < numberOfSpacesBeforeText; i++)
            {
                Console.Write(" ");
            }

            Console.Write(text);

            
            for (int i = 0; i < numberOfSpacesAfterText; i++)
            {
                Console.Write(" ");
            }

        }
        
    }
}

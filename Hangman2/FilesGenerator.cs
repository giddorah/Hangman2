using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangman2
{
    class FilesGenerator
    {

        public static string[] HighScore { get; set; }

        public static void FilesCreator()
        {
            string easy = "Bo" + Environment.NewLine +
                "jesus" + Environment.NewLine +
                "kalaspuffar" + Environment.NewLine +
                "korv" + Environment.NewLine +
                "kungen" + Environment.NewLine +
                "drottningen" + Environment.NewLine +
                "Prinsessa" + Environment.NewLine +
                "danskjävel" + Environment.NewLine +
                "johan" + Environment.NewLine +
                "Ludwig";
            File.WriteAllText(@"c:\users\public\easy.txt", easy);


            string normal = "ibrahimovic" + Environment.NewLine +
                "bananskal" + Environment.NewLine +
                "vatten" + Environment.NewLine +
                "betlehem" + Environment.NewLine +
                "andeluvisk" + Environment.NewLine +
                "besserwisser" + Environment.NewLine +
                "underbarn" + Environment.NewLine +
                "sjung" + Environment.NewLine +
                "zlatan" + Environment.NewLine +
                "susanna" + Environment.NewLine +
                "hyperneuroakustiskadiafragmakontravibrationer";
            File.WriteAllText(@"c:\users\public\normal.txt", normal);

            string hard = "åsar" + Environment.NewLine +
           "bör" + Environment.NewLine +
           "tår" + Environment.NewLine +
           "byn" + Environment.NewLine +
           "list" + Environment.NewLine +
           "stå" + Environment.NewLine +
           "ger" + Environment.NewLine +
           "etsa" + Environment.NewLine +
           "lina" + Environment.NewLine +
           "lira" + Environment.NewLine +
           "yr" + Environment.NewLine +
           "yxa";
            File.WriteAllText(@"c:\users\public\hard.txt", hard);
        }

        public static string[] HighScoreCreator()
        {

            try
            {
                HighScore = File.ReadAllLines(@"c:\users\public\highscore.txt");
            }
            catch (FileNotFoundException)
            {
                File.WriteAllText(@"c:\users\public\highscore.txt", "");
                HighScore = File.ReadAllLines(@"c:\users\public\highscore.txt");
            }

            return HighScore;
        }

        public static void SaveHighScore(string[] highScoreList)
        {
            File.WriteAllLines(@"c:\users\public\highscore.txt", highScoreList);
        }
    }
}

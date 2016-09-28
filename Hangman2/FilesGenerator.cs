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
        static string pathString;

        public static string PathString
        {
            get { return pathString; }
            set { pathString = value; }
        }

        static string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static string FolderName
        {
            get { return folderName; }
            private set { folderName = value; }
        }



        public static void FilesCreator()
        {
            pathString = Path.Combine(folderName, "HangManData");
            Directory.CreateDirectory(pathString); 

            LanguageStrings.Swedish();
            LanguageStrings.Northlandish();
            LanguageStrings.English();

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
            File.WriteAllText(pathString + @"\easy.txt", easy);



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
            File.WriteAllText(pathString + @"\normal.txt", normal);

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
            File.WriteAllText(pathString + @"\hard.txt", hard);
        }
    }
}

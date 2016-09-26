using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Runtime.InteropServices;


namespace Hangman2
{
    class Program
    {


        static void Main(string[] args)
        {
            FilesGenerator.FilesCreator();
            Menus.LanguageSelecion();
            Console.WriteLine(Language.Languages[0]);
            Player.NameLengthController(Console.ReadLine());
            Menus.MainMenu();
        }

        public static void Timer(double seconds)
        {
            {
                double sec = seconds;
                var t = Task.Run(async delegate
                {
                    await Task.Delay(TimeSpan.FromSeconds(sec));
                    return;
                });
                t.Wait();

            }
        }


    }
}


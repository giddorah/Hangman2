﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman2
{
    class Program
    {


        static void Main(string[] args)
        {
            FilesGenerator.FilesCreator();
            Console.WriteLine("Skriv in namn:");
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


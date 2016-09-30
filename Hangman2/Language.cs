using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangman2
{


    class Language
    {
        private static string[] language;

        public static string[] Languages
        {
            get { return language; }
            set { language = value; }
        }
    }
}

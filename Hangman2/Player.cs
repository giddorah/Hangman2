using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman2
{
    class Player
    {
        private static string name;
        public static string Name
        {
            get { return name; }
            set
            {
                if (value.Length >= 3 && value.Length < 25)
                {
                    name = value;
                    
                }

            }
        }

        public static void NameLengthController(string input)
        {
            do
            {
                if (input.Length >= 3 && input.Length < 25)
                {
                    Name = input;
                    return;
                }
                else
                {
                    Console.WriteLine("Namnet måste vara mellan 3 och 25 bokstäver.");
                    input = Console.ReadLine();
                }
            } while (true);
        }
        static int scores;

        public static int Scores
        {
            get { return scores; }
            set { scores = value; }
        }

    }
}

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

        public static void HighScore()
        {
            string[] highScore = FilesGenerator.HighScoreCreator();
            string[] names = new string[10];
            int[] score = new int[10];

            for (int i = 0; i < highScore.Length; i++)
            {
                if (i % 2 == 1)
                {
                    score[i - 1] = int.Parse(highScore[i]);
                }
                else if (i == 0)
                {
                    names[i] = highScore[i];
                }
                else
                {
                    names[i - 1] = highScore[i];
                }
            }

            string highScoreName = Name;

            for (int i = 0; i < names.Length; i++)
            {
                if (Scores > score[i])
                {
                    int tempScore = score[i];
                    score[i] = Scores;
                    Scores = tempScore;
                    string tempName = names[i];
                    names[i] = highScoreName;
                    highScoreName = tempName;

                }
            }
        }
    }
}

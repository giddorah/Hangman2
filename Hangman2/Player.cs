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

        static int score;

        public static int Score
        {
            get { return score; }
            set { score = value; }
        }

        public static void HighScore()
        {
            string highScoreName = Name;
            string[] namesList; // kommer att användas för att spara alla namn i highscore inclusive det nya på rätt plats. storlek bestämms senare
            int[] scoreList;    // kommer att användas för att spara alla scores i highscore inclusive det nya på rätt plats. storlek bestämms senare
            string[] highScoreList = FilesGenerator.HighScoreCreator(); // skapar en string array över alla tidigare highscores

            if (highScoreList.Length < 20) // om listan är mindre än 20, dvs 10 namn och 10 scores, så kommer listorna
            {
                namesList = new string[highScoreList.Length / 2 + 1];
                scoreList = new int[highScoreList.Length / 2 + 1];
            }
            else
            {
                namesList = new string[highScoreList.Length / 2];
                scoreList = new int[highScoreList.Length / 2];
            }

            for (int i = 0; i < scoreList.Length * 2; i++)
            {
                if (highScoreList.Length > i)
                {
                    if (i % 2 == 1)
                    {
                        scoreList[i / 2] = int.Parse(highScoreList[i]);
                    }

                    else
                    {
                        namesList[i / 2] = highScoreList[i];
                    }
                }

                else
                {
                    if (i % 2 == 1)
                    {
                        scoreList[i / 2] = 0;
                    }

                    else
                    {
                        namesList[i / 2] = "";
                    }
                }
            }

            for (int i = 0; i < scoreList.Length; i++)
            {

                if (Score > scoreList[i])
                {
                    int tempScore = scoreList[i];
                    scoreList[i] = Score;
                    Score = tempScore;
                    string tempName = namesList[i];
                    namesList[i] = highScoreName;
                    highScoreName = tempName;

                }

            }

            highScoreList = new string[scoreList.Length * 2];
            for (int i = 0; i < scoreList.Length * 2; i++)
            {
                if (i % 2 == 1)
                {
                    highScoreList[i] = "" + scoreList[i / 2];
                }

                else
                {
                    highScoreList[i] = namesList[i / 2];
                }
            }

            FilesGenerator.SaveHighScore(highScoreList);
        }
    }
}

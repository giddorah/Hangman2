using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman2
{
    class Player
    {
        static int score;
        public static int Score
        {
            get { return score; }
            set { score = value; }
        }

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

        public static void HighScore()
        {
            string highScoreName = Name;
            string[] namesList; // kommer att användas för att spara alla namn i highscore inclusive det nya på rätt plats. storlek bestämms senare
            int[] scoreList;    // kommer att användas för att spara alla scores i highscore inclusive det nya på rätt plats. storlek bestämms senare
            string[] highScoreList = FilesGenerator.HighScoreCreator(); // skapar en string array över alla tidigare highscores

            if (highScoreList.Length < 20) // om listan är mindre än 20, dvs 10 namn och 10 scores, så kommer listorna att att bli en större för att ta in det nya namnet och scoren som kommer då garanterat in i highscoren.
            {
                namesList = new string[highScoreList.Length / 2 + 1];
                scoreList = new int[highScoreList.Length / 2 + 1];
            }
            else // om highscorelistans längd är 20 (den kan inte bli större) så kommer listorna få storleken 10, alltså 10 namn och 10 scores. den nya scoren kommer då att läggas in på rätt plats och det lägsta i highscoren kommer åka ut.
            {
                namesList = new string[highScoreList.Length / 2];
                scoreList = new int[highScoreList.Length / 2];
            }

            //i loopen så går sparas värdena från highscorelistan till namn- och score-listorna.  
            for (int i = 0; i < scoreList.Length * 2; i++) //anledningen till att det är scorelist*2 och inte highscorelist är för att om highscore list inte är full så kommer vi vilja köra 2 gånger till (en för namn och en för score)
            {
                if (highScoreList.Length > i) // här kollas att i är innanför highscorelistans längd
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

                // om i är utanför highscorelistans längd så kommer score få värdet noll 
                //och då kommer det definitivt att bytas us mot det nya highscoren och då kommer det tomma namnet bytas ut också. 
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

            // i den här for-loopen så kommer föra genom listan tills den hittas det första vädre som det nya poängen (Score) är större än
            // då kommer Score att sparas på denna plats och det tidigare värdet kommer att sparas som Score och fortsätta genom listan så att
            // alla lägre värden förskuts med 1. samma sak händer med namn.
            for (int i = 0; i < scoreList.Length; i++)
            {
                if (Score > scoreList[i])
                {
                    int tempScore = scoreList[i]; // det tidigare scoren sparas i en temporär int
                    scoreList[i] = Score; // score sparas till den plats i listan som den ska
                    Score = tempScore; // Score blir lika med det gamla värdet så att den kan förskuta de lägre scoren.
                    string tempName = namesList[i];
                    namesList[i] = highScoreName;
                    highScoreName = tempName;

                }

            }

            //efter att alla värden har stoppats in i rätt plats så ska de sparas igen i textfilen.

            // highscore listan görs så att den är dubbelt så stor som scoreList,
            //det gör för att om den inte innehöll 10 olika namn och 10 olika score så måste den bli större för att få plats med det nya scoren och namnet.
            highScoreList = new string[scoreList.Length * 2]; 

            //denna for-loop är som den första bara i motsatt ordning 
            for (int i = 0; i < scoreList.Length * 2; i++) // här skulle man kunna använda highscorelistans längd men för att det ska vara i enlighet med de andra så är det scorelistans längd * 2:
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

            FilesGenerator.SaveHighScore(highScoreList); // Metoden SaveHighScore som anropas här sparar ner den uppdaterade listan till textfilen HighScore.txt
        }
    }
}

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
            set {
                do
                {
                    if (value.Length >= 3 && value.Length < 25)
                    {
                        name = value;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Namnet måste vara mellan 3 och 25 bokstäver.");
                        value = Console.ReadLine();
                    }
                } while (true);
                
                }
        }

       
        

        
        


    }
}

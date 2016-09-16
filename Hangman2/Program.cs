using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman2
{
    class Program
    {
        #region Klassvariabler
        static int playerLives; // Lagrar spelarens antal liv
        static string playerName; // Lagrar spelarens namn
        static string playerGuess; // Lagrar spelaerns gissning
        static string[] wordGeneratorWord; // Lagrar ordgeneratorns ord som en array av stringar
        static string theWord;  //  Lagrar ordgeneratorns ord som en string
        static int wordLength; // Lagrar ordets antal bokstäver
        static string guessHistory; // Lagrar tidigare gissningar
        static int numberOfGuesses; // Lagrar hur många gissningar som gjorts

        //en array av strings som är lika långt som wordGeneratorWord men har bara understreck i början
        //och kommer att fyllas ut med bokstäver under spelets gång
        static string[] maskedWord; 
        #endregion

        static void Main(string[] args)
        {
            TakeName(); // Metod för att hämta in spelarens namn!.
        }

        private static void ForDeveloper()
        {
            /*
            TakeName(); // Metod för att hämta in spelarens namn.
            MainMenu(""); // Metod för att visa startmenyn.

            HowTo(); // Metod för att visa en guide.
            
            StartGame(); // Metod för att starta spelet.
            WordGenerator(); // Metod för att generera (Hämta) ord till spelet.
            Lives(); // Metod för att visa och räkna spelarens liv.
            History(); // Metod för att samla in spelarens historiska gissningar.
            WordLength(); // Metod för att räkna ut och visa ordets antal bokstäver.
            
            GameLoop(); // Metod för att loopa spelets gränssnitt.
            GameInterface(); // Metod för att visa nödvändig information.
            Guess(); // Metod för att ta emot en gissning ifrån användaren.
            CompareWord(); // Metod för att jämföra gissning med ordet.
            CheckEndGame(); // Metod för att kolla om spelarens liv tagit slut eller spelets ord gissats.
            
            WinGame(); // Metod om man vinner spelet.
            LoseGame(); // Metod om man förlorar spelet.
            
            MainMenuGui(); // Metod för att visa gränssnittet för huvudmenyn.
            HowToGui(); // Metod för att visa gränssnittet för how to'n.*/
        } // Visar information om vilka metoder vi har att arbeta med.

        private static void TakeName() // Metod för att insamla spelarens namn.
        {
            do
            {

                Console.WriteLine("Skriv in namn.");
                playerName = Console.ReadLine(); //tar spelarens namn

                //namnet måste vara mellan 3 och 25 bokstäver annars kommer den inte att accepteras och loopen kommer att köras igen
                if (playerName.Length >= 3 && playerName.Length <= 25) 
                {
                    Console.WriteLine("välkommen " + playerName);
                    MainMenu();
                    return;
                }
                else
                {
                    Console.WriteLine("Skriv minst 3 bokstäver och inte mer än 25 bokstäver");

                }
            } while (true);
        }

        private static void MainMenu() // Huvudmenyn till spelet.
        {
            //variabel som tar det som spelaren skriver och sparar det som en string 
            string checkInput;

            //variabel som kommer att bestämma vilket val som görs i switchen den kommer att tilldelas
            // ett värde från checkInput efter att det har försäkrats att det är ett nummer
            int mainMenuSwitch;

            // En loop för att huvudmenyn ska finnas tillgänglig så länge spelaren befinner sig utanför spelet.
            while (true)
            {
                Console.Clear(); // Rensar konsollen från tidigare kommandon.
                MainMenuGui(); // Visar gränssnittet för MainMenu.

                checkInput = Console.ReadLine();

                //jämfr det spelaren har skrivit, det måste vara 1, 2 eller 3 annars kommer det inte accepteras och
                //spelaren måste skriva om
                if (checkInput.Equals("1") || checkInput.Equals("2") || checkInput.Equals("3"))
                {
                    mainMenuSwitch = int.Parse(checkInput);
                }

                else
                {
                    //när mainMenuSwitch får vädet noll så kommer den att åka till default
                    //och när den är klar där så kommer användaren frågas om igen eftersom allt ligger i en while-loop
                    mainMenuSwitch = 0;
                }

                switch (mainMenuSwitch) // Initierar en switch-meny med tre olika alternativ.
                {
                    case 1:
                        Difficulty();
                        break;

                    case 2:
                        HowTo(); // Visar HowTo'n om spelaren trycker på 2.
                        break;

                    case 3:
                        Console.WriteLine("Avslutar spelet."); // Avslutar spelet om spelaren trycker på 3.
                        Timer(1);
                        //Environment.Exit(0);
                        //menuLoop = false;
                        return;
                    //break;

                    default:
                        Console.WriteLine("Använd enbart 1, 2 eller 3."); // Visas om spelaren trycker på någon annan knapp än tillåtet.
                        Console.WriteLine("Tryck enter för att gå tillbaka och försöka igen.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static void Difficulty()
        {
            //orden som kan väljas mellan spara som string arrayer istället för stringar så att vi ska ha mer kontroll över dem
            string[] easy = new string[] {"k", "u", "n", "g", "e", "n"};
            string[] medium = new string[] {"a","s","k","u","n","g","e","n"};
            string[] hard = new string[] {"k","o","n","t","i","n","e","n","t","a","l"};

            while (true) // En loop som körs tills spelaren har valt ett giltigt val funkar som i huvudmenyn
            {
                int difficultySwitch;

                Console.WriteLine("Svårighetsgrad");
                Console.WriteLine("Vill du köra på lätt nivå? Tryck 1:");
                Console.WriteLine("Vill du köra på medel nivå? Tryck 2:");
                Console.WriteLine("Vill du köra på svår nivå? Tryck 3:");

                string checkInput = Console.ReadLine();
                int inputCheckLength = checkInput.Length;

                if (checkInput.Equals("1") || checkInput.Equals("2") || checkInput.Equals("3"))
                {

                    difficultySwitch = int.Parse(checkInput);

                }

                else
                {
                    difficultySwitch = 0;

                }
                //WordGeneratorWord sätts det ord som motsvarar den svårighet spelaren valt
                //och sedan anropar den wordGenerator
                switch (difficultySwitch)
                {
                    case 1:
                        Console.WriteLine("Du valde lätt nivå!");
                        wordGeneratorWord = easy;
                        WordGenerator();
                        return;

                    case 2:
                        Console.WriteLine("Du valde medel nivå");
                        wordGeneratorWord = medium;
                        WordGenerator();
                        return;

                    case 3:
                        Console.WriteLine("Du valde svår nivå");
                        wordGeneratorWord = hard;
                        WordGenerator();
                        return;

                    default:
                        Console.WriteLine("Var vänlig och skriv in 1,2 eller 3");
                        break;
                }
            }
        }

        private static void WordGenerator() // Metod för att välja ord från ordlistan.
        {
            Console.Clear();

            //här görs lite förberedelser inför spelet, återställer värdena om spelet körts innan
            playerLives = 4;
            numberOfGuesses = 0;
            guessHistory = "";
            wordLength = wordGeneratorWord.Length;
            theWord = "";

            //här tilldelas stringen theWord så att den får samma ord som wordGeneratorWord
            //skillnaden är att theWord är en string och wordGeneratorWord är en array av stringar
            for (int i = 0; i < wordLength; i++)
            {
                theWord += wordGeneratorWord[i];
            }

            //maskedWord får samma längd som wordGeneratorWord
            maskedWord = new string[wordLength];

            //maskedWord får ett understreck motsvarande varje bokstav dessa kommer bytas ut mot bokstäver under spelets gång
            for (int i = 0; i < wordLength; i++)
            {
                maskedWord[i] = "_";
            }
            GameLoop();
        }

        private static void GameLoop() // Loopen som spelet körs inom. Startar om efter varje gissning och uppdaterar andra metoder.
        {
            while (true)
            {

                GameInterface();
                Guess();
                History();


                //metoden CompareWord Anropas och om den är sann och då går man ur loopen annars körs loopen igen.
                //den är sann om man har vunnit eller förlorat som kollas i metoden CompareWord som returner ett bool värde
                if (CompareWord() == true) return;

            }
        }

        private static void GameInterface() // Visar "gränssnittet" för spelaren.
        {
            //om spelaren gör har mindre än 4 liv händer det i if satsen som gör att liven blir röda
            //annars skrivs det ut med grå som allt annat
            if (playerLives < 4) 
            {



                Console.Write("\nDu har: ");
                Console.ForegroundColor = ConsoleColor.Red; //här blir det rött
                Console.Write(playerLives);                 //här skrivs det liven
                Console.ResetColor();                       //här återsälls färgen
                Console.Write(" liv kvar ");
                //Console.Beep();
                //Console.Beep();
                //Console.Beep();

            }
            else
            {

                Console.WriteLine("\nDu har: " + playerLives + " liv kvar");

            }

            Console.WriteLine("\nDu har gissat på:" + guessHistory);
            WordLength();
        }

        private static void WordLength() // Metod för att ta reda på nuvarande ords antal bokstäver.
        {
            
            Console.Write("Ordet är: ");
            for (int i = 0; i < wordLength; i++) 

            {
                //här skrivs bokstäverna maskedWord ut i början kommer det att bara vara understreck och mellanrum
                //men senare under spelet kommer det att bytas ut mot bokstäver.
                Console.Write(maskedWord[i] + " ");  

            }

            Console.WriteLine("");
        }

        private static void Guess() // Metod för att samla in gissning från spelaren.
        {

            Console.Write("Gissa ord: ");

            //spelaren skriver in sin gissning och det sparas som en variabel
            playerGuess = Console.ReadLine().ToLower();

            //antalet gissningar ökar med 1
            numberOfGuesses++;
        }

        private static void History() // Metod för att visa historiken över gissade ord.
        {
            //här läggs spelarens gissning i en string med alla tidigare gissningar så att de kan vissas för spelaren
            //om historien är tom dvs när spelaren gör sin första gissning så läggs gissningen bara in
            //senare läggs de in med ett ,-tecken mellan
            if (guessHistory.Equals(""))  
            {
                guessHistory += " " + playerGuess;
            }
            else guessHistory += ", " + playerGuess;
        }

        //metoden skickar tillbaka ett bool värde dvs true eller false
        //om spelaren har vunnit eller förlorat så skickas true och då kommer spelet avslutas
        private static bool CompareWord() // Metod för att jämföra Guess med WordGenerator.
        {
            //Här tas all text bort från konsolen så att det ska inte vara så mycket störande text.
            //anledningen att det görs här och inte i början eller slutet av gameloop är att denna metod skriver
            //text som ska synas så det måste vara med i nästa gameloop
            Console.Clear();

            //variabel skapas för att för att kolla om man hade rätt.
            bool changeMade = false;

            //en for-loop som går igenom ordet bokstav för bokstav och om ett stämmer så kommer motsvarande plats i maskedWord 
            //updateras med den gissade bokstaven. maskedWord kommer att då se mer och mer ut som  wordGeneratorWord
            //dvs det rätta ordet. changeMade blir true för att visa att en ändring har hänt
            //om en ändring aldrig har hänt dvs att gissningen inte stämmer överäns med någon bokstav i ordet
            //så kommer changeMade aldrig ändras till true och skickas vidare som falsk
            for (int i = 0; i < wordLength; i++)
            {
                if (playerGuess.Equals(wordGeneratorWord[i]))
                {
                    maskedWord[i] = playerGuess;
                    changeMade = true;
                }

            }
            
             


            //variabel skapas for att se om maskedWord är samma som wordGeneratorWord
            //den sätts som true i början och om något fel hittas så kommer den bli false
            bool isEqual = true;

            //en for-loop som går igenom maskedWord och wordGeneratorWord bokstav för boksvar och ser om de är lika
            //om vid något tillfälle en bokstav i maskedWord inte är samma som motsvarande bokstav i wordGeneratorWord
            //så får isEqual false som värde
            for (int i = 0; i < wordGeneratorWord.Length; i++)
            {
                if (maskedWord[i] != wordGeneratorWord[i]) isEqual = false;
            }


            //kollar om antingen spelarens gissning är samma som ordet eller om isEqual är sann vilket innebär att
            //spelaren har gissat all bokstäver i ordet
            //om något av dessa är sann så vinner man
            if (playerGuess.Equals(theWord) || isEqual)
            {
                WinGame();
                return true;
            }
            
            //om spelarens liv är noll så förlorar man
            if (playerLives == 0)
            {
                LoseGame();
                return true;
            }

            //om changeMade är falsk så innebär det att ingen ändring har hänt och då minskas ens liv
            if (changeMade == false)
            {
                Console.WriteLine("\nDu gissade fel, försök igen!");
                playerLives--;
            }

            return false;
        }

        private static void WinGame() // anropas om spelaren har vunnit 
        {
            Console.WriteLine("Grattis. Du är awesome!.");
            Console.WriteLine("Ordet var : {0}", theWord);
            Console.ReadLine();

        }

        private static void LoseGame() // Förolämpar spelaren om denne inte är så bra.
        {
            Console.WriteLine(" ________________ ");
            Console.WriteLine(" |  | ");
            Console.WriteLine(" | ( ) ");
            Console.WriteLine(" | /|\\ ");
            Console.WriteLine(" |  | ");
            Console.WriteLine(" | / \\ ");
            Console.WriteLine(" | ");
            Console.WriteLine(" | ");
            Console.WriteLine(" |_______ ");
            Console.WriteLine("Du... Dra.");
            Console.ReadLine();

        }

        private static void HowTo() // Metod för att visa HowTo'n.
        {
            while (true) //loop som funkar som loopen i huvudmenyn
            {
                HowToGui(); // Visar gränssnittet för HowTo'n.
                Console.WriteLine("Var vänlig och skriv in 1 eller 2");
                int menuSwitchHowTo;

                string checkInput = Console.ReadLine();
                int inputCheckLength = checkInput.Length;

                if (checkInput.Equals("1") || checkInput.Equals("2"))
                {

                    menuSwitchHowTo = int.Parse(checkInput);

                }

                else
                {
                    menuSwitchHowTo = 0;

                }

                switch (menuSwitchHowTo) // Ytterligare en switchmeny men utan loop eftersom att menyn inte behöver visas igen.
                {
                    case 1:
                        // Låter spelaren återgå till mainmenu
                        return;


                    case 2:
                        Difficulty();
                        return;
                }
            }
        }

        private static void HowToGui() // Metod för att visa gränssnittet för How To'n
        {
            Console.Clear();
            Console.WriteLine("             `..`         ");
            Console.WriteLine("            .:::`                                                  `-..         ");
            Console.WriteLine("           `.:-:`                                                  `//-         ");
            Console.WriteLine("       `````.:.:`                ````                              `/+.         ");
            Console.WriteLine("      .-//:/:/+...`````....::::////::---------:::--::..........````-/+-`        ");
            Console.WriteLine("      `---::/+/:://////:::::::--..:.``````````..---::----::::::-:/+++/::::---`  ");
            Console.WriteLine("       ``...//+s/-.......................-------------.....``....../+/:::--.-   ");
            Console.WriteLine("        ``..-.---..````````     ``  `                       ``...``:+:.```      ");
            Console.WriteLine("        ```.-.-..`                                           `````-/+-`         ");
            Console.WriteLine("         ```.--.      För att spela spelet måste du                ++-          ");
            Console.WriteLine("         ```.-+-`    gissa ett ord. Om du gissar fel så            //-          ");
            Console.WriteLine("         `` -/o-`     kommer du att förlora ett liv                /::          ");
            Console.WriteLine("             /o-                                                  +/-           ");
            Console.WriteLine("         `   :o-      Välj ett av följande:                      `++-           ");
            Console.WriteLine("         ``  /o-`     1. Återvänd till huvudmenyn                .++-           ");
            Console.WriteLine("             ++-      2. Starta spelet                         ` .++.           ");
            Console.WriteLine("            .o+-                                               ``-/+`           ");
            Console.WriteLine("            -o+-                ``                            ```-/+`           ");
            Console.WriteLine("      `````./o/:-----------::::://:::::::::::::------......-`....::+-`          ");
            Console.WriteLine("  `-:::///+oso/:+::::---------...-:..................----::::::::/:---/::--`    ");
            Console.WriteLine("   -:/o+/::oss/:.```````````````                            ``..-/+o:.-://:`    ");
            Console.WriteLine("  `-:::/:-.`/o/.````                                        ```.--++.    ``     ");
            Console.WriteLine("  `..``....`:o:.`                                             `...+/.           ");
            Console.WriteLine("            `..`                                               `..+:.           ");
            Console.WriteLine("                                                    	            `-`            ");
        }

        private static void MainMenuGui() // Metod för att visa gränssnittet för huvudmenyn
        {
            Console.WriteLine("             `..`");
            Console.WriteLine("            .:::`                                                  `-..         ");
            Console.WriteLine("           `.:-:`                                                  `//-         ");
            Console.WriteLine("       `````.:.:`                ````                              `/+.         ");
            Console.WriteLine("      .-//:/:/+...`````....::::////::---------:::--::..........````-/+-`        ");
            Console.WriteLine("      `---::/+/:://////:::::::--..:.``````````..---::----::::::-:/+++/::::---`  ");
            Console.WriteLine("       ``...//+s/-.......................-------------.....``....../+/:::--.-   ");
            Console.WriteLine("        ``..-.---..````````     ``  `                       ``...``:+:.```      ");
            Console.WriteLine("        ```.-.-..`                                           `````-/+-`         ");
            Console.WriteLine("         ```.--.                                                   ++-          ");
            Console.Write("         ```.-+-`");

            //for-looparna raknar ut hur många mellanrum som ska skrivas ut innan och efter texten eftersom den
            //varierar beroende på storleken av spelarens namn och skulle annars förstöra rammen 
            for (int i = 0; i < 12 - playerName.Length / 2; i++)
            {
                Console.Write(" ");
            }
            Console.Write("Välkommen {0} till Hangr 0.1", playerName); // Byter ut {0} mot vad spelaren angivit i TakeName.
            if (playerName.Length % 2 == 0)
            {

                for (int i = 0; i < 13 - playerName.Length / 2; i++)
                {
                    Console.Write(" ");
                }
            }
            else
            {
                for (int i = 0; i < 13 - playerName.Length / 2 - 1; i++)
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine("//-          ");
            Console.WriteLine("         `` -/o-`                                                  /::          ");
            Console.WriteLine("         `  -:o.                                                   /::          ");
            Console.WriteLine("         `  -/o.                                                  `+:-          ");
            Console.WriteLine("            ./o.                                                  .o/-          ");
            Console.WriteLine("            `/o.             Välj något av följande:              :o/.          ");
            Console.WriteLine("             /o-             1. Starta spel.                      /o/`          ");
            Console.WriteLine("             /o-             2. How to.                           ++:`          ");
            Console.WriteLine("             /o-             3. Avsluta spel.                     +/-           ");
            Console.WriteLine("         `   :o-                                                 `++-           ");
            Console.WriteLine("         ``  /o-`                                                .++-           ");
            Console.WriteLine("             ++-           förra spelet tog {0} gissningar       ` .++.           ", numberOfGuesses);
            Console.WriteLine("            .o+-                                               ``-/+`           ");
            Console.WriteLine("            -o+-                ``                            ```-/+`           ");
            Console.WriteLine("      `````./o/:-----------::::://:::::::::::::------......-`....::+-`          ");
            Console.WriteLine("  `-:::///+oso/:+::::---------...-:..................----::::::::/:---/::--`    ");
            Console.WriteLine("   -:/o+/::oss/:.```````````````                            ``..-/+o:.-://:`    ");
            Console.WriteLine("  `-:::/:-.`/o/.````                                        ```.--++.    ``     ");
            Console.WriteLine("  `..``....`:o:.`                                             `...+/.           ");
            Console.WriteLine("            `..`                                               `..+:.           ");
            Console.WriteLine("                                                    	            `-`            ");
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangman2
{
    class LanguageStrings
    {
        public static void Swedish()
        {
           string swedish = "Skriv in namn:" + Environment.NewLine +
"Välkommen" + Environment.NewLine +
"till Hangr 0.1" + Environment.NewLine +
"Välj något av följande:" + Environment.NewLine +
"1. Starta spel." + Environment.NewLine +
"2. How to." + Environment.NewLine +
"3. Avsluta spel." + Environment.NewLine +
"förra spelet tog" + Environment.NewLine +
"gissningar" + Environment.NewLine +
"För att spela spelet ska du" + Environment.NewLine +
"gissa antingen på ord eller bokstav" + Environment.NewLine +
"om du gissar fel blir du av med ett liv" + Environment.NewLine +
"men om du gissar rätt så behåller du liv." + Environment.NewLine +
"Antal liv bestäms genom villken" + Environment.NewLine +
"svårighetsgrad som man väljer" + Environment.NewLine +
"Välj ett av följande:" + Environment.NewLine +
"1. Återvänd till huvudmenyn" + Environment.NewLine +
"2. Starta spelet" + Environment.NewLine +
"Var vänlig och skriv in 1 eller 2" + Environment.NewLine +
"Du måste ange 1 eller 2." + Environment.NewLine +
"Använd enbart 1, 2 eller 3." + Environment.NewLine +
"Tryck enter för att gå tillbaka och försöka igen." + Environment.NewLine +
"Svårighetsgrad" + Environment.NewLine +
"Vill du köra på lätt nivå? Tryck 1:" + Environment.NewLine +
"Vill du köra på medel nivå? Tryck 2:" + Environment.NewLine +
"Vill du köra på svår nivå? Tryck 3:" + Environment.NewLine +
"Var vänlig och skriv in 1,2 eller 3" + Environment.NewLine +
"Du har gissat på:" + Environment.NewLine +
"Ordet är:" + Environment.NewLine +
"Gissa bokstav/ord:" + Environment.NewLine +
"Du måste skriva in en gissning." + Environment.NewLine +
"Ange gissning:" + Environment.NewLine +
"Du gissade fel, försök igen!" + Environment.NewLine +
"Du har:" + Environment.NewLine +
"liv kvar." + Environment.NewLine +
"Du gissade rätt bokstav, fortsätt så!" + Environment.NewLine +
"Ordet du sökte var" + Environment.NewLine +
"Du... Dra." + Environment.NewLine +
"Åh, du är så fin. Vad skulle du önska att du fick göra nu?" + Environment.NewLine +
"Vill du:" + Environment.NewLine +
"1. Spela igen." + Environment.NewLine +
"2. Byta spelare." + Environment.NewLine +
"3. Avsluta spelet." + Environment.NewLine +
"Fy" + Environment.NewLine +
"Grattis. Du är awesome! Dina poäng är" + Environment.NewLine +
"Namnet måste vara mellan 3 och 25 bokstäver." + Environment.NewLine +
"Du valde lätt nivå!" + Environment.NewLine +
"Du valde medel nivå!" + Environment.NewLine +
"Du valde svår nivå!" + Environment.NewLine +
"Avslutar spelet.";
            File.WriteAllText(@"c:\users\public\hangmandata\swedish.txt", swedish, Encoding.GetEncoding("iso-8859-1"));
        }
        public static void Northlandish()
        {
            string northlandish ="Va e namnä:" + Environment.NewLine +
"Tjäna" + Environment.NewLine +
"du kö Hangr 0.1" + Environment.NewLine +
"Ta' en:" + Environment.NewLine +
"1. Ba kö." + Environment.NewLine +
"2. Va?" + Environment.NewLine +
"3. Lägg utåa." + Environment.NewLine +
"Sist'å" + Environment.NewLine +
"fisök    " + Environment.NewLine +
"Fö å lira så lä ru        " + Environment.NewLine +
"gissa ordä elle boksta'n.         " + Environment.NewLine +
"Gissaru fel så ta vi liv å gissaru    " + Environment.NewLine +
"rätt fåru behålla skit'n.               " + Environment.NewLine +
"Liv'n fåru av svårihet'n.     " + Environment.NewLine +
"Kö nu!                      " + Environment.NewLine +
"Ta' en:             " + Environment.NewLine +
"1. Första menyn           " + Environment.NewLine +
"2. Ba kö.      " + Environment.NewLine +
"Ta 1 elle 2." + Environment.NewLine +
"Hörru tjåggis, ta 1 elle 2." + Environment.NewLine +
"Ta ba 1, 2 elle 3." + Environment.NewLine +
"Tjoffa enter fö å testa igänn." + Environment.NewLine +
"Svårihet" + Environment.NewLine +
"Skaru kö på lätt? Ta 1." + Environment.NewLine +
"Skaru kö på median? Ta 2." + Environment.NewLine +
"Skaru hare svårt? Ta 3." + Environment.NewLine +
"Ta ba 1, 2 elle 3." + Environment.NewLine +
"Du ha tatt:" + Environment.NewLine +
"Orde ä':" + Environment.NewLine +
"Dra e'n gissning på ordä/boksta'n:" + Environment.NewLine +
"Du lä dra en gissning." + Environment.NewLine +
"Gissning:" + Environment.NewLine +
"Hah, du gissa fel, kö igen!" + Environment.NewLine +
"Du ha:" + Environment.NewLine +
" liv." + Environment.NewLine +
"Du dro en tjoffsmoff rätt uppi smet'n! Kö på!" + Environment.NewLine +
"Orde du skulle tatt va" + Environment.NewLine +
"Hörru, dra!" + Environment.NewLine +
"Du e så snablarns vackär, va nu?" + Environment.NewLine +
"Va vill du:" + Environment.NewLine +
"1. Kö igän." + Environment.NewLine +
"2. Byt lirar'n." + Environment.NewLine +
"3. Lägg utåa." + Environment.NewLine +
"Bu" + Environment.NewLine +
"Men dude, du e awesome! Dina poäng ä" + Environment.NewLine +
"Namne lä va 3 te 25 joxx." + Environment.NewLine +
"Du to lätt!" + Environment.NewLine +
"Du to grön kobärs!" + Environment.NewLine +
"Du e ju dum du!" + Environment.NewLine +
"Slut å' kö!";
            File.WriteAllText(@"c:\users\public\hangmandata\northlandish.txt", northlandish, Encoding.GetEncoding("iso-8859-1"));
        }
        public static void English()
        {
            string english ="Enter name:" + Environment.NewLine +
"Welcome" + Environment.NewLine +
"to Hangr 0.1   " + Environment.NewLine +
"Select one of the following:" + Environment.NewLine +
"1. Start game." + Environment.NewLine +
"2. How to." + Environment.NewLine +
"3. Quit game.  " + Environment.NewLine +
"Last game took" + Environment.NewLine +
"guesses    " + Environment.NewLine +
"To play the game you      " + Environment.NewLine +
"have to guess either the word or letter." + Environment.NewLine +
"If you guess wrong you will lose a life" + Environment.NewLine +
"and if you guess correct you keep them.  " + Environment.NewLine +
"Number of lives are decided through choice" + Environment.NewLine +
"of difficulty.              " + Environment.NewLine +
"Select one of the following:" + Environment.NewLine +
"1. Return to main menu    " + Environment.NewLine +
"2. Start game  " + Environment.NewLine +
"Please select 1 or 2" + Environment.NewLine +
"You have to select 1 or 2." + Environment.NewLine +
"Only use 1, 2 or 3." + Environment.NewLine +
"Press enter to go back and try again." + Environment.NewLine +
"Difficulty" + Environment.NewLine +
"Do you want to play on easy level? Press 1." + Environment.NewLine +
"Do you want to play on medium level? Press 2." + Environment.NewLine +
"Do you want to play on hard level? Press 3." + Environment.NewLine +
"Please enter 1, 2 or 3." + Environment.NewLine +
"You have guessed:" + Environment.NewLine +
"The word is:" + Environment.NewLine +
"Guess the letter/word:" + Environment.NewLine +
"You have to write a guess." + Environment.NewLine +
"Enter guess:" + Environment.NewLine +
"You guessed wrong, try again!" + Environment.NewLine +
"You have:" + Environment.NewLine +
" lives left." + Environment.NewLine +
"You guessed the right letter, keep doing that!" + Environment.NewLine +
"The word you were looking for was" + Environment.NewLine +
"Hey you, leave!" + Environment.NewLine +
"Oh, you are so beautiful. What would you like you could do now?" + Environment.NewLine +
"Do you want to:" + Environment.NewLine +
"1. Play again." + Environment.NewLine +
"2. Change player." + Environment.NewLine +
"3. Quit game." + Environment.NewLine +
"Boo" + Environment.NewLine +
"Congratulations, you are awesome! Your points is" + Environment.NewLine +
"The name have to be 3 to 25 letters long." + Environment.NewLine +
"You picked easy level!" + Environment.NewLine +
"You picked medium level!" + Environment.NewLine +
"You picked hard level!" + Environment.NewLine +
"Quitting game.";
            File.WriteAllText(@"c:\users\public\hangmandata\english.txt", english, Encoding.GetEncoding("iso-8859-1"));
        }
    }
}

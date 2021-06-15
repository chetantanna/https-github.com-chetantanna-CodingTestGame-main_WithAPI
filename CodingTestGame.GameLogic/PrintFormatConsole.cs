using System;

namespace CodingTestGame.GameLogic
{
    public class PrintFormatConsole : IPrintFormatConsole
    {
        #region methods
        public string GetGameObjectSelection()
        {
            return "0-R-Rock (For choose Rock object you can write 0 OR R Or Rock and press enter)\r\n\r\n"+
                              "1-P-Paper (For choose Paper object you can write 1 OR P Or Paper and press enter)\r\n\r\n" +
                              "2-S-Scissors (For choose Scissors object you can write 2 OR S Or Scissors and press enter)\r\n\r\n" +
                              "Please select your option:";
        }
        public string GetHeaderConsole(string name)
        {
            return "Welcome to Rock, Paper, Scissors! You " + name + " against the Random Computer Player.\r\n\r\n" +
                "Below are the rules of Game.\r\n\r\n" +
                "Rock beats scissors.\r\n\r\n"+
                "Scissors beats paper..\r\n\r\n"+
                "Paper beats rock..\r\n\r\n";
        }
        public string GetPlayerName(string name)
        {
            return string.Format("{0} ,let's Play!"+Environment.NewLine, name);
        }
        #endregion
    }
}

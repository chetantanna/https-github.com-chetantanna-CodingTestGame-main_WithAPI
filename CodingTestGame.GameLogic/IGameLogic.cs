using CodingTestGame.Models;
using System.Collections.Generic;

namespace CodingTestGame.GameLogic
{
    public interface IGameLogic
    {
        #region Signatures
        RockPaperScissorsEnum AcceptUserPlayerInput(string userPlayerInput);
        RockPaperScissorsEnum GenerateRandomPlayerInput();
        RockPaperScissorsEnum GetWinnerObject(RockPaperScissorsEnum winnerInput);
        string GetWinner(PlayerDetail userPlayer,PlayerDetail randomPlayer);
        string GetWinnerResultString(List<string> lstResults);
        string GetWinnerObjectData(string userPlayer, string randomPlayer);
        #endregion
    }
}

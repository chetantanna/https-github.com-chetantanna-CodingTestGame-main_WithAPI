using CodingTestGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingTestGame.GameLogic
{
    public class GameLogic : IGameLogic
    {
        #region Private properties
        private string MessageHumanPlayerwin = "Human Player is winner";
        private string MessageRandomComputerPlayerwin = "Random Computer Player is winner";
        private string MessageDrawOrInvalid = "Tie between players!";
        private string MessageHumanPlayerwinOnly = "Human";
        private string MessageRandomComputerPlayerwinOnly = "Random";
        private string MessageDrawOrInvalidOnly = "Tie";
        #endregion

        #region Game Logic methods
        /// <summary>
        /// Accept user input
        /// </summary>
        /// <param name="userPlayerInput"></param>
        /// <returns>RockPaperScissorsEnum enum</returns>
        public RockPaperScissorsEnum AcceptUserPlayerInput(string userPlayerInput)
        {
            try
            {
                return GetResultFromInput(userPlayerInput?.ToUpper());
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Genearate Random Computer player input
        /// </summary>
        /// <returns></returns>
        public RockPaperScissorsEnum GenerateRandomPlayerInput()
        {
            try
            {
                Random random = new Random();
                return GetResultFromInput(Convert.ToString(random.Next(0, 2)));
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get winner.
        /// </summary>
        /// <returns>winner string result.</returns>
        /// <param name="userPlayer">PlayerDetail userPlayer.</param>
        /// <param name="randomPlayer">PlayerDetail randomPlayer.</param>
        public string GetWinner(PlayerDetail userPlayer, PlayerDetail randomPlayer)
        {
            try
            {
                if (GetWinnerObject(userPlayer.GameObjects).Equals(randomPlayer.GameObjects))
                {
                    return MessageRandomComputerPlayerwin;
                }
                else if (GetWinnerObject(randomPlayer.GameObjects).Equals(userPlayer.GameObjects))
                {
                    return MessageHumanPlayerwin;
                }
                else
                {
                    return MessageDrawOrInvalid;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Get winner.
        /// </summary>
        /// <returns>winner string result.</returns>
        /// <param name="userPlayer">string userPlayer.</param>
        /// <param name="randomPlayer">string randomPlayer.</param>
        public string GetWinnerObjectData(string userPlayer, string randomPlayer)
        {
            try
            {
                if (GetWinnerObject(GetGameObjectByString(userPlayer)).Equals(GetGameObjectByString(randomPlayer)))
                {
                    return MessageRandomComputerPlayerwin;
                }
                else if (GetWinnerObject(GetGameObjectByString(randomPlayer)).Equals(GetGameObjectByString(userPlayer)))
                {
                    return MessageHumanPlayerwin;
                }
                else
                {
                    return MessageDrawOrInvalid;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Get Winner object
        /// </summary>
        /// <param name="winnerInput"></param>
        /// <returns>RockPaperScissorsEnum enum</returns>
        public RockPaperScissorsEnum GetWinnerObject(RockPaperScissorsEnum winnerInput)
        {
            try
            {
                switch (winnerInput)
                {
                    case RockPaperScissorsEnum.Rock:
                        return RockPaperScissorsEnum.Paper;
                    case RockPaperScissorsEnum.Paper:
                        return RockPaperScissorsEnum.Scissors;
                    case RockPaperScissorsEnum.Scissors:
                        return RockPaperScissorsEnum.Rock;
                    default:
                        return RockPaperScissorsEnum.Unknown;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Get Winner object
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>RockPaperScissorsEnum enum</returns>
        public RockPaperScissorsEnum GetWinnerGameObjectByString(string userInput)
        {
            try
            {
                switch (userInput)
                {
                    case "Rock":
                        return RockPaperScissorsEnum.Paper;
                    case "Paper":
                        return RockPaperScissorsEnum.Scissors;
                    case "Scissors":
                        return RockPaperScissorsEnum.Rock;
                    default:
                        return RockPaperScissorsEnum.Unknown;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Get Winner object
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>RockPaperScissorsEnum enum</returns>
        public RockPaperScissorsEnum GetGameObjectByString(string userInput)
        {
            try
            {
                switch (userInput)
                {
                    case "Rock":
                        return RockPaperScissorsEnum.Rock;
                    case "Paper":
                        return RockPaperScissorsEnum.Paper;
                    case "Scissors":
                        return RockPaperScissorsEnum.Scissors;
                    default:
                        return RockPaperScissorsEnum.Unknown;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Get final result string
        /// </summary>
        /// <param name="lstResults"></param>
        /// <returns>final result string</returns>
        public string GetWinnerResultString(List<string> lstResults)
        {
            try
            {
                int TieCount = lstResults.Where(x => x.Contains(MessageDrawOrInvalidOnly)).Count();
                int PlayerCount = lstResults.Where(x => x.Contains(MessageHumanPlayerwinOnly)).Count();
                int RandomPlayerCount = lstResults.Where(x => x.Contains(MessageRandomComputerPlayerwinOnly)).Count();
                if (TieCount == 0)
                {
                    if (PlayerCount > RandomPlayerCount)
                        return MessageHumanPlayerwin;
                    else if (RandomPlayerCount > PlayerCount)
                        return MessageRandomComputerPlayerwin;
                    else
                        return MessageDrawOrInvalid;
                }
                else
                {
                    if (TieCount == 3)
                        return MessageDrawOrInvalid;
                    else if (TieCount == 2 && PlayerCount == 1)
                        return MessageHumanPlayerwin;
                    else if (TieCount == 2 && RandomPlayerCount == 1)
                        return MessageRandomComputerPlayerwin;
                    else if (TieCount == 1 && RandomPlayerCount == 1 && PlayerCount == 1)
                        return MessageDrawOrInvalid;
                    else if (TieCount == 1 && PlayerCount == 2)
                        return MessageHumanPlayerwin;
                    else if (TieCount == 1 && RandomPlayerCount == 2)
                        return MessageRandomComputerPlayerwin;
                    else
                        return MessageDrawOrInvalid;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get result from input
        /// </summary>
        /// <param name="input"></param>
        /// <returns>RockPaperScissorsEnum enum</returns>
        private RockPaperScissorsEnum GetResultFromInput(string input)
        {
            try
            {
                if (input == "0" || input == "ROCK" || input == "R")
                {
                    return RockPaperScissorsEnum.Rock;
                }
                else if (input == "1" || input == "PAPER" || input == "P")
                {
                    return RockPaperScissorsEnum.Paper;
                }
                else if (input == "2" || input == "SCISSORS" || input == "S")
                {
                    return RockPaperScissorsEnum.Scissors;
                }
                else
                {
                    return RockPaperScissorsEnum.Unknown;
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        #endregion
    }
}

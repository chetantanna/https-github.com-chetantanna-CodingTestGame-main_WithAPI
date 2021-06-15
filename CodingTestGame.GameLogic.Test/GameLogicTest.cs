using CodingTestGame.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodingTestGame.GameLogic.Test
{
    public class GameLogicTest
    {
        private GameLogic _GameLogic;
        private string MessageHumanPlayerwin = "\nHuman Player is winner";
        private string MessageRandomComputerPlayerwin = "\nRandom Computer Player is winner";
        private string MessageDrawOrInvalid = "\nTie between players!";
        [SetUp]
        public void Setup()
        {
            _GameLogic = new GameLogic();
        }

        [Test]
        [TestCase("R")]
        [TestCase("0")]
        [TestCase("Rock")]

        [TestCase("P")]
        [TestCase("1")]
        [TestCase("Paper")]

        [TestCase("S")]
        [TestCase("2")]
        [TestCase("Scissors")]
        [TestCase("-1")]
        public void IsNotNull_AcceptUserPlayerInput(string name)
        {
            var result = _GameLogic.AcceptUserPlayerInput(name);
            Assert.IsNotNull(result);
        }

        [Test]
        public void IsNotNull_GenerateRandomPlayerInput()
        {
            var result = _GameLogic.GenerateRandomPlayerInput();
            Assert.IsNotNull(result);
        }
        [Test]
        public void IsNotNull_GetWinner_Humanlayer()
        {
            PlayerDetail userPlayer = new PlayerDetail("Human Player") {GameObjects= RockPaperScissorsEnum.Scissors };
            PlayerDetail randomPlayer = new PlayerDetail("Random computer Player") { GameObjects = RockPaperScissorsEnum.Paper };

            var result = _GameLogic.GetWinner(userPlayer, randomPlayer);
            Assert.AreEqual(MessageHumanPlayerwin, result);
        }
        [Test]
        public void IsNotNull_GetWinner_RandomPlayer()
        {
            PlayerDetail randomPlayer = new PlayerDetail("Random computer Player") { GameObjects = RockPaperScissorsEnum.Scissors };
            PlayerDetail userPlayer = new PlayerDetail("Human Player") { GameObjects = RockPaperScissorsEnum.Paper };

            var result = _GameLogic.GetWinner(userPlayer, randomPlayer);
            Assert.AreEqual(MessageRandomComputerPlayerwin, result);
        }
        [Test]
        public void IsNotNull_GetWinner_TieBetweenPlayers()
        {
            PlayerDetail randomPlayer = new PlayerDetail("Random computer Player") { GameObjects = RockPaperScissorsEnum.Scissors };
            PlayerDetail userPlayer = new PlayerDetail("Human Player") { GameObjects = RockPaperScissorsEnum.Scissors };

            var result = _GameLogic.GetWinner(userPlayer, randomPlayer);
            Assert.AreEqual(MessageDrawOrInvalid, result);
        }
        [Test]
        public void Result_TieWin()
        {
            List<string> lstResults = new List<string>() { MessageDrawOrInvalid, MessageDrawOrInvalid, MessageDrawOrInvalid };
            var result = _GameLogic.GetWinnerResultString(lstResults);
            Assert.AreEqual(MessageDrawOrInvalid, result);

            List<string> lstResultsElsePart = new List<string>() { MessageHumanPlayerwin, MessageDrawOrInvalid, MessageRandomComputerPlayerwin };
            var resultElsePart = _GameLogic.GetWinnerResultString(lstResultsElsePart);
            Assert.AreEqual(MessageDrawOrInvalid, resultElsePart);
        }
        [Test]
        public void Result_HumanPlayerWin()
        {
            List<string> lstResults = new List<string>() { MessageHumanPlayerwin, MessageHumanPlayerwin, MessageDrawOrInvalid };
            var result = _GameLogic.GetWinnerResultString(lstResults);
            Assert.AreEqual(MessageHumanPlayerwin, result);

            List<string> lstResultsElsePart = new List<string>() { MessageHumanPlayerwin, MessageHumanPlayerwin, MessageRandomComputerPlayerwin };
            var resultElsePart = _GameLogic.GetWinnerResultString(lstResultsElsePart);
            Assert.AreEqual(MessageHumanPlayerwin, resultElsePart);
        }
        [Test]
        public void Result_RandomPlayerWin()
        {
            List<string> lstResults = new List<string>() { MessageRandomComputerPlayerwin, MessageRandomComputerPlayerwin, MessageHumanPlayerwin };
            var result = _GameLogic.GetWinnerResultString(lstResults);
            Assert.AreEqual(MessageRandomComputerPlayerwin, result);

            List<string> lstResultsElsePart = new List<string>() { MessageDrawOrInvalid, MessageDrawOrInvalid, MessageRandomComputerPlayerwin };
            var resultElsePart = _GameLogic.GetWinnerResultString(lstResultsElsePart);
            Assert.AreEqual(MessageRandomComputerPlayerwin, resultElsePart);
        }
        [Test]
        public void Result_PlayerWinRemainingCombination()
        {
            List<string> lstResults = new List<string>() { MessageDrawOrInvalid, MessageRandomComputerPlayerwin, MessageRandomComputerPlayerwin };
            var result = _GameLogic.GetWinnerResultString(lstResults);
            Assert.AreEqual(MessageRandomComputerPlayerwin, result);

            List<string> lstResultsElsePart = new List<string>() { MessageDrawOrInvalid, MessageDrawOrInvalid };
            var resultElsePart = _GameLogic.GetWinnerResultString(lstResultsElsePart);
            Assert.AreEqual(MessageDrawOrInvalid, resultElsePart);
        }
        [Test]
        [TestCase("Rdasda")]
        [TestCase("0dsada")]
        [TestCase("Rockdd")]

        [TestCase("Pddds")]
        [TestCase("1sss")]
        [TestCase("Papertttt")]

        [TestCase("-2")]
        [TestCase("-1")]
        [TestCase("Sdcazdadacissors")]
        [TestCase("-10000")]
        public void ShouldThrow_ValidationOfInvalidInput(string name)
        {
            var result = _GameLogic.AcceptUserPlayerInput(name);
            Assert.AreEqual(result, RockPaperScissorsEnum.Unknown);
        }
    }
}
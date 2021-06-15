using NUnit.Framework;

namespace CodingTestGame.GameLogic.Test
{
    public class PrintFormatTest
    {
        private PrintFormatConsole _PrintFormatConsole;
        [SetUp]
        public void Setup()
        {
            _PrintFormatConsole = new PrintFormatConsole();
        }

        [Test]
        public void IsNotNull_GetGameObjectSelection()
        {
            var result = _PrintFormatConsole.GetGameObjectSelection();
            Assert.IsNotEmpty(result);
        }
        [Test]
        public void IsNotNull_GetHeaderConsole()
        {
            var result = _PrintFormatConsole.GetGameObjectSelection();
            Assert.IsNotEmpty(result);
        }
        [Test]
        [TestCase("Human player")]
        public void IsNotNull_GetGameObjectSelection(string name)
        {
            var result = _PrintFormatConsole.GetHeaderConsole(name);
            Assert.IsNotEmpty(result);
        }
        [Test]
        [TestCase("Random computer player")]
        public void IsNotNull_GetPlayerName(string name)
        {
            var result = _PrintFormatConsole.GetPlayerName(name);
            Assert.IsNotEmpty(result);
        }
    }
}
using CodingTestGame.GameLogic;
using CodingTestGame.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodingTestGame.WebApi.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private IPrintFormatConsole _printFormatConsole;
        private IGameLogic _gameLogic;
        public ApiController(IPrintFormatConsole PrintFormatConsole, IGameLogic GameLogic)
        {
            _printFormatConsole = PrintFormatConsole;
            _gameLogic = GameLogic;
        }
        [HttpGet("GetHeaderConsole")]
        public IActionResult GetHeaderConsole(string humanPlayerName)
        {
            return Ok(_printFormatConsole.GetHeaderConsole(humanPlayerName));
        }
        [HttpGet("GetPlayerName")]
        public IActionResult GetPlayerName(string humanPlayerName)
        {
            return Ok(_printFormatConsole.GetPlayerName(humanPlayerName));
        }
        [HttpGet("GetGameObjectSelection")]
        public IActionResult GetGameObjectSelection()
        {
            return Ok(_printFormatConsole.GetGameObjectSelection());
        }
        [HttpGet("AcceptUserPlayerInput")]
        public IActionResult AcceptUserPlayerInput(string input)
        {
            return Ok(_gameLogic.AcceptUserPlayerInput(input));
        }
        [HttpGet("GenerateRandomPlayerInput")]
        public IActionResult GenerateRandomPlayerInput()
        {
            return Ok(_gameLogic.GenerateRandomPlayerInput());
        }
        [HttpGet("GetWinner")]
        public IActionResult GetWinner(string userPlayer, string randomPlayer)
        {
            return Ok(_gameLogic.GetWinnerObjectData(userPlayer,randomPlayer));
        }
        [HttpGet("GetWinnerResultString")]
        public IActionResult GetWinnerResultString(string result1, string result2,string result3)
        {
            List<string> lstResult = new List<string>();
            lstResult.Add(result1);
            lstResult.Add(result2);
            lstResult.Add(result3);
            return Ok(_gameLogic.GetWinnerResultString(lstResult));
        }

    }
}

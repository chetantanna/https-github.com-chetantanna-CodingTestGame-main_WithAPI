using CodingTestGame.Models;

namespace CodingTestGame.GameLogic
{
    public interface IPrintFormatConsole
    {
        #region Signatures
        string GetHeaderConsole(string name);
        string GetPlayerName(string name);
        string GetGameObjectSelection();
        #endregion
    }
}

using CodingTestGame.Models;
using System;
using Microsoft.Extensions.DependencyInjection;
using CodingTestGame.GameLogic;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http.Headers;

namespace CodingTestGameConsole
{
    class Program
    {
        private static PlayerDetail humanPlayer;
        private static PlayerDetail randomComputerPlayer;
        private static string humanPlayerName = "Human Player";
        private static string randomComputerPlayerName = "Random Computer Player";
        private static readonly string BaseApiUrl = "http://localhost:58700/Api/";
        static void Main(string[] args)
        {
            try
            {
                StartGame();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static void StartGame()
        {
            try
            {
                var humanplayerName = GetHeaderConsole(humanPlayerName); 
                Console.WriteLine(humanplayerName);
                humanPlayer = new PlayerDetail(humanplayerName);
                randomComputerPlayer = new PlayerDetail(randomComputerPlayerName);
                GetPlayerName(humanplayerName);
                int Count = 0;
                List<string> lstResults = new List<string>();
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                while (Count < 3)
                {
                    Console.WriteLine(GetGameObjectSelection());
                    string input = Console.ReadLine();
                    var handSign = AcceptUserPlayerInput(input);
                    humanPlayer.GameObjects = handSign;
                    if (handSign != RockPaperScissorsEnum.Unknown)
                    {
                        randomComputerPlayer.GameObjects = GenerateRandomPlayerInput();
                        Console.WriteLine(humanPlayerName + " Input :" + humanPlayer.GameObjects.GetDescription());
                        Console.WriteLine(randomComputerPlayerName + " Input :" + randomComputerPlayer.GameObjects.GetDescription());
                        string result = GetWinner(humanPlayer.GameObjects.GetDescription(), randomComputerPlayer.GameObjects.GetDescription());
                        lstResults.Add(result);
                        Console.WriteLine("************************************************************************************");
                        Console.WriteLine(result + Environment.NewLine );
                        Console.WriteLine("************************************************************************************");
                        Console.WriteLine("-----------------------------------------------------------------------------------------");
                        Count++;
                    }
                    else
                    {
                        Console.WriteLine("************************************************************************************");
                        Console.WriteLine("Invalid Input, Please try again with correct input.");
                        Console.WriteLine("************************************************************************************");
                    }
                }
                Console.WriteLine("---------------------------------------Final Result------------------------------------");
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.WriteLine(GetWinnerResultString(lstResults));
                Console.WriteLine(Environment.NewLine+"-----------------------------------------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------------");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region call api section
        private static string GetHeaderConsole(string humanPlayerName)
        {
            string result = string.Empty;
            HttpClient client = HttpClientHelper.GetHttpClient(BaseApiUrl);
            var responseTask = client.GetAsync("GetHeaderConsole?humanPlayerName="+ humanPlayerName);
            responseTask.Wait();
            var resultResponse = responseTask.Result;
            if (resultResponse.IsSuccessStatusCode)
            {
                var readTask = resultResponse.Content.ReadAsStringAsync();
                readTask.Wait();
                result = readTask.Result;
            }
            return result.Replace("\"","").Replace("\\r\\n\\r\\n", Environment.NewLine).Replace("\r\n\r\n", Environment.NewLine); ;
        }
        private static string GetPlayerName(string humanPlayerName)
        {
            string result = string.Empty;
            HttpClient client = HttpClientHelper.GetHttpClient(BaseApiUrl);
            var responseTask = client.GetAsync("GetPlayerName?humanPlayerName=" + humanPlayerName);
            responseTask.Wait();
            var resultResponse = responseTask.Result;
            if (resultResponse.IsSuccessStatusCode)
            {
                var readTask = resultResponse.Content.ReadAsStringAsync();
                readTask.Wait();
                result = readTask.Result;
            }
            return result.Replace("\"", "").Replace("\\r\\n\\r\\n", Environment.NewLine).Replace("\r\n\r\n", Environment.NewLine); ;
        }
        private static string GetGameObjectSelection()
        {
            string result = string.Empty;
            HttpClient client = HttpClientHelper.GetHttpClient(BaseApiUrl);
            var responseTask = client.GetAsync("GetGameObjectSelection");
            responseTask.Wait();
            var resultResponse = responseTask.Result;
            if (resultResponse.IsSuccessStatusCode)
            {
                var readTask = resultResponse.Content.ReadAsStringAsync();
                readTask.Wait();
                result = readTask.Result;
            }
            return result.Replace("\"", "").Replace("\\r\\n\\r\\n", Environment.NewLine).Replace("\r\n\r\n", Environment.NewLine);
        }
        private static RockPaperScissorsEnum AcceptUserPlayerInput(string input)
        {
            HttpClient client = HttpClientHelper.GetHttpClient(BaseApiUrl);
            var responseTask = client.GetAsync("AcceptUserPlayerInput?input=" + input);
            responseTask.Wait();
            var resultResponse = responseTask.Result;
            if (resultResponse.IsSuccessStatusCode)
            {
                var readTask = resultResponse.Content.ReadAsAsync<RockPaperScissorsEnum>();
                readTask.Wait();
                return readTask.Result;
            }
            return RockPaperScissorsEnum.Unknown;
        }
        private static RockPaperScissorsEnum GenerateRandomPlayerInput()
        {
            HttpClient client = HttpClientHelper.GetHttpClient(BaseApiUrl);
            var responseTask = client.GetAsync("GenerateRandomPlayerInput");
            responseTask.Wait();
            var resultResponse = responseTask.Result;
            if (resultResponse.IsSuccessStatusCode)
            {
                var readTask = resultResponse.Content.ReadAsAsync<RockPaperScissorsEnum>();
                readTask.Wait();
                return readTask.Result;
            }
            return RockPaperScissorsEnum.Unknown;
        }
        private static string GetWinner(string userinput,string randomplayerInput)
        {
            HttpClient client = HttpClientHelper.GetHttpClient(BaseApiUrl);
            var responseTask = client.GetAsync("GetWinner?userPlayer="+userinput+ "&randomPlayer="+ randomplayerInput);
            responseTask.Wait();
            var resultResponse = responseTask.Result;
            string result = string.Empty;
            if (resultResponse.IsSuccessStatusCode)
            {
                var readTask = resultResponse.Content.ReadAsStringAsync();
                readTask.Wait();
                result= readTask.Result;
            }
            return result;
        }
        private static string GetWinnerResultString(List<string> lstResult)
        {
            HttpClient client = HttpClientHelper.GetHttpClient(BaseApiUrl);
            var responseTask = client.GetAsync("GetWinnerResultString?result1=" + lstResult[0] + "&result2=" + lstResult[1] + "&result3=" + lstResult[2]);
            responseTask.Wait();
            var resultResponse = responseTask.Result;
            string result = string.Empty;
            if (resultResponse.IsSuccessStatusCode)
            {
                var readTask = resultResponse.Content.ReadAsStringAsync();
                readTask.Wait();
                result = readTask.Result;
            }
            return result;
        }
        #endregion
    }
}

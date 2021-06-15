using System;
using System.Collections.Generic;

namespace CodingTestGame.Models
{
    public class PlayerDetail
    {
        private string name;
        private RockPaperScissorsEnum gameObjects;
        public PlayerDetail(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public RockPaperScissorsEnum GameObjects
        {
            get { return gameObjects; }
            set { gameObjects = value; }
        }
    }
    public class PlayerCompare
    {
        public List<PlayerDetail> lstplayers { get; set; }
    }
    public class ResultDetails
    {
        public List<string> lstResults { get; set; }
    }

}

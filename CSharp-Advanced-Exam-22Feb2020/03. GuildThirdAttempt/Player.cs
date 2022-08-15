using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        public Player(string name,string clahs)
        {
            Name = name;
            Class = clahs;
            Rank = "Trial";
            Description = "n/a";
        }
        public string Name { get; private set; }

        public string Class { get; private set; }

        public string Rank { get; internal set; }

        public string Description { get; set; }


        public override string ToString()
        {
            StringBuilder myStringToReturn = new StringBuilder();
            myStringToReturn.AppendLine($"Player {this.Name}: {this.Class}");
            myStringToReturn.AppendLine($"Rank: {this.Rank}");
            myStringToReturn.AppendLine($"Description: {this.Description}");
            return myStringToReturn.ToString().TrimEnd();
        }


    }
}


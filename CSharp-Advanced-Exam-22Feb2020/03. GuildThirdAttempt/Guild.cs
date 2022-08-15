using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        public Guild(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            Roster = new List<Player>();
        }
        public List<Player> Roster { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public void AddPlayer(Player player)
        {
            if(Count+1<=Capacity && !Roster.Contains(player))
            {
                Roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            if(Roster.Any(p=>p.Name == name))
            {
                Roster.RemoveAll(p => p.Name == name);
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            Roster.First(p => p.Name == name).Rank = "Member";
               
        }
        public void DemotePlayer(string name)
        {
            Roster.First(p => p.Name == name).Rank = "Trail";
        }
        public Player[] KickPlayersByClass(string clahs)
            {
            int size = 0;
            foreach (var item in Roster)
            {
                if (item.Class == clahs)
                    size++;
            }
            Player[] toReturn = new Player[size];
            toReturn = Roster.Where(p => p.Class == clahs).ToArray();
            Roster.RemoveAll(p => p.Class == clahs);
            return toReturn;
        }
        public int Count => Roster.Count;
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var item in Roster)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

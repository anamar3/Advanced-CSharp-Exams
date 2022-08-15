using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;
        public Race(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new List<Racer>();
        }
        public int Capacity { get; set; }
        public string Name { get; set; }
        public List<Racer> Data { get; set; }

        public void Add(Racer Racer)
        {
            if(Data.Count +1 <=Capacity)
            {
                Data.Add(Racer);
            }
        }
        public bool Remove(string name)
        {
            bool isThere = false;
            if(Data.Any(r=>r.Name == name))
            {
                Data.RemoveAll(r => r.Name == name);
                isThere = true;
            }
            return isThere;
        }
        public Racer GetOldestRacer()
        {
            return Data.OrderByDescending(r => r.Age).First();
        }
        public Racer GetRacer(string name)
        {
            return Data.First(r => r.Name == name);
        }
        public Racer GetFastestRacer()
        {
            return Data.OrderByDescending(r => r.Car.Speed).First();
        }
        public int Count => Data.Count;

        public string Report()
        {
           
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");
           foreach (var item in Data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

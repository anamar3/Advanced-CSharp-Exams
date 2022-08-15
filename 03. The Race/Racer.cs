using System;
using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Racer
    {
        public Racer(string name, int age, string country, Car car)
        {
            Name = name;
            Country = country;
            Age = age;
            Car = car;
        }
        public Car Car { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Racer: {Name}, {Age} ({Country})";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_Advanced_Exam__23_October_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] v = Console.ReadLine().Split().Select(char.Parse).ToArray();
            char[] c = Console.ReadLine().Split().Select(char.Parse).ToArray();
            Dictionary<string, List<char>> food = new Dictionary<string, List<char>>();
            food.Add("pear", new List<char>() { 'p', 'e', 'a', 'r' });
            food.Add("flour", new List<char>() { 'f', 'l', 'o', 'u', 'r' });
            food.Add("pork", new List<char>() { 'p', 'o', 'r', 'k' });
            food.Add("olive", new List<char>() { 'o', 'l', 'i', 'v', 'e' });
           
           
            


            Queue<char> vowels = new Queue<char>(v);
            Stack<char> consonants = new Stack<char>(c);
            int count = 0;

            while(consonants.Count>0)
            {
                char currCon = consonants.Pop();
                char currVol = vowels.Dequeue();

                if(food["olive"].Contains(currVol))
                {
                    food["olive"].Remove(currVol);
                }
                if (food["pear"].Contains(currVol))
                {
                    food["pear"].Remove(currVol);
                }
                if (food["pork"].Contains(currVol))
                {
                    food["pork"].Remove(currVol);
                }
                if (food["flour"].Contains(currVol))
                {
                    food["flour"].Remove(currVol);
                }
                if (food["olive"].Contains(currCon))
                {
                    food["olive"].Remove(currCon);
                }
                if (food["pear"].Contains(currCon))
                {
                    food["pear"].Remove(currCon);
                }
                if (food["pork"].Contains(currCon))
                {
                    food["pork"].Remove(currCon);
                }
                if (food["flour"].Contains(currCon))
                {
                    food["flour"].Remove(currCon);
                }
                vowels.Enqueue(currVol);
            }
            foreach (var item in food)
            {
                if(item.Value.Count == 0)
                {
                    count++;
                }
            }
            Console.WriteLine($"Words found: {count} ");

            foreach (var item in food.Where(f=>f.Value.Count==0))
            {
                Console.WriteLine(item.Key);
            }

        }
    }
}

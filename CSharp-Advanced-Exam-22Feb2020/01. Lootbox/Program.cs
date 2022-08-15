using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_Advanced_Exam___22_Feb_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLoot = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondLoot = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> firstBox = new Queue<int>(firstLoot);
            Stack<int> secondBox = new Stack<int>(secondLoot);

            int claimedItems = 0;

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int currF = firstBox.Peek();
                int currS = secondBox.Peek();
                int sum = currF + currS;

                if (sum % 2 == 0)
                {
                    firstBox.Dequeue();
                    secondBox.Pop();
                    claimedItems += sum;
                }
                else
                {
                    secondBox.Pop();
                    firstBox.Enqueue(currS);
                }
            }

            if (firstBox.Count <= 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if(claimedItems>=100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }

        }
    }
}

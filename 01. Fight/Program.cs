using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_Advanced_Exam___20_February_2021
{
    class Program
    {
        static void Main(string[] args)

        {
            int currW = 0;
            int currP = 0;

            int wavesOfOrcs = int.Parse(Console.ReadLine());
            int[] platesOfDefence = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> plates = new Queue<int>(platesOfDefence);
            Stack<int> orcsLeft = new Stack<int>();
            bool isTheDefenceOfGondorDestroyed = false;

            for (int i = 1; i <= wavesOfOrcs; i++)
            {

                Stack<int> orcs = new Stack<int>(Console.ReadLine()
                  .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse).ToArray());
                if (i % 3==0)
                {
                    int additional = int.Parse(Console.ReadLine());
                    plates.Enqueue(additional);
                }
                while (plates.Count > 0 && orcs.Count > 0)
                {
                    currW = orcs.Peek();
                    currP = plates.Peek();
                    if (currW > currP)
                    {
                        currW -= currP;
                        plates.Dequeue();
                        orcs.Pop();
                        orcs.Push(currW);
                    }
                    else if (currP > currW)
                    {
                        currP -= currW;
                        Queue<int> newPlates = new Queue<int>();
                        plates.Dequeue();
                        orcs.Pop();
                        newPlates.Enqueue(currP);

                        for (int j = 0; j < plates.Count; j++)
                        {
                            newPlates.Enqueue(plates.ElementAt(j));
                        }

                        plates = newPlates;
                    }
                    else
                    {
                        plates.Dequeue();
                        orcs.Pop();
                    }
                    if (plates.Count == 0)
                    {
                        isTheDefenceOfGondorDestroyed = true;
                        orcsLeft = orcs;
                        break;
                    }


                }

               
            }
            if (isTheDefenceOfGondorDestroyed)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcsLeft)}");
            }
            else 
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
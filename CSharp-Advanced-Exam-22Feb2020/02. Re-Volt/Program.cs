using System;

namespace _02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int countCommands = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int pRow = 0;
            int pCol = 0;

            for (int k = 0; k < size; k++)
            {
                string input = Console.ReadLine();
                for (int t = 0; t < size; t++)
                {
                    matrix[k, t] = input[t];
                    if (input[t] == 'f')
                    {
                        pRow = k;
                        pCol = t;
                    }
                }
            }
            int i = 0;
            while(i<countCommands)
            {
                string action = Console.ReadLine();
                matrix[pRow, pCol] = '-';

                if (action == "up")
                {
                    pRow--;
                    if (pRow < 0)
                    {
                        pRow = size - 1;
                    }
                   if (matrix[pRow, pCol] == 'B')
                    {
                        pRow--;

                    }
                    else if (matrix[pRow, pCol] == 'T')
                    {
                        pRow++;
                    }
                    if (pRow < 0)
                    {
                        pRow = size - 1;
                    }

                }
                else if (action == "down")
                {
                    pRow++;
                    if (pRow == size)
                    {
                        pRow = 0;
                    }
                    if (matrix[pRow, pCol] == 'B')
                    {
                        pRow++;

                    }
                    else if (matrix[pRow, pCol] == 'T')
                    {
                        pRow--;
                    }
                    if (pRow == size)
                    {
                        pRow = 0;
                    }

                }
                else if (action == "left")
                {
                    pCol--;
                    if (pCol < 0)
                    {
                        pCol = size - 1;
                    }
                     if (matrix[pRow, pCol] == 'B')
                    {
                        pCol--;

                    }
                    else if (matrix[pRow, pCol] == 'T')
                    {
                        pCol++;
                    }
                    if (pCol < 0)
                    {
                        pCol = size - 1;
                    }

                }
                else if (action == "right")
                {
                    pCol++;
                    if (pCol == size)
                    {
                        pCol = 0;
                    }
                  if (matrix[pRow, pCol] == 'B')
                    {
                        pCol++;

                    }
                    else if (matrix[pRow, pCol] == 'T')
                    {
                        pCol--;
                    }
                    if (pCol == size)
                    {
                        pCol = 0;
                    }

                }

                if (matrix[pRow, pCol] == 'F')
                {
                    matrix[pRow, pCol] = 'f';
                    Console.WriteLine("Player won!");

                    break;
                }
                matrix[pRow, pCol] = 'f';
                i++;

            }
            if(i==countCommands)
            {
                Console.WriteLine("Player lost!");
            }
            
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }


        }
    }

}

using System;
using System.Linq;

namespace warshipsAGAIN
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] coordinates = Console.ReadLine().Split(',');

            char[,] battleField = new char [size, size];

            int shipsPlayerOne = 0;
            int shipsPlayerTwo = 0;

            for (int i = 0; i < size; i++)
            {
                string [] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < size; j++)
                {
                    battleField[i, j] = char.Parse(input[j]);
                    if (char.Parse(input[j]) == '<')
                        shipsPlayerOne++;
                    else if (char.Parse(input[j]) == '>')
                        shipsPlayerTwo++;
                }
            }

            int currSumOfOneShips = 0;
            int currSumOfTwoShips = 0;

            for (int i = 0; i < coordinates.Length; i++)
            {
                
               int [] currCoordinates = coordinates[i].Split(' ').Select(int.Parse).ToArray();
                int currRow = currCoordinates[0];
                int currCol = currCoordinates[1];

                if(currCol<0 || currCol >=size || currRow <0 || currRow>=size)
                {
                    continue;
                }
               else if(battleField[currRow,currCol] == '<')
                {
                  
                    battleField[currRow, currCol] = 'X';


                }
                else if(battleField[currRow,currCol] == '>')
                {
                   
                    battleField[currRow, currCol] = 'X';
                }
                else if(battleField[currRow,currCol]== '#')
                {
                    if(currRow-1>=0 && currCol-1 >=0)
                        battleField[currRow-1, currCol-1] = 'X';
                    if(currRow-1>=0)
                        battleField[currRow-1, currCol] = 'X';
                    if(currRow-1>=0 && currCol+1<size)
                        battleField[currRow-1, currCol+1] = 'X';
                    if(currCol-1>=0)
                        battleField[currRow, currCol-1] = 'X';
                    if(currCol+1<size)
                        battleField[currRow, currCol+1] = 'X';
                    if(currRow+1 <size && currCol-1>=0)
                        battleField[currRow+1, currCol-1] = 'X';
                    if(currRow+1<size)
                        battleField[currRow+1, currCol] = 'X';
                    if(currRow+1<size && currCol+1<size)
                        battleField[currRow+1, currCol+1] = 'X';

                }
               currSumOfOneShips = 0;
                 currSumOfTwoShips = 0;
                for (int r = 0; r < size; r++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        if (battleField[r, k] == '<')
                            currSumOfOneShips++;
                        else if (battleField[r, k] == '>')
                            currSumOfTwoShips++;
                    }
                }

                if(currSumOfTwoShips == 0 )
                {
                    Console.WriteLine($"Player One has won the game! {shipsPlayerTwo+(shipsPlayerOne-currSumOfOneShips)} ships have been sunk in the battle.");
                    return;
                }
                else if(currSumOfOneShips == 0)
                {
                    Console.WriteLine($"Player Two has won the game! {shipsPlayerOne+(shipsPlayerTwo-currSumOfTwoShips)} ships have been sunk in the battle.");
                  return;
                }

            }

            Console.WriteLine($"It's a draw! Player One has {currSumOfOneShips} ships left. Player Two has {currSumOfTwoShips} ships left.");
        }
    }
}

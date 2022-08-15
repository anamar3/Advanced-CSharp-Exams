using System;

namespace pawn_wars_attept_2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] chessBoard = new char[8, 8];
            int rowWhite = 0;
            int colWhite = 0;
            int rowBlack = 0;
            int colBlack = 0;


            for (int i = 0; i < 8; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < 8; j++)
                {
                    chessBoard[i, j] = input[j];
                    if (input[j] == 'b')
                    {
                        colBlack = j;
                        rowBlack = i;
                    }
                    else if (input[j] == 'w')
                    {
                        colWhite = j;
                        rowWhite = i;
                    }
                }
            }

            bool whiteTurn = true;
            int coordinatesRow = 0;
            string coordinates = "";

            while (rowWhite != 0 && rowBlack != 7)
            {
                if (whiteTurn)
                {
                    whiteTurn = false;
                    if (colWhite - 1 >= 0 && chessBoard[rowWhite - 1, colWhite - 1] == 'b')
                    {

                        coordinatesRow = 8 - (rowWhite - 1);
                        coordinates = GetCoordinates(colWhite - 1, coordinatesRow.ToString());
                        Console.WriteLine($"Game over! White capture on {coordinates}.");
                        return;
                    }
                    else if (colWhite + 1 < 8 && chessBoard[rowWhite - 1, colWhite + 1] == 'b')
                    {
                        coordinatesRow = 8 - (rowWhite - 1);
                        coordinates = GetCoordinates(colWhite + 1, coordinatesRow.ToString());
                        Console.WriteLine($"Game over! White capture on {coordinates}.");
                        return;
                    }
                    else
                    {
                        chessBoard[rowWhite, colWhite] = '-';
                        rowWhite--;
                        chessBoard[rowWhite, colWhite] = 'w';
                    }
                }
                else
                {
                    whiteTurn = true;
                    if (colBlack - 1 >= 0 && chessBoard[rowBlack + 1, colBlack - 1] == 'w')
                    {

                        coordinatesRow = 8 - (rowBlack + 1);
                        coordinates = GetCoordinates(colBlack - 1, coordinatesRow.ToString());
                        Console.WriteLine($"Game over! Black capture on {coordinates}.");
                        return;
                    }
                    else if (colBlack + 1 < 8 && chessBoard[rowBlack + 1, colBlack + 1] == 'w')
                    {
                        coordinatesRow = 8-(rowBlack + 1);
                        coordinates = GetCoordinates(colBlack + 1, coordinatesRow.ToString());
                        Console.WriteLine($"Game over! Black capture on {coordinates}.");
                        return;
                    }
                    else
                    {
                        chessBoard[rowBlack, colBlack] = '-';
                        rowBlack++;
                        chessBoard[rowBlack, colBlack] = 'b';
                    }

                    }
          
            if(rowBlack == 7)
                {
                    coordinates = GetCoordinates(colBlack, 1.ToString());
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {coordinates}.");
                }
            else if(rowWhite ==0)
                {
                    coordinates = GetCoordinates(colWhite, 8.ToString());
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {coordinates}.");
                }
            
                        
                        
                        
                        }

           

            static string GetCoordinates(int col, string coordinatesRow)
            {
                string coordinatesCol = "";
                if (col == 0)
                {
                    coordinatesCol = "a";
                }
                else if (col == 1)
                {
                    coordinatesCol = "b";
                }
                else if (col == 2)
                {
                    coordinatesCol = "c";
                }
                else if (col == 3)
                {
                    coordinatesCol = "d";
                }
                else if (col == 4)
                {
                    coordinatesCol = "e";
                }
                else if (col == 5)
                {
                    coordinatesCol = "f";
                }
                else if (col  == 6)
                {
                    coordinatesCol = "g";
                }
                else if (col  == 7)
                {
                    coordinatesCol = "h";
                }
                return coordinatesCol + coordinatesRow;
            }
        }
    }
 }
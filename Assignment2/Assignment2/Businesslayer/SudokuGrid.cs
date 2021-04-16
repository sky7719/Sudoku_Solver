using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class SudokuGrid
    {
        public static int[,] Grid = new int[9, 9];
        public static string[] Input = new string[9];
        /// <summary>
        /// Reads the inpu from the console in the form of 9 strings 
        /// containing numbers and dashes and returns it in the form of 
        /// 9x9 2D array.
        /// </summary>
        /// <returns></returns>
        public static int[,] ReturnBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                Input[i] = Console.ReadLine();
                string Val = Input[i];
                for (int j = 0; j < 9; j++)
                {
                    if (Val[j] == '-')
                    {
                        Grid[i, j] = 0;
                    }
                    else
                    {
                        Grid[i, j] = int.Parse(Val[j].ToString());
                    }
                }
            }
            return Grid;
        }
        /// <summary>
        /// Takes a 2D array as an input and prints it on the console.
        /// </summary>
        /// <param name="Grid"></param>
        public static void PrintBoard(int[,] Grid)
        {
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    Console.Write(Grid[i, j]+" ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Gives the user option to either start a new game or exit.
        /// </summary>
        public static void NewGameInput()
        {
            int Choice;
            if (int.TryParse(Console.ReadLine(),out Choice))
            {
                if(Choice < 3 && Choice > 0)
                {
                    switch (Choice)
                    {
                        case 1:
                            RunGame();
                            break;
                        case 2: break;
                        default:
                            Console.WriteLine(Constants.ErrorMessege);
                            Console.WriteLine(Constants.MenuMessege);
                            NewGameInput();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(Constants.ErrorMessege);
                    Console.WriteLine(Constants.MenuMessege);
                    NewGameInput();
                }
            }
            else
            {
                Console.WriteLine(Constants.ErrorMessege);
                Console.WriteLine(Constants.MenuMessege);
                NewGameInput();
            }
        }
        /// <summary>
        /// Calls the ReturnBoard function to take input from the console.
        /// Calls the Solution function to solve the sudoku and tell 
        /// weather it is solvable or not.
        /// </summary>
        public static void RunGame()
        {
            try
            {
                Console.WriteLine(Constants.OpeningMessege);
                int[,] Grid = new int[9, 9];
                Grid = ReturnBoard();
                if (SolveSudoku.Solution(Grid))
                {
                    PrintBoard(Grid);
                    Constants.NewGameMessege();
                }
                else
                {
                    Console.WriteLine(Constants.NotSolvable);
                    Constants.NewGameMessege();
                }
            }
            catch
            {
                Console.WriteLine(Constants.ErrorMessege);
                Constants.NewGameMessege();
            }
        }
    }
}

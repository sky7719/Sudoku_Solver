using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// Stores all the messeges.
    /// </summary>
    class Constants
    {
        public static string OpeningMessege = "Enter the Sudoku.";
        public static string ErrorMessege = "Invalid Input.";
        public static string NotSolvable = "Not a solvable Sudoku.";
        public static string MenuMessege = "Enter your choice(1 or 2) and press enter.";
        /// <summary>
        /// Prints the options 
        /// </summary>
        public static void NewGameMessege()
        {
            Console.WriteLine();
            Console.WriteLine(" 1. New Game");
            Console.WriteLine(" 2. Exit");
            Console.WriteLine(MenuMessege);
            SudokuGrid.NewGameInput();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class SolveSudoku
    {
        /// <summary>
        /// function which checks if the element is already 
        /// present in the given Row,Col or 3x3 Grid.
        /// </summary>
        public static bool IsValidMove(int[,] Grid, int Row, int Col, int Val)
        {
            for (int i = 0; i < 9; i++)//Returns false if the givan number is already present in the given row.
            {
                if (Grid[Row, i] == Val)
                {
                    return false;
                }
            }
            for (int i = 0; i < 9; i++)//Returns false if the givan number is already present in the given column.
            {
                if (Grid[i, Col] == Val)
                {
                    return false;
                }
            }
            int RowBegin = (Row - Row % 3);
            int ColBegin = (Col - Col % 3);
            for (int i = RowBegin; i < (RowBegin + 3); i++)//Returns false if the givan number is already present in the 3x3 grid in which it is being entered.
            {
                for (int j = ColBegin; j < (ColBegin + 3); j++)
                {
                    if (Grid[i, j] == Val)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Takes a Sudoku grid in the form of 9x9 2D array and applies 
        /// backtracking to solve the sudoku.
        /// </summary>
        /// <param name="Grid"></param>
        /// <returns></returns>
        public static bool Solution(int[,] Grid)
        {
            int Row = 0;
            int Col = 0;
            bool IsEmpty = true;

            for (int i = 0; i < 9; i++)//Check for the next empty cell in the sudoku.
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Grid[i, j] == 0)//If the empty cell is found it's row and column is saved.
                    {
                        Row = i;
                        Col = j;
                        IsEmpty = false;
                        break;
                    }
                }
                if (!IsEmpty)//If empty cell is found. breaks out of the outer for loop.
                {
                    break;
                }
            }
            if (IsEmpty)
            {
                return true;
            }
            for (int Val = 1; Val <= 9; Val++)//Enters vales from 1 to 9 to check the right answer.
            {
                if (IsValidMove(Grid, Row, Col, Val))//If the entered value is not already present in the same row, column or 3x3 grid, assign it to the cell.
                {
                    Grid[Row, Col] = Val;
                    if (Solution(Grid))//Uses backtracking to check and change the answer if the entered answer is not right.
                    {
                        return true;
                    }
                    else
                    {
                        Grid[Row, Col] = 0;
                    }
                }
            }
            return false;
        }
    }
}

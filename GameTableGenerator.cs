using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class GameTableGenerator
    {
        private string[] moves;
        private MoveComparer comparer;

        public GameTableGenerator(string[] moves)
        {
            this.moves = moves;
            comparer = new MoveComparer(moves);
        }

        public string GenerateTable()
        {
            int count = moves.Length;

            //Calculating the width of each cell
            int cellWidth = Math.Max(GetMaxMoveLength(), 5);

            //Calculating the width of table
            int tableWidth = (cellWidth+ 1) * (count+2);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(GenerateHeaderRow(cellWidth));
            sb.AppendLine(GenerateHorizontalLine(tableWidth));

            for(int i = 0; i < count; i++)
            {
                string[] row = new string[count + 1];
                row[0] = moves[i];
                for (int j = 0; j < count; j++)
                {
                    int result = comparer.CompareMoves(i, j);
                    if (result == 1)
                    {
                        row[j + 1] = "Win";
                    }
                    else if (result == -1)
                    {
                        row[j + 1] = "Lose";
                    }
                    else row[j + 1] = "Draw";
                }
                sb.AppendLine(GenerateTableRow(row,cellWidth));
                sb.AppendLine(GenerateHorizontalLine(tableWidth));
            }
            return sb.ToString();
        }
        private string GenerateHeaderRow(int cellWidth)
        {
            StringBuilder sb = new StringBuilder();

            // Generate an empty cell for the top-left corner
            sb.Append("|".PadRight(cellWidth + 1));

            // Generate column headers
            for (int i = 0; i < moves.Length; i++)
            {
                sb.Append("|");
                sb.Append(moves[i].PadCenter(cellWidth));
            }
            sb.Append("|");

            return sb.ToString();
        }

        private string GenerateTableRow(string[] items, int cellWidth)
        {
            StringBuilder sb = new StringBuilder();

            for(int i =0; i<items.Length; i++)
            {
                sb.Append('|');
                sb.Append(items[i].PadCenter(cellWidth));
            }
            sb.Append('|');
            return sb.ToString();
        }
        private string GenerateHorizontalLine(int tableWidth)
        {
            return new string('-', tableWidth);
        }
        private int GetMaxMoveLength()
        {
            int maxLength = 0;
            foreach(string move in moves)
            {
                maxLength = Math.Max(maxLength, move.Length);
            }
            return maxLength;
        }
        public int CompareMoves(int move1, int move2)
        {
            return comparer.CompareMoves(move1, move2);
        }
    }
    public static class StringExtensions
    {
        public static string PadCenter(this string s,int width)
        {
            int padding = width - s.Length;
            if (padding <= 0)
                return s;

            int padLeft = padding / 2 + s.Length;
            return s.PadLeft(padLeft).PadRight(width);
        }
    }
}

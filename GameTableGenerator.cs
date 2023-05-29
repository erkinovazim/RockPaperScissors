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

        public string[,] GenerateTable()
        {
            int count = moves.Length;
            string[,] table = new string[count + 1, count + 1];

            // Fill row and column headers
            for (int i = 0; i < count; i++)
            {
                table[i + 1, 0] = table[0, i + 1] = moves[i];
            }

            // Fill table cells
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    int result = comparer.CompareMoves(i, j);
                    if (result == 1)
                        table[i + 1, j + 1] = "Win";
                    else if (result == -1)
                        table[i + 1, j + 1] = "Lose";
                    else
                        table[i + 1, j + 1] = "Draw";
                }
            }

            return table;
        }

        public int CompareMoves(int move1, int move2)
        {
            return comparer.CompareMoves(move1, move2);
        }
    }
}

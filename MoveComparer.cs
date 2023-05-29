using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class MoveComparer
    {
        private Dictionary<int, int> moveMap;

        public MoveComparer(string[] moves)
        {
            moveMap = new Dictionary<int, int>();
            int count = moves.Length;
            int half = count / 2;

            for (int i = 0; i < count; i++)
            {
                int prev = (i - half + count) % count;
                int next = (i + half) % count;
                moveMap[i] = prev;
                moveMap[prev] = next;
            }
        }

        public int CompareMoves(int move1, int move2)
        {
            if (moveMap[move1] == move2)
                return 1; // move1 wins
            else if (moveMap[move2] == move1)
                return -1; // move2 wins
            else
                return 0; // draw
        }
    }
}

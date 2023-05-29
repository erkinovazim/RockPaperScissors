using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class Game
    {
        private string[] moves;
        private HMACGenerator hmacGenerator;
        private GameTableGenerator tableGenerator;
        private Random random;

        public Game(string[] moves)
        {
            if (moves.Length < 3 || moves.Length % 2 == 0)
            {
                throw new ArgumentException("Invalid number of moves. Example: rock paper scissors");
            }

            this.moves = moves;
            hmacGenerator = new HMACGenerator();
            tableGenerator = new GameTableGenerator(moves);
            random = new Random();
        }

        private int GetComputerMove()
        {
            return random.Next(1, moves.Length + 1);
        }

        private void DisplayTable()
        {
            string table = tableGenerator.GenerateTable();

            Console.WriteLine("Game Table:");
            Console.WriteLine(table);
            Console.WriteLine();
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Available moves:");
            for (int i = 0; i < moves.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {moves[i]}");
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
        }

        public void Play()
        {
            byte[] hmac = hmacGenerator.ComputeHMAC(Encoding.UTF8.GetBytes(moves[GetComputerMove() - 1]));
            string hmacString = BitConverter.ToString(hmac).Replace("-", string.Empty);

            Console.WriteLine($"HMAC: {hmacString}");
            Console.WriteLine();

            while (true)
            {
                DisplayMenu();
                Console.Write("Enter your move: ");
                string input = Console.ReadLine();

                if (input == "?")
                {
                    Console.WriteLine();
                    DisplayTable();
                    continue;
                }

                if (!int.TryParse(input, out int userMove) || userMove < 0 || userMove > moves.Length)
                {
                    Console.WriteLine("Invalid move. Please try again.");
                    Console.WriteLine();
                    continue;
                }

                if (userMove == 0)
                    break;

                Console.WriteLine();
                Console.WriteLine($"Your move: {moves[userMove - 1]}");

                int computerMove = GetComputerMove();
                Console.WriteLine($"Computer move: {moves[computerMove - 1]}");

                int result = tableGenerator.CompareMoves(userMove - 1, computerMove - 1);
                if (result == 1)
                    Console.WriteLine("You win!");
                else if (result == -1)
                    Console.WriteLine("Computer wins!");
                else
                    Console.WriteLine("It's a draw!");

                Console.WriteLine($"HMAC key: {hmacGenerator.GetKey()}");
                Console.WriteLine();
            }
        }
    }
}

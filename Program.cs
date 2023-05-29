using RockPaperScissors;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            if (args.Length < 3 || args.Length % 2 == 0)
            {
                Console.WriteLine("Invalid number of moves. Example: rock paper scissors");
                return;
            }

            Game game = new Game(args);
            game.Play();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

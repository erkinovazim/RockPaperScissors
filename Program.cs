using RockPaperScissors;
public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            if (args.Length < 3 || args.Length % 2 == 0 || CheckDuplicateInputs(args))
            {
                Console.WriteLine("Invalid number of moves. Example: dotnet run rock paper scissors");
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
    private static bool CheckDuplicateInputs(string[] args)
    {
        bool hasDuplicates = false;
        HashSet<string> uniqueInputs = new HashSet<string>();
        foreach (string input in args)
        {
            if (!uniqueInputs.Add(input))
            {
                hasDuplicates = true;
                break;
            }
        }
        if (hasDuplicates)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

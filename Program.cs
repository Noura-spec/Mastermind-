using System;

class Program
{
    static void Main(string[] args)
    {
        string codeArg = null;
        int maxAttempts = 10;

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-c" && i + 1 < args.Length)
                codeArg = args[i + 1];
            if (args[i] == "-t" && i + 1 < args.Length && int.TryParse(args[i + 1], out int t))
                maxAttempts = t;
        }

        MastermindGame game = new MastermindGame(codeArg, maxAttempts);
        game.Start();
    }
}

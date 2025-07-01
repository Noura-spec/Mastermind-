using System;

class MastermindGame
{
    private readonly Code secretCode;
    private readonly int maxAttempts;

    public MastermindGame(string code, int attempts)
    {
        secretCode = new Code(code);
        maxAttempts = attempts;
    }

    public void Start()
    {
        Console.WriteLine("Can you break the code? Enter a valid guess.");

        for (int round = 0; round < maxAttempts; round++)
        {
            Console.WriteLine($"---\nRound {round}");

            string input = Console.ReadLine();

            if (input == null)
            {
                Console.WriteLine("End of input. Goodbye!");
                return;
            }

            if (!InputValidator.IsValidGuess(input))
            {
                Console.WriteLine("Wrong input!");
                round--; // Don't count invalid input as an attempt
                continue;
            }

            if (secretCode.IsCorrect(input))
            {
                Console.WriteLine("Congratz! You did it!");
                return;
            }

            int wellPlaced = secretCode.CountWellPlaced(input);
            int misplaced = secretCode.CountMisplaced(input);

            Console.WriteLine($"Well placed pieces: {wellPlaced}");
            Console.WriteLine($"Misplaced pieces: {misplaced}");
        }

        Console.WriteLine("---\nGame over. You couldn't crack the code.");
    }
}

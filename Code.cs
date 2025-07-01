
using System;
using System.Linq;

class Code
{
    private readonly string secret;

    public Code(string code)
    {
        if (!string.IsNullOrEmpty(code) && InputValidator.IsValidGuess(code))
            secret = code;
        else
            secret = GenerateRandomCode();
    }

    private string GenerateRandomCode()
    {
        var digits = "012345678".ToCharArray().OrderBy(x => Guid.NewGuid()).Take(4);
        return new string(digits.ToArray());
    }

    public bool IsCorrect(string guess) => guess == secret;

    public int CountWellPlaced(string guess)
    {
        int count = 0;
        for (int i = 0; i < 4; i++)
            if (guess[i] == secret[i]) count++;
        return count;
    }

    public int CountMisplaced(string guess)
    {
        int misplaced = 0;
        for (int i = 0; i < 4; i++)
        {
            if (guess[i] != secret[i] && secret.Contains(guess[i]) && guess.IndexOf(guess[i]) != secret.IndexOf(guess[i]))
                misplaced++;
        }

        return misplaced - CountOverlaps(guess);
    }

    private int CountOverlaps(string guess)
    {
       
        return guess.Distinct().Sum(ch => Math.Max(0, guess.Count(g => g == ch) - 1));
    }
}


using System.Linq;

class InputValidator
{
    public static bool IsValidGuess(string guess)
    {
        if (guess.Length != 4 || !guess.All(char.IsDigit))
            return false;

        if (!guess.All(c => "012345678".Contains(c)))
            return false;

        return guess.Distinct().Count() == 4;
    }
}

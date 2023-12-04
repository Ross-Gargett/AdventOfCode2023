// Part 1

using System.Text.RegularExpressions;

var input = File.ReadAllLines("input.txt");

var answer = input
    .Select(x => int.Parse(GetFirstAndLastDigit(x)))
    .Sum();

Console.WriteLine(answer);

string GetFirstAndLastDigit(string text)
{
    return $"{GetFirstDigit(text)}{GetLastDigit(text)}";

    char GetLastDigit(string s)
    {
        for (var i = s.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(s[i]))
                return s[i];
        }

        throw new Exception("No digit found");
    }

    char GetFirstDigit(string s)
    {
        return s.SkipWhile(c => !char.IsDigit(c)).Take(1).First();
    }
}

//Part 2
//match any number either as a digit or a string
var regex = new Regex("(one|two|three|four|five|six|seven|eight|nine|\\d)");
var backwardsRegex = new Regex("(one(?!ight)|two(?!ne)|three(?!ight)|four|five(?!ight)|six|seven(?!ine)|eight(?!wo)|nine(?!ight)|\\d)");

var numberMapping = new Dictionary<string, int>()
{
    {"one", 1},
    {"two", 2},
    {"three", 3},
    {"four", 4},
    {"five", 5},
    {"six", 6},
    {"seven", 7},
    {"eight", 8},
    {"nine", 9},
};

string GetFirstAndLastDigitIncludingLetters(string text)
{
    var forwardMatch = regex.Match(text);
    var backwardsMatches = backwardsRegex.Matches(text);
    return $"{GetNumberAsParsable(forwardMatch.Value)}{GetNumberAsParsable(backwardsMatches.Last().Value)}";

    string GetNumberAsParsable(string digit)
    {
        return numberMapping.TryGetValue(digit, out var realNumber) 
            ? $"{realNumber}" 
            : digit;
    }
}

var correctAnswer = input
    .Select(x => int.Parse(GetFirstAndLastDigitIncludingLetters(x)))
    .Sum();

Console.WriteLine(correctAnswer);
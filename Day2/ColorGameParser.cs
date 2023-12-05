using System.Text.RegularExpressions;

namespace Day2;

public class ColorGameParser
{
    private static readonly Regex ColorPattern = new (@"(\d+)\s*(red|green|blue)");
    
    public GameSummary ParseGame(string gameStr)
    {
        var game = Regex.Match(gameStr, @"Game (\d+): (.+)$");

        if (!game.Success) throw new Exception($"Could not parse game: {gameStr}");
    
        var gameId = int.Parse(game.Groups[1].Value);
    
        var colors = ColorPattern.Matches(game.Groups[2].Value)
            .Select(x => new { Color = x.Groups[2].Value, Count = int.Parse(x.Groups[1].Value) })
            .ToList();
    
        return new GameSummary
        {
            Id = gameId,
            MaxRed = colors.Where(x => x.Color == "red").Max(x => x.Count),
            MaxBlue = colors.Where(x => x.Color == "blue").Max(x => x.Count),
            MaxGreen = colors.Where(x => x.Color == "green").Max(x => x.Count),
        };
    }
}
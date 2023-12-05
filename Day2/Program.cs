using Day2;

const int maxRed = 12, maxBlue = 14, maxGreen = 13;

var input = File.ReadAllLines("input.txt");

var parser = new ColorGameParser();

var games = input
    .Select(x => parser.ParseGame(x))
    .ToList();

var answer = games
    .Where(game => game is {MaxRed: <= maxRed, MaxBlue: <= maxBlue, MaxGreen: <= maxGreen})
    .Sum(game => game.Id);

Console.WriteLine(answer);

var answer2 = games
    .Select(game => game.MaxBlue * game.MaxGreen * game.MaxRed)
    .Sum();
    
Console.WriteLine(answer2);
var file = File.ReadAllLines("../aoc_day_2");

var totalSum = 0;
foreach(var line in file)
{
    var totalProduct = 1;
    var gameId = ParseId(line);
    var gameSetStrings = line.Substring(line.IndexOf(':')).Split(";").ToList();

    var maxRed = int.MinValue;
    var maxGreen = int.MinValue;
    var maxBlue = int.MinValue;

    foreach(var gameSet in gameSetStrings)
    {
      var newGameSet = new GameSet(gameId, gameSet);

      maxRed = newGameSet.Red == 0 ? maxRed : Math.Max(maxRed, newGameSet.Red);
      maxGreen = newGameSet.Green == 0 ? maxGreen :  Math.Max(maxGreen, newGameSet.Green);
      maxBlue =  newGameSet.Blue == 0 ? maxBlue :  Math.Max(maxBlue, newGameSet.Blue);
    }

    totalProduct = maxRed * maxGreen * maxBlue;
    totalSum += totalProduct;
}

Console.WriteLine($"Total Sum of game minimum products: {totalSum}");

static int ParseId( string line)
{
    int id = -1;
    id = char.IsDigit(line[7]) ? int.Parse(line[5..8]) 
      : char.IsDigit(line[6]) ? int.Parse(line[5..7]) 
      : int.Parse(line[5..6]);
    return id;
}

class GameSet
{
    public GameSet(int gameId, string gameSet)
    {
      GameId = gameId;
      Red = GetAmountForGameSetColor(gameSet, "red");
      Green = GetAmountForGameSetColor(gameSet, "green");;
      Blue = GetAmountForGameSetColor(gameSet, "blue");
    }

    public int GameId { get; set; }
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }

    public int GetAmountForGameSetColor(string gameSet, string color)
    {
          int amount = 0;
          var index = gameSet.IndexOf(color);

          amount = index - 3 >= 0 && char.IsDigit(gameSet[index - 3]) ? amount = int.Parse(gameSet.Substring((index - 3), 2))
            : index - 2 >= 0 && char.IsDigit(gameSet[index - 2]) ? amount = int.Parse(gameSet[(index - 2)].ToString()) 
            : 0;

          return amount;
    }
}

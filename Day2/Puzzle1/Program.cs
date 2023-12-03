
var file = File.ReadAllLines("/home/wamcr/dotnet/AdventOfCode2023_CSharp/Day2/aoc_day_2");

int sumOfPassingIndexes = 0;

foreach(var line in file)
{
    var gameId = ParseId(line);
    var gameSetStrings = line.Substring(line.IndexOf(':')).Split(";").ToList();

    bool isPassing = true;
    foreach(var gameSet in gameSetStrings)
    {
      var gameSetObj = new GameSet(gameId, gameSet);

      if(!gameSetObj.IsGameSetPassing())
      {
        isPassing = false;
        break;
      }
    }
    if(isPassing)
      sumOfPassingIndexes += gameId;
}

Console.WriteLine($"Sum of passing indexes: {sumOfPassingIndexes}");


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

    public bool IsGameSetPassing()
    {
      return Red <= 12  && Green <= 13 && Blue <= 14;
    }
}

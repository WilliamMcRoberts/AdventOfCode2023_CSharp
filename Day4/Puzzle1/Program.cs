
var file = File.ReadAllLines("../aoc_day_4");

var total = 0;

foreach(var f in file)
{
  var gameIdAndNumbers = f.Split(":", StringSplitOptions.RemoveEmptyEntries);
  var cardId = gameIdAndNumbers[0].Trim().Split(" ")[1];
  var numberSets = gameIdAndNumbers[1].Trim().Split("|");
  var winningNumbers = numberSets[0].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x));
  var myNumbers = numberSets[1].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x));

  int points = 0;
  foreach(var winningNum in winningNumbers)
  {
    if(myNumbers.Contains(winningNum))
    {
        points = points == 0 ? 1 : points * 2;
    }
  }
  total += points;
  points = 0;
}

Console.WriteLine($"Total: {total}");

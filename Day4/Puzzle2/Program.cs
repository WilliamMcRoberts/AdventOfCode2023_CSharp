var file = File.ReadAllLines("../aoc_day_4");

int[] cardCount = Enumerable.Repeat(1, file.Length).ToArray();

for(int i = 0; i < file.Length; i++)
{
  var sections = file[i].Split(":");
  var numbers = sections[1].Split("|");
  var winningNumbers = numbers[0]
    .Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
    .Select(int.Parse)
    .ToArray();

  var myNumbers = numbers[1]
    .Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
    .Select(int.Parse)
    .ToArray();

  var matchingNumbersCount = winningNumbers.Intersect(myNumbers).Count();

  for(int j = 0; j < matchingNumbersCount; j++)
  {
    cardCount[i + 1 + j] += cardCount[i];
  }
}

Console.WriteLine($"Total: {cardCount.Sum()}");

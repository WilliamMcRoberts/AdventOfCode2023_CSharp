
var file = File.ReadAllLines("/home/wamcr/dotnet/AdventOfCode2023_CSharp/Day1/aoc_day_1");

long total = 0;

foreach (var line in file)
{
  int first = line.First(c => char.IsDigit(c)) - '0';
  int last = line.Last(c => char.IsDigit(c)) - '0';

  var linetotal = (first * 10) + last;

  total += linetotal;
}

Console.WriteLine($"total: {total}");

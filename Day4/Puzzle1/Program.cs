﻿
var file = File.ReadAllLines("../aoc_day_4");

int total = 0;

foreach(var f in file)
{
  var sections = f.Split(":");
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

  if(matchingNumbersCount == 0) continue;

   // total += (1 << (matchingNumbersCount - 1));
   total += (int)Math.Pow(2, matchingNumbersCount - 1);
}

Console.WriteLine($"Total: {total}");

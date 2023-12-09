var file = File.ReadAllLines("../aoc_day_6");

var totalTime = long.Parse(
    file[0]
    ["Time:".Length..]
    .Replace(" ", string.Empty));
var record = long.Parse(
    file[1]
    ["Distance:".Length..]
    .Replace(" ", string.Empty));

var d = totalTime * totalTime - 4 * (record + 1);
var x1 = (totalTime + Math.Sqrt(d)) / 2;
var x2 = (totalTime - Math.Sqrt(d)) / 2;

var time = (long)Math.Ceiling(Math.Min(x1, x2));
var total = (totalTime - time) - time + 1;

Console.WriteLine($"Total: {total}");
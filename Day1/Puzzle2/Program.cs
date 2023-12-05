
var file = File.ReadAllLines("../aoc_day_1");

Dictionary<string, int> dict = new()
{
  { "zero", 0 },
  { "one", 1 },
  { "two", 2 },
  { "three", 3 },
  { "four", 4 },
  { "five", 5 },
  { "six", 6 },
  { "seven", 7 },
  { "eight", 8 },
  { "nine", 9 }
};

for (int i = 0; i < 10; i++)
{
  dict.Add(i.ToString(), i);
}

long total = 0;

foreach (var line in file)
{
  var firstIndex = line.Length;
  var lastIndex = -1;
  var firstValue = 0;
  var lastValue = 0;

  foreach(var number in dict)
  {
    var index = line.IndexOf(number.Key);
    if (index < 0) continue;

    if (index < firstIndex)
    {
      firstIndex = index;
      firstValue = number.Value;
    }

    index = line.LastIndexOf(number.Key);

    if (index > lastIndex)
    {
      lastIndex = index;
      lastValue = number.Value;
    }
  }
  var linetotal = (firstValue * 10) + lastValue;

  total += linetotal;
}

Console.WriteLine($"total: {total}");

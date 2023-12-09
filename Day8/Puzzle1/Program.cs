
var file = File.ReadAllLines("../aoc_day_8");
var directions = file[0];
var dict =
    new Dictionary<string, (string, string)>();

for (int index = 2; index < file.Length; index++)
{
    var sections = file[index].Split("=", StringSplitOptions.TrimEntries);
    var element = sections[0];
    var lr = sections[1].Trim(['(', ')']);
    var l = lr.Split(",", StringSplitOptions.TrimEntries)[0];
    var r = lr.Split(",", StringSplitOptions.TrimEntries)[1];

    dict.Add(element, (l, r));
}

string currentElement = "AAA";
int total = 0;
int directionsIndex = 0;
while (currentElement != "ZZZ")
{
    if (directionsIndex == directions.Length)
    {
        directionsIndex = 0;
        continue;
    }

    (string left, string right) = dict[currentElement];

    currentElement = directions[directionsIndex] switch
    {
        'L' => left,
        'R' => right,
        _ => throw new Exception("Invalid Direction"),
    };

    total++;
    directionsIndex++;
}

Console.WriteLine($"Total: {total}");

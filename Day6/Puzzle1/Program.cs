var file = File.ReadAllLines("../aoc_day_6");

var times = file[0]
        ["Time:".Length..]
        .Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        .Select(int.Parse)
        .ToArray();

var records = file[1]
        ["Distance:".Length..]
        .Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        .Select(int.Parse)
        .ToArray();

var total = 1;

for (int race = 0; race < times.Length; race++)
{
    var waysToWin = 0;
    var totalTime = times[race];
    var record = records[race];

    for (int time = 0; time < totalTime; time++)
    {
        if (time * (totalTime - time) > record)
        {
            waysToWin++;
        }
    }

    total *= waysToWin;
}

Console.WriteLine($"Total: {total}");

var lines = File.ReadAllLines("../aoc_day_11").ToList();

long SumOfGalaxyDistances(List<string> lines, int expansion)
{
    // Expand rows
    List<int> rowExpansions = new();
    for (var i = 0; i < lines.Count; i++)
    {
        if (lines[i].All(x => x == '.')) 
            rowExpansions.Add(i);
    }
    
    // Expand columns
    List<int> columnExpansions = new();
    for (var i = 0; i < lines[0].Length; i++)
    {
        var foundGalaxy = false;
        foreach (var line in lines)
        {
            if (line[i] == '#')
                foundGalaxy = true;
        }
    
        if (!foundGalaxy) 
            columnExpansions.Add(i);
    }
    
    // Map galaxies
    List<(int y, int x)> galaxies = new();
    for (var y = 0; y < lines.Count; y++)
    {
        for (var x = 0; x < lines[0].Length; x++)
        {
            if (lines[y][x] == '#')
            {
                int yExpansion;
                for (yExpansion = 0; yExpansion < rowExpansions.Count; yExpansion++)
                {
                    if (rowExpansions[yExpansion] > y) break;
                }
                
                int xExpansion;
                for (xExpansion = 0; xExpansion < columnExpansions.Count; xExpansion++)
                {
                    if (columnExpansions[xExpansion] > x) break;
                }

                galaxies.Add((y + yExpansion * expansion, x + xExpansion * expansion));
            }
        }
    }
    
    int sum = 0;
    foreach (var (y1, x1) in galaxies)
    {
        foreach (var (y2, x2) in galaxies)
        {
            sum += Math.Abs(y1 - y2) + Math.Abs(x1 - x2);
        }
    }

    // ???
    return sum / 2;
}

var sum = SumOfGalaxyDistances(lines, 1);
Console.WriteLine($"Sum: {sum}");


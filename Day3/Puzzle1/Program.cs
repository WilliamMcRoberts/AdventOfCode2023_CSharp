
var file = File.ReadAllLines("../aoc_day_3");

var width = file[0].Length;
var height = file.Length;

(int, int)[] directions = [(0, 1), (1, 0), (0, -1), (-1, 0), (1, 1), (-1, -1), (-1, 1), (1, -1)];

var map = new char[width, height];

for (var x = 0; x < width; x++)
{
    for (var y = 0; y < height; y++)
    {
        map[x, y] = file[y][x];
    }
}

var total = 0;
var currentNumber = 0;
var isAdjacent = false;

for (var i = 0; i < height; i++)
{
    for (var j = 0; j < height; j++)
    {
        var character = map[j, i];

        if (char.IsDigit(character))
        {
            var value = character - '0';
            currentNumber = currentNumber * 10 + value;
            foreach (var direction in directions)
            {
                var neigbhorJ = j + direction.Item1;
                var neigbhorI = i + direction.Item2;
                if (neigbhorJ < 0 || neigbhorJ >= width || neigbhorI < 0 || neigbhorI >= height)
                    continue;
                var neighborCharacter = map[neigbhorJ, neigbhorI];
                isAdjacent = !char.IsDigit(neighborCharacter) && neighborCharacter != '.' ? true : isAdjacent;
            }
        }
        else 
        {
            total = currentNumber != 0 && isAdjacent ? total + currentNumber : total;
            currentNumber = 0;
            isAdjacent = false;
        }
    }
    total = currentNumber != 0 && isAdjacent ? total + currentNumber : total;
    currentNumber = 0;
    isAdjacent = false;
}

Console.WriteLine($"Total: {total}");

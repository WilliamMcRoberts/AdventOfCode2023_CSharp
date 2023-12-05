// var file =  "467..114.. ...*...... ..35..633. ......#... 617*...... .....+.58. ..592..... ......755. ...$.*.... .664.598..".Split(" ").ToArray();

var file = File.ReadAllLines("../aoc_day_3");

(int, int)[] directions = [(0, 1), (1, 0), (0, -1), (-1, 0), (1, 1), (-1, -1), (-1, 1), (1, -1)];

var width = file[0].Length;
var height = file.Length;

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
var stars = new Dictionary<Point, List<int>>();
var neighboringStars = new HashSet<Point>();

for (var y = 0; y < height; y++)
{
    void EndCurrentNumber()
    {
        if (currentNumber != 0 && neighboringStars.Count > 0)
        {
            foreach (var neighboringStar in neighboringStars)
            {
                var x = neighboringStar.X;
                var y = neighboringStar.Y;
                if (!stars.ContainsKey((x, y)))
                {
                    stars[(x, y)] = [];
                }

                stars[(x, y)].Add(currentNumber);
            }
        }
        currentNumber = 0;
        neighboringStars.Clear();
    }

    for (var x = 0; x < height; x++)
    {
        var character = map[x, y];
        // check if we are reading a number
        if (char.IsDigit(character))
        {
            var value = character - '0';
            currentNumber = currentNumber * 10 + value;
            foreach (var direction in directions)
            {
                var neigbhorX = x + direction.Item1;
                var neigbhorY = y + direction.Item2;
                if (neigbhorX < 0 || neigbhorX >= width || neigbhorY < 0 || neigbhorY >= height)
                {
                    continue;
                }

                var neighborCharacter = map[neigbhorX, neigbhorY];
                if (neighborCharacter == '*')
                {
                    neighboringStars.Add((neigbhorX, neigbhorY));
                }
            }
        }
        else 
        {
            EndCurrentNumber();
        }
    }

    EndCurrentNumber();
}

foreach (var (point, numbers) in stars)
{
    if (numbers.Count == 2)
    {
        total += numbers[0] * numbers[1];
    }
}

Console.WriteLine(total);

public record struct Point(int X, int Y)
{
    public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);
    
    public static Point operator -(Point a, Point b) => new Point(a.X - b.X, a.Y - b.Y);

    public Point Normalize() => new Point(X != 0 ? X / Math.Abs(X) : 0, Y != 0 ? Y / Math.Abs(Y) : 0);

    public static implicit operator Point((int X, int Y) tuple) => new Point(tuple.X, tuple.Y);

    public int ManhattanDistance(Point b) => Math.Abs(X - b.X) + Math.Abs(Y - b.Y);
}

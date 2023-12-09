var file = File.ReadAllLines("../aoc_day_8");
var directions = file[0];
var dict =
    new Dictionary<string, (string, string)>();

var startingElements = new List<string>();
for (int index = 2; index < file.Length; index++)
{
    var sections = file[index].Split("=", StringSplitOptions.TrimEntries);
    var element = sections[0];
    var lr = sections[1].Trim(['(', ')']);
    var l = lr.Split(",", StringSplitOptions.TrimEntries)[0];
    var r = lr.Split(",", StringSplitOptions.TrimEntries)[1];

    dict.Add(element, (l, r));
    if(element[2] == 'A') startingElements.Add(element);
}


List<long> countList = [];
foreach (var elem in startingElements)
{
    string key = elem;
    var count = 0;
    for (var i = 0; i < directions.Length; i++)
    {
        if (key.EndsWith("Z"))
            break;
        
        (string left, string right) = dict[key];
    
        key = directions[i] == 'L' ? left : right;
        count++;
    
        if (directions.Length == i+1)
            i = -1;
    
    }
    countList.Add(count);
}

var total = CalculateLcmFromList(countList);

Console.WriteLine("Total: " + total);

static long CalculateLcmFromList(List<long> numbers)
{
    return numbers.Aggregate(Lcm);
}
static long Lcm(long a, long b)
{
    return Math.Abs(a * b) / Gcd(a, b);
}
static long Gcd(long a, long b)
{
    return b == 0 ? a : Gcd(b, a % b);
}


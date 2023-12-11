var file = File.ReadAllLines("../aoc_day_9");


int Calculate(bool reverse)
{
    List<List<int>> histories = file.Select(x =>
            {
                var buffer = x
                    .Split(' ')
                    .Select(int.Parse)
                    .ToList();
                if (reverse)
                    buffer.Reverse();
                return buffer;
            })
        .ToList();

    var sum = 0;
    foreach (var history in histories)
    {
        List<int> historyNew = [];
        List<int> historyTemp = history;
        List<int> lastValues = [history.Last()];

        while (historyTemp.Any(x => x != 0))
        {
            historyNew.Clear();
            for (var i = 0; i < historyTemp.Count - 1; i++)
            {
                historyNew.Add(historyTemp[i + 1] - historyTemp[i]);
            }

            lastValues.Add(historyNew.Last());
            historyTemp = historyNew[..];
        }

        lastValues.Reverse();
        sum += lastValues.Aggregate((a, b) => a + b);
    }

    return sum;
}

var total = Calculate(false);
Console.WriteLine("Total: " + total);





using System;
using System.Text;

char[][] input = File.ReadAllLines("../aoc_day_14").Select(x => x.ToCharArray()).ToArray(); 

for (int i = 1; i < input.Length; i++)
{
  for(int j = 0; j < input[i].Length; j++)
  {
    if (input[i][j] != 'O')
					continue;     

    for (var k = i; k > 0 && input[k - 1][j] == '.'; k--)
				{
          (input[k - 1][j], input[k][j]) = (input[k][j], input[k - 1][j]);
				}
  }
}

int total = 0;
for(int i = 0; i < input.Length; i++)
{
  total += (input[i].Count(x => x == 'O') * (input.Length - i));
}

Console.WriteLine($"Total: {total}");

using System.Diagnostics;

int size = 1_000_0000;
int[] array = Enumerable.Range(1,size).Select(item => new Random().Next(1, 10)).ToArray();
int m = 3000;
// Console.WriteLine($"[{string.Join(", ", array)}]");

Stopwatch sw = new();
sw.Start();

int t = 0;
for (int i = 0; i < size-m+1; i++)
{
    int sum = 0;
    for (int j = i; j < i+m; j++)
    {
        sum += array[j];
        if (sum>t) t = sum;
    }
}

sw.Stop();
Console.WriteLine(t);
Console.WriteLine($"time = {sw.ElapsedMilliseconds}");


sw = new();
sw.Start();
int sum2 = 0;
for (int i = 0; i < m; i++)
{
    sum2 += array[i];
}
int t2 = sum2;

for (int j = m; j < size; j++)
{
    sum2 = sum2 + array[j] - array[j-m];
    if (sum2>t2) t2 = sum2;
}
sw.Stop();
Console.WriteLine(t2);
Console.WriteLine($"time = {sw.ElapsedMilliseconds}");
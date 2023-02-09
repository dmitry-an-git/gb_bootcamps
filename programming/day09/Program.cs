int[] array = new int[100];
Random _rand = new Random();
for (int i = 0; i < array.Length; i++)
{
    array[i] = _rand.Next(0,10);
}

int max = 0;
for (int i = 0; i < array.Length; i++)
{
    if (array[i]>max)
    {
        max = array[i];
    }
}

int[] counter = new int[max+1];

for (int i = 0; i < array.Length; i++)
{
    counter[array[i]]+=1;
}

Console.WriteLine($"{string.Join(", ",counter)}");

int[] sortedArray = new int[100];

int position = 0;
for (int i = 0; i < counter.Length; i++)
{
    for (int j = 0; j < counter[i]; j++)
    {
        sortedArray[position] = i;
        position++;
    }
}

Console.WriteLine($"{string.Join(", ",sortedArray)}");
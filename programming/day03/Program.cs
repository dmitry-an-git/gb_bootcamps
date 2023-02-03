

int[] SelectionSort(int[] collection)
{
    int size = collection.Length;
    for (int i = 0; i < size-1; i++)
    {
        int pos = i;
        for (int j = i+1; j < size; j++)
        {
            if (collection[pos]>collection[j]) pos = j;
        }

        int temp = collection[pos];
        collection[pos] = collection[i];
        collection[i] = temp;
    }
    return collection;
}


int size = 10;
int[] array = Enumerable.Range(1,size).Select(item => new Random().Next(1, 10)).ToArray();
Console.WriteLine($"[{string.Join(", ",array)}]");
array = SelectionSort(array);
Console.WriteLine($"[{string.Join(", ",array)}]");
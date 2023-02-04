Console.Clear();
Console.WriteLine("pls input array length: ");
int size = Convert.ToInt32(Console.ReadLine());
int[] array = new int[size];

for (int i = 0; i < size; i++)
{
    array[i] = new Random().Next(1, 10);
}

Console.WriteLine($"Ваш массив: [{string.Join(", ",array)}]");

for (int i = 0; i < size; i++)
{
    for (int j = 0; j < size-1; j++)
    {
        if (array[j]>array[j+1]) 
        {
            int temp = array[j];
            array[j] = array[j+1];
            array[j+1] = temp;
        }
    }
}
Console.WriteLine($"Сортированный массив: [{string.Join(", ",array)}]");

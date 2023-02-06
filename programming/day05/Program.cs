// See https://aka.ms/new-console-template for more information

Console.Clear();
Console.WriteLine("pls input array length: ");
int size = Convert.ToInt32(Console.ReadLine());
int[] array = new int[size];

for (int i = 0; i < size; i++)
{
   array[i] = new Random().Next(1, 10);
}

Console.WriteLine($"Ваш массив: [{string.Join(", ",array)}]");

int[] QuickSort(int[] array, int start, int end)
{

    int pivot_pos = (start+end)/2;
    int pivot = array[pivot_pos];
    int left = start;
    int right = end;


    while (left <= right)
    {
        while (array[left]<pivot) left++;
        while (array[right]>pivot) right--;
        if (left<=right)
        {
            int t = array[left];
            array[left] = array[right];
            array[right] = t;
            left++;
            right--;
        }
    }

    if (left < end) QuickSort(array,left,end);
    if (start < right) QuickSort(array,start,right);
    return array;
}



array = QuickSort(array,0,size-1);
Console.WriteLine($"Сортированный массив: [{string.Join(", ",array)}]");

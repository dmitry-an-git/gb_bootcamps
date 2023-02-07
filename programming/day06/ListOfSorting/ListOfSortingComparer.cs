namespace ListOfSorting
{
    public class ListOfSortingComparer
    {
        static void Swap(ref int leftValue, ref int rightValue)
        {
            int temp = leftValue;
            leftValue = rightValue;
            rightValue = temp;
        }

        public static void QuickSort(int[] inputArray, int minIndex, int maxIndex)
        {
            static int GetPivotIndex(int[] inputArray, int minIndex, int maxIndex)
            {
                int pivotIndex = minIndex - 1;
                for (int i = minIndex; i <= maxIndex; i++)
                {
                    if (inputArray[i] < inputArray[maxIndex])
                    {
                        pivotIndex++;
                        Swap(ref inputArray[i], ref inputArray[pivotIndex]);
                    }
                }
                pivotIndex++;
                Swap(ref inputArray[pivotIndex], ref inputArray[maxIndex]);
                return pivotIndex;
            }

            if (minIndex >= maxIndex) return;
            int pivot = GetPivotIndex(inputArray, minIndex, maxIndex);
            QuickSort(inputArray, minIndex, pivot - 1);
            QuickSort(inputArray, pivot + 1, maxIndex);
            return;
        }
        public static void BubbleSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length - 1 - i; j++)
                {
                    if (inputArray[j] > inputArray[j + 1])
                    {
                        Swap(ref inputArray[j], ref inputArray[j + 1]);
                    }
                }
            }
        }
        public static void SelectionSort(int[] inputArray)
        {

            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                //поиск минимального числа
                int min = i;
                for (int j = i + 1; j < inputArray.Length; j++)
                {
                    if (inputArray[j] < inputArray[min])
                    {
                        min = j;
                    }
                }
                Swap(ref inputArray[min], ref inputArray[i]);
            }
            return;
        }
    }
}

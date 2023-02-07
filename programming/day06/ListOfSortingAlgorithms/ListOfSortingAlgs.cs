namespace ListOfSorting
{
    public class ListOfSortingAlgs
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

        public static void CountingSort(int[] inputArray)
        {
            //поиск минимального и максимального значений
            var min = inputArray[0];
            var max = inputArray[0];
            foreach (int element in inputArray)
            {
                if (element > max)
                {
                    max = element;
                }
                else if (element < min)
                {
                    min = element;
                }
            }

            //поправка
            var correctionFactor = min != 0 ? -min : 0;
            max += correctionFactor;

            var count = new int[max + 1];
            for (var i = 0; i < inputArray.Length; i++)
            {
                count[inputArray[i] + correctionFactor]++;
            }
            var index = 0;
            for (var i = 0; i < count.Length; i++)
            {
                for (var j = 0; j < count[i]; j++)
                {
                    inputArray[index] = i - correctionFactor;
                    index++;
                }
            }

            return;
        }
        public static void ShakerSort(int[] listS)
        {
            int left = 0,
                right = listS.Length - 1,
                count = 0;

            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    count++;
                    if (listS[i] > listS[i + 1])
                        Swap(ref listS[i], ref listS[i + 1]);
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    count++;
                    if (listS[i - 1] > listS[i])
                        Swap(ref listS[i - 1], ref listS[i]);
                }
                left++;
            }
        }
    }
}

using BenchmarkDotNet.Attributes;
using ListOfSorting;

namespace TestSortList
{
    [MemoryDiagnoser]
    [RankColumn]
    public class ListOfSortingBenchmark
    {
        //private readonly int[] arr = { 1, 2, 5, -3, 0, 2 };
        private static readonly int[] arr = new int[1000];
        private static readonly Random _rand = new Random();

        static ListOfSortingBenchmark()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = _rand.Next(0, 10);
            }
        }

        public int[] GetArr()
        {
            var res = new int[arr.Length];
            Array.Copy(arr, res, arr.Length);
            return res;
        }

        [Benchmark]
        public void TestQuickSort()
        {
            var testArr = GetArr();
            ListOfSortingAlgs.QuickSort(testArr, 0, testArr.Length - 1);
        }

        [Benchmark]
        public void TestBubbleSort()
        {
            var testArr = GetArr();
            ListOfSortingAlgs.BubbleSort(testArr);
        }

        [Benchmark]
        public void TestSelectionSort()
        {
            var testArr = GetArr();
            ListOfSortingAlgs.SelectionSort(testArr);
        }

        [Benchmark]
        public void TestCountingSort()
        {
            var testArr = GetArr();
            ListOfSortingAlgs.CountingSort(testArr);
        }

        [Benchmark]
        public void TestShakerSort()
        {
            var testArr = GetArr();
            ListOfSortingAlgs.ShakerSort(testArr);
        }

        [Benchmark]
        public void TestQuickDotnetSort()
        {
            var testArr = GetArr();
            Array.Sort(testArr);
        }
    }
}


const int N = 1000000;
const int THREADS_NUMBER = 4;
object locker = new object();

Random rand = new Random();
int[] resParallel = new int[N].Select(item => new Random().Next(1, 10)).ToArray();
int[] resSerial = new int[N];
Array.Copy(resParallel,resSerial,N);

void CountSortParallelPrepare(int[] array)
{
    int max = array.Max();
    int min = array.Min();

    int offset = -min;
    int[] counter = new int[max+offset+1];

    int threadCalc = N/THREADS_NUMBER;
    var threadParallel = new List<Thread>();

    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i*threadCalc;
        int endPos = (i+1)*threadCalc;
        if (i==THREADS_NUMBER-1) endPos = N;
        threadParallel.Add(new Thread(() => CountSortParallelThread(array,counter,offset,startPos,endPos)));
        threadParallel[i].Start(); 
    }

    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        threadParallel[i].Join(); // соединить в один поток
    }

    int position = 0;
    for (int i = 0; i < counter.Length; i++)
    {
        for (int j = 0; j < counter[i]; j++)
        {
            array[position] = i-offset;
            position++;
        }
    }

}

void CountSortParallelThread(int[] array, int[] counter, int offset, int startPos, int endPos)
{
    for (int i = startPos; i < endPos; i++)
    {
        lock (locker)
        {
            counter[array[i]+offset]++;
        }
    }
}


void CountSortSerial(int[] array)
{
    int max = array.Max();
    int min = array.Min();

    int offset = -min;
    int[] counter = new int[max+offset+1];

    for (int i = 0; i < array.Length; i++)
    {
        counter[array[i]+offset]++;
    }

    Console.WriteLine($"{string.Join(", ",counter)}");

    int position = 0;
    for (int i = 0; i < counter.Length; i++)
    {
        for (int j = 0; j < counter[i]; j++)
        {
            array[position] = i-offset;
            position++;
        }
    }
}

bool CompareArray(int[] a, int[] b)
{
    bool res = true;
    for (int i = 0; i < N; i++)
    {
        res = res && (a[i] == b[i]);
    }
    return res;
}


CountSortSerial(resSerial);
CountSortParallelPrepare(resParallel);

Console.WriteLine(CompareArray(resParallel,resSerial));

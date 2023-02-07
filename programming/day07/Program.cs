using System.Diagnostics;

const int N = 1000;
const int THREADS = 10;

int[,] serialMulRes = new int[N,N];
int[,] threadMulRes = new int[N,N];

int[,] MatrixGenerator(int rows, int columns)
{
    Random _rand = new Random();
    int[,] matrix = new int[rows,columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i,j] = _rand.Next(1, 11);
        }
    }
    return matrix;
}

int[,] matrix1 = MatrixGenerator(N,N);
int[,] matrix2 = MatrixGenerator(N,N);

void MatrixMulSerial(int[,] a, int[,] b)
{
    if (a.GetLength(1)!=b.GetLength(0)) throw new Exception("Нельзя умножать такие матрицы");

    for (int i = 0; i < a.GetLength(0); i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                serialMulRes[i,j] += a[i,k] * b[k,j];
            }
        }
    }
}

void MatrixMulThreadMain(int[,] a, int[,] b)
{
    if (a.GetLength(1)!=b.GetLength(0)) throw new Exception("Нельзя умножать такие матрицы");
    int thread_size = N/THREADS; 
    Thread[] arr = new Thread[2];
    var threadList = new List<Thread>(); // лист с потоками

    for (int i = 0; i < THREADS; i++)
    {
        int start = i * thread_size;
        int end = (i + 1) * thread_size;
        if (i == (THREADS-1)) end = N;
        threadList.Add(new Thread(() => MatrixMulThreadParralel(a,b,start, end))); // создаем потоки
        threadList[i].Start(); // запустить потоки
    }

    for (int i = 0; i < THREADS; i++)
    {
        threadList[i].Join(); // соединить в один поток
    }
}

void MatrixMulThreadParralel(int[,] a, int[,] b, int start, int end)
{
    for (int i = start; i < end; i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                threadMulRes[i,j] += a[i,k] * b[k,j];
            }
        }
    }
}

bool CompareMatrix(int[,] a, int[,] b)
{
    bool res = true;
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < N; j++)
        {
            res = res && (a[i,j] == b[i,j]);
        }
    }
    return res;
}

Stopwatch sw = new();
sw.Start();
MatrixMulSerial(matrix1,matrix2);
sw.Stop();
Console.WriteLine($"time = {sw.ElapsedMilliseconds}");

sw = new();
sw.Start();
MatrixMulThreadMain(matrix1,matrix2);
sw.Stop();
Console.WriteLine($"time = {sw.ElapsedMilliseconds}");

Console.WriteLine(CompareMatrix(serialMulRes,threadMulRes));

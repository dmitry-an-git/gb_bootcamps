// 1
// int n = 5;
// int[] array = new int[n];
// for (int i = 0; i < n; i++)
// {
//     array[i] = Convert.ToInt32(Console.ReadLine());
// }
// Console.WriteLine($"[{string.Join(", ",array)}]");


// 2 multiplication table
// int m = 5;
// for (int i = 0; i <m; i++)
// {
//     for (int j = 0; j < m; j++)
//     {
//         Console.Write($"{(i+1)*(j+1)} ");
//     }
//     Console.WriteLine();
// }

// 3 optimized

int n = Convert.ToInt32(Console.ReadLine());
int[,] matrix = new int[n,n];
for (int i = 0; i < n; i++)
{
    for (int j = i; j < n; j++)
    {
        matrix[i,j] = (i+1)*(j+1);
        matrix[j,i] = (i+1)*(j+1);
    }
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        Console.Write(matrix[i,j]);
        Console.Write("\t");
    }
    Console.WriteLine();
}
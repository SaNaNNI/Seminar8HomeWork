// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2


int SetNumber(string message)
{
    System.Console.Write($"Put number {message}: ");
    int num = Convert.ToInt32(Console.ReadLine());
    return num;
}

int rows = SetNumber("row");
int columns = SetNumber("column");
int[,] array = GetMatrix(rows, columns, 0, 9);
PrintMatrix(array);
System.Console.WriteLine();
FilterRows(array);
PrintMatrix(array);

int[,] GetMatrix(int rows, int columns, int minValue = 10, int maxValue = 99)
{
    int[,] matrix = new int[rows, columns];
    Random rand = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int l = 0; l < columns; l++)
            matrix[i, l] = rand.Next(minValue, maxValue + 1);
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int l = 0; l < matrix.GetLength(1); l++)
            Console.Write($"{matrix[i, l]} ");
        Console.WriteLine();
    }
}

void FilterRows (int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
{
        for (int j = 0; j < matrix.GetLength(1); j++)
    {
            for (int l = 0; l < matrix.GetLength(1) - 1 - j; l++)
        {
            if (matrix[i, l] < matrix[i, l + 1])
            {
                int temp = matrix[i, l];
                matrix[i, l] = matrix[i, l + 1];
                matrix[i, l + 1] = temp;
            } 
        }
    }
}
}






// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка



int SetNumber(string message)
{
    Console.Write($"{message}");
    int num = int.Parse(Console.ReadLine()!);
    return num;
}

int rows = SetNumber("Enter number of rows: ");
int columns = SetNumber("Enter number of column: ");
int[,] matrix = GetMatrix(rows, columns, 1, 10);
PrintMatrix(matrix);
Console.WriteLine();
int[] arr = GetArray(matrix);
Console.WriteLine(string.Join(", ", arr));
MinIndex(matrix, arr);

int[,] GetMatrix(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
            matrix[i, j] = new Random().Next(min, max);
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i, j]} ");
        Console.WriteLine();
    }
}

int[] GetArray(int[,] matrix)
{
    int[] arr = new int[matrix.GetLength(0)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            arr[i] += matrix[i, j];
        }
    }
    return arr;
}

void MinIndex(int[,] matrix, int[] arr)
{
    int min = 0;
    for (int j = 1; j < matrix.GetLength(0); j++)
    {
        if (arr[j] < arr[min])
            min = j;
    }
    Console.WriteLine($"Index with the smallest amount: {min}");         
}





// Задача 60. Сформируйте трёхмерный массив. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)


int SetNumber(string message)
{
    Console.Write($"{message}");
    int num = int.Parse(Console.ReadLine()!);
    return num;
}

int height = SetNumber("Enter height: ");
int width = SetNumber("Enter widght: ");
int depth = SetNumber("Enter depth: ");
int[,,] matrix = GetMatrix(height, width, depth, 1, 10);
Console.WriteLine();
PrintMatrix(matrix);


int[,,] GetMatrix(int height, int width, int depth, int min, int max)
{
    int [,,] matrix = new int[height, width, depth];
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            for (int l = 0; l < depth; l++)
                matrix[i, j, l] = new Random().Next(min, max);
        }
    }
    return matrix;
}

void PrintMatrix(int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int l = 0; l < matrix.GetLength(2); l++)
                Console.Write($"{matrix[i, j, l]}({j},{l},{i})\t");
            Console.WriteLine();
        }
        Console.WriteLine(); 
    }
}





// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:

//  1  2  3 4
// 12 13 14 5
// 11 16 15 6
// 10  9  8 7


int n = 4;
int[,] array = new int[n, n];

int value = 1;
int topBorder = 0;
int bottomBorder = n - 1;
int leftBorder = 0;
int rightBorder = n - 1;

while (value <= n * n)
    {

    for (int i = leftBorder; i <= rightBorder; i++)
    {
        array[topBorder, i] = value++;
    }
        topBorder++;


    for (int i = topBorder; i <= bottomBorder; i++)
    {
        array[i, rightBorder] = value++;
    }
        rightBorder--;


    for (int i = rightBorder; i >= leftBorder; i--)
    {
        array[bottomBorder, i] = value++;
    }
        bottomBorder--;


    for (int i = bottomBorder; i >= topBorder; i--)
    {
        array[i, leftBorder] = value++;
    }
        leftBorder++;
    }


    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Console.Write(array[i, j] + "\t");
        }
    Console.WriteLine();
    }
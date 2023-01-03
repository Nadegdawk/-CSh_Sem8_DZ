Main();

void Main()
{
	bool isWorking = true;
	while (isWorking)
	{
		Console.Write("Input command: ");
		switch (Console.ReadLine())
		{
			case "Task54": Task54(); break;
			case "Task56": Task56(); break;
			case "Task58": Task58(); break;
			case "Task60": Task60(); break;
			case "Task62": Task62(); break;
            case "exit": isWorking = false; break;
		}
		Console.WriteLine();
	}
}

void Task54()
// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит 
// по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

{
	Console.WriteLine("Sorting elements in an array MxN row in descending order");
	int m = ReadInt("M");
	int n = ReadInt("N");
	int[,] array = GetArray(m, n);
    PrintArray2(array);
    SortRowMaxToMin(array);
	PrintArray2(array);
}

void Task56()
// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки 
// с наименьшей суммой элементов: 1 строка

{
    Console.WriteLine("Search for a row with the minimum sum array MxN");
	int m = ReadInt("M");
	int n = ReadInt("N");
	int[,] array = GetArray(m, n);
    PrintArray2(array);
    GetTempArray(array);
    int min = FindMinSum(GetTempArray(array));
    System.Console.WriteLine($"The line with the minimum sum: {min+1}");
}

void Task58()
// Задача 58: Задайте две матрицы. Напишите программу, которая будет 
// находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

{
	Console.WriteLine("Multiplication of two matrices MxN and NxK");
	int m = ReadInt("M");
	int n = ReadInt("N");
    int k = ReadInt("K");
	int[,] arrayA = GetArray(m, n);
    int[,] arrayB = GetArray(n, k);
    PrintArray2(arrayA);
    PrintArray2(arrayB);
    int[,] arrayC = MatrixMultiplication(arrayA, arrayB);
    PrintArray2(arrayC);
    
	
}

void Task60()
// Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, 
// добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

{
	Console.WriteLine("Three-dimensional array of unique numbers MxNxK");
	int m = ReadInt("M");
    int n = ReadInt("N");
    int k = ReadInt("K");
	int[,,] array = GetThreeArray(m, n, k);
    PrintArray3(array);
}

void Task62()
// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07



{
    Console.WriteLine("filling the array NxN in a spiral");
    int n = ReadInt("N");
    int[,] array = new int[n,n];
    ArrayCircle(array, n);
    PrintArray2(array);
}

int ReadInt(string argumentName)            //ввод данных пользователем
{
	Console.Write($"Input {argumentName}: ");
	return int.Parse(Console.ReadLine());
}

void PrintArray2 (int[,] array)     //печать двумерного массива
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} | ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] GetArray (int length, int secondLength)      //создание рандомного двумерного массива
{
    int[,] array = new int[length, secondLength]; 
    Random random = new Random();
    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < secondLength; j++)
        {
            array[i, j] = random.Next(10);  
        }
    }
    return array;
}

void SortMaxToMin (int[,] array, int row)       //сортировка от max до min
{
    for (int i = 0; i < array.GetLength(1); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[row, i] > array[row, j])
            {
                int temp = array[row, i];
                array[row, i] = array[row, j];
                array[row, j] = temp;
            }
        }
    }
}

void SortRowMaxToMin (int[,] array)     //сортировка строки от max до min
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        SortMaxToMin(array, i);
    }
}

int[] GetTempArray(int[,] array)        //создание временного массива
{
	int[] tempArray = new int[array.GetLength(0)];

	for (int i = 0; i < array.GetLength(1); i++)
	{
		for (int j = 0; j < array.GetLength(0); j++)
        {
            tempArray[i] += array[i, j];
        }      
	}
	return tempArray;
}

int FindMinSum (int[] array)        //поиск мин элемента
{
    int count = 0;
    for (int i = 0; i < array.Length-1; i++)
    {
        if (array[i] < array[i+1]) count = i;
    }
    return count;
}

int[,,] GetThreeArray (int length1, int length2, int length3)      //создание рандомного трехмерного массива
{
    int[,,] array = new int[length1, length2, length3]; 
    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                int value = random.Next(10, 100); 
                if (!UniqueElement(array, value))
                {
                    array[i, j, k] = value;
                }
                else 
                {
                    k--;
                }
            }
        }
    }
    return array;
}

void PrintArray3 (int[,,] array)     //печать трехмерного массива
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write($"{array[i, j, k]} ({i}, {j}, {k}) ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

bool UniqueElement (int[,,] array, int value)       //уникальный элемент
{
    foreach (int item in array)
    {
        if (item == value)
        {
            return true;
        }
    }
    return false;
}

int[,] MatrixMultiplication (int[,] arrayA, int[,] arrayB)      //умножение матриц
{
    int[,] arrayC = new int[arrayA.GetLength(0),arrayB.GetLength(1)];
    for (int i = 0; i < arrayA.GetLength(0); i++)
    {
        for (int j = 0; j < arrayB.GetLength(1); j++)
        {
            for (int k = 0; k < arrayA.GetLength(1); k++)
            {
                arrayC[i,j] += arrayA[i,k] * arrayB[k,j];
            }
        }
    }
    return arrayC;
}

 int[,] ArrayCircle (int[,] array, int n)       //заполнение массива по спирали
 {
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (!(i == -1 || i == n || j == -1 || j == n)) 
            {
                int ix = i + 1;     
                int jx = j + 1;  
                int k =  (jx - ix + n) / n;
                int ic = Math.Abs(ix - n / 2  - 1) + (ix - 1)/(n /2) * ((n-1) % 2);
                int jc = Math.Abs(jx - n / 2  - 1) + (jx - 1)/(n /2) * ((n-1) % 2);
                int circle = n/2 - (Math.Abs(ic - jc) + ic + jc)/2;
                int xs = ix - circle + jx - circle - 1;    
                int grow = 4 * circle * (n - circle);
                array[i,j] = grow + k * xs + Math.Abs(k - 1) * (4 * (n - 2 * circle) - 2 - xs);	
            }
        }  
    }
    return array;
 }
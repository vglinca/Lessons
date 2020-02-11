using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            WorkWithOneDimensionalArray();
            WorkWithMultidimensionalArrays();
        }

        static void WorkWithOneDimensionalArray()
        {
            //we can initialize array like this...
            int[] arr = new int[10] { 5, 7, 3, 2, 7, 9, 1, 34, 5, 89 };
            //...and like this
            int[] arr1 = { 6, -4, 7, 9, -11, 10, -24, 34 - 46, 24 };

            //sort in descending order
            InsertionSort(arr, (a, b) => a < b);
            PrintArr(arr);
            //sort in ascending order
            InsertionSort(arr, (a, b) => a > b);
            PrintArr(arr);

            InsertionSort(arr1, (a, b) => a > b);
            PrintArr(arr1);
        }

        static void WorkWithMultidimensionalArrays()
        {
            int[,] m = new int[,] { 
                {4,-1,4,6,7,2 }, 
                {9,10,-13,0,5,0 }, 
                { 7,1,4,-4,-7,4},
                { 0,-3,7,8,-9,-1}, 
                {-11,23,4,7,99,10 }, 
                {89,46,-32,66,14,23 } 
            };

            PrintMatrix(m);

            TransposeMatrix(m);
            PrintMatrix(m);
        }

        static void InsertionSort(int[] arr, Func<int, int, bool> predicate)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i; j > 0 && predicate(arr[j - 1], arr[j]); j--)
                {
                    Swap(ref arr[j], ref arr[j - 1]);
                }
            }
        }

        static void PrintArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine("\n------------------------------------------------------------");
        }

        static void PrintMatrix(int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write($"{m[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------------------------------------");
        }

        static void TransposeMatrix(int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = i; j < m.GetLength(1); j++)
                {
                    Swap(ref m[i, j], ref m[j, i]);
                }
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
    }
}

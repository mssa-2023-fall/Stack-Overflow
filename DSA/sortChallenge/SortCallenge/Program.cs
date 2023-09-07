// See https://aka.ms/new-console-template for more information
using System.Runtime.ExceptionServices;

namespace sortArray
{
    internal class Program
    {
        public static void Main(string[] args) 
        {
            int[] arr = new int[0];
            PrintArr(arr);

            for(int i = 1; i < 12; i++)
            {
                arr = Push(arr, Fib(i) );
                PrintArr(arr);
            }

        }
        public static int Fib (int input)
        {
            if (input == 0) return 0;
            if (input == 1) return 1;
            return Fib(input - 1) + Fib(input - 2);
        }
        public static int[] Push(int[] arr, int num)
        {
            int[] result = new int[arr.Length + 1];
            for(int i = 0; i < arr.Length; i++)
            {
                result[i] = arr[i];
            }
            result[arr.Length] = num;
            return result;
        }
        public static int[] Sort(int[] arr)
        {
            for(int i=0; i<arr.Length -1; i++)
            {
                int maxIndex = i;

                for(int j = i+1; j<arr.Length; j++)
                {
                    if (arr[j] > arr[maxIndex]) maxIndex = j;
                }
                int temp = arr[maxIndex];
                arr[maxIndex] = arr[i];
                arr[i] = temp;
            }
            return arr;
        }

       
        public static int[] MaxLast(int[] arr)
        {
            int maxIndex = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                maxIndex = (arr[maxIndex] > arr[i]) ? maxIndex : i;
            }
            if (arr[maxIndex] != arr[arr.Length - 1])
            {
                int helper = arr[arr.Length - 1];
                arr[arr.Length -1] = arr[maxIndex];
                arr[maxIndex] = helper;
            }
            return arr;
        }

        public static void PrintArr(int[] arr)
        {
            foreach( int val in arr )
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }
    }
}
// See https://aka.ms/new-console-template for more information
using System.Runtime.ExceptionServices;

namespace sortArray
{
    internal class Program
    {
        public static void Main(string[] args) 
        {
            int[] arr = new int[5] { 85, 22, 63, 91, 24 };
            PrintArr(arr);

            MaxLast(arr);
            PrintArr(arr);

            Sort(arr);
            PrintArr(arr);
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
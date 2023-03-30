using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class QuickSortMultithreading
    {
        private object lockObject = new object();

        public void Start()
        {
            int[] arr = new int[10];
            Random random = new Random();

            for(int i = 0; i < arr.Length; i++)
                arr[i] = random.Next(0, 20);

            Console.WriteLine("Original array: " + ArrayToString(arr));
            QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine("Sorted array: " + ArrayToString(arr));

            Console.ReadKey();
        }

        private void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                Thread leftThread = new Thread(() => QuickSort(arr, left, pivot - 1));
                Thread rightThread = new Thread(() => QuickSort(arr, pivot + 1, right));

                leftThread.Start();
                rightThread.Start();

                leftThread.Join();
                rightThread.Join();
            }
        }

        private int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left - 1;

            for (int j = left; j <= right - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, right);
            return i + 1;
        }

        private void Swap(int[] arr, int i, int j)
        {
            lock (lockObject)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        private string ArrayToString(int[] arr)
        {
            string result = "";
            for(int i = 0; i < arr.Length; i++)
            {
                if(i + 1 == arr.Length)
                    result += arr[i];
                else
                    result += arr[i] + ", ";
            }
            return result;
        }
    }
}

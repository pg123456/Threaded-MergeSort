/*********************
*  Name: Patrick Guo
*  ID: 11378369
*********************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUO_HW10
{
    class Program
    {
        /************************************************************************************
        *  Get an array of random ints.
        ************************************************************************************/
        static int[] GetRandomIntArray(int size)
        {
            Random number_generator = new Random();
            int[] arr = new int[size];
            
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = number_generator.Next();
            }

            return arr;
        }

        /************************************************************************************
        *  Get an array of random ints and sort them using the
        *  MergeSorter.
        ************************************************************************************/
        static void RunTest(int array_size)
        {
            int[] arr = GetRandomIntArray(array_size);
            int[] cloned_arr = new int[array_size];
            Array.Copy(arr, cloned_arr, array_size);

            Console.WriteLine(" Starting test for size " + array_size + " - Test completed:");
            Console.WriteLine("   Normal Sort time (ms): " + MergeSorter.MergeSort(arr, false));
            Console.WriteLine("   Threaded Sort time (ms): " + MergeSorter.MergeSort(cloned_arr, true));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Starting tests of merge sort vs. threaded merge sort");
            Console.WriteLine("  Array sizes under test: [8, 64, 256, 1024]");

            RunTest(8);
            RunTest(64);
            RunTest(256);
            RunTest(1024);
        }
    }
}

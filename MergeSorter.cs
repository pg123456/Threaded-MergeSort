/*********************
*  Name: Patrick Guo
*  ID: 11378369
*********************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace GUO_HW10
{
    public static class MergeSorter
    {
        /************************************************************************************
        *  The merge function for MergeSort. Merges two sections 
        *  of an array into one sorted section.
        *  
        *  Step 1: Copy the two array sections (already-sorted) into two new sub-arrays
        *  Step 2: Merge the two sub-arrays' contents back into the
        *          original array in sorted-order
        ************************************************************************************/
        private static void Merge(int[] arr, int i, int m, int j)
        {
            int left_count = m - i + 1, right_count = j - m,
                temp_i = 0, temp_j = 0;
            int[] left_arr = new int[left_count], right_arr = new int[right_count];

            /****************************************************
            *  Step 1
            ****************************************************/
            for (temp_i = 0; temp_i < left_count; temp_i++)
            {
                left_arr[temp_i] = arr[i + temp_i];
            }
            for (temp_j = 0; temp_j < right_count; temp_j++)
            {
                right_arr[temp_j] = arr[m + 1 + temp_j];
            }

            temp_i = 0;
            temp_j = 0;
            int k = i;

            /****************************************************
            *  Step 2
            ****************************************************/
            while (temp_i < left_count && 
                temp_j < right_count)
            {
                if (left_arr[temp_i] <= right_arr[temp_j])
                {
                    arr[k] = left_arr[temp_i];
                    temp_i++;
                }
                else
                {
                    arr[k] = right_arr[temp_j];
                    temp_j++;
                }
                k++;
            }
            
            while (temp_i < left_count)
            {
                arr[k] = left_arr[temp_i];
                temp_i++;
                k++;
            }

            while (temp_j < right_count)
            {
                arr[k] = right_arr[temp_j];
                temp_j++;
                k++;
            }
        }

        /************************************************************************************
        *  The standard merge-sort function with an optional threading functionality
        *  added to it.
        ************************************************************************************/
        private static void MergeSort(int[] arr, int i, int j, bool use_multi_threading = false)
        {
            if (i < j)
            {
                int m = (i + j) / 2;

                if (use_multi_threading)
                {
                    Thread t1 = new Thread(() => MergeSort(arr, i, m));
                    Thread t2 = new Thread(() => MergeSort(arr, m + 1, j));
                    t1.Start();
                    t2.Start();

                    t1.Join();
                    t2.Join();
                }
                else
                {
                    MergeSort(arr, i, m);
                    MergeSort(arr, m + 1, j);
                }

                Merge(arr, i, m, j);
            }
        }

        /************************************************************************************
        *  I know that the professor mentioned to use the UNIX time with the 
        *  DateTimeOffset but for whatever reason my system doesn't have
        *  the DateTime.Now.ToUnixTimeMilliseconds() function on it (and the
        *  other functions are giving weird results) so I used the
        *  stopwatch class instead.  
        ************************************************************************************/
        public static long MergeSort(int[] arr, bool use_multi_threading = false)
        {
            Stopwatch timer = Stopwatch.StartNew();
            MergeSort(arr, 0, arr.Length - 1, use_multi_threading);
            timer.Stop();

            return timer.ElapsedMilliseconds;
        }
    }
}

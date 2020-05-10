using System;

namespace Sorts
{
    public class Shellsort<T> where T : IComparable<T>, IEquatable<T>
    {
        public static void Run(T[] arr)
        {
            // We use the increment sequence 3x + 1.
            // This calculates x, such that 3x + 1 is the highest element in that sequence under arr.Length.
            int x = (arr.Length - 2) / 3;

            for (int i = x; i >= 0; i--)
            {
                int h = (3 * i) + 1;
                InsertionSort<T>.Run(arr, h);
            }
        }
    }
}
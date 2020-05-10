using System;

namespace Sorts
{
    public class InsertionSort<T> where T : IComparable<T>, IEquatable<T>
    {
        public static void Run(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    int result = arr[j].CompareTo(arr[j - 1]);
                    if (result < 0)
                        Swap(arr, j, j - 1);
                    else
                        break;
                }
            }
        }

        private static void Swap(T[] arr, int first, int second)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}
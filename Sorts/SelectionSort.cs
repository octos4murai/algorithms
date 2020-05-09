using System;

namespace Sorts
{
    public class SelectionSort<T> where T : IComparable<T>, IEquatable<T>
    {
        public SelectionSort()
        {
        }

        public static void Run(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    int result = arr[minIndex].CompareTo(arr[j]);
                    if (result > 0)
                        minIndex = j;
                }

                Swap(arr, i, minIndex);
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

using System;

namespace Sorts
{
    public class InsertionSort<T> where T : IComparable<T>, IEquatable<T>
    {
        public static void Run(T[] arr, int h = 1)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j > 0; j -= h)
                {
                    int current = j;
                    int previous = j - h;

                    if (previous < 0)
                        break;

                    int result = arr[current].CompareTo(arr[previous]);
                    if (result < 0)
                        Swap(arr, current, previous);
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
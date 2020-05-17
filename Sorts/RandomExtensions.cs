using System;

namespace Sorts
{
    public static class RandomExtensions
    {
        public static void Shuffle<T>(this Random r, T[] arr)
        {
            int n = arr.Length;
            while (n > 1)
            {
                int k = r.Next(n--);
                T temp = arr[n];
                arr[n] = arr[k];
                arr[k] = temp;
            }
        }
    }
}
using System;

namespace Sorts
{
    public class Mergesort<T> where T : IComparable<T>, IEquatable<T>
    {
        public static void Run(T[] arr)
        {
            var aux = new T[arr.Length];
            Sort(arr, aux, 0, arr.Length - 1);
        }

        private static void Sort(T[] arr, T[] aux, int lo, int hi)
        {
            if (lo == hi)
                return;

            int md = ((hi - lo) / 2) + lo;

            Sort(arr, aux, lo, md);
            Sort(arr, aux, md + 1, hi);

            Merge(arr, aux, lo, md, hi);
        }

        private static void Merge(T[] arr, T[] aux, int lo, int md, int hi)
        {
            Array.Copy(arr, lo, aux, lo, hi - lo + 1);

            int i = lo;
            int j = md + 1;

            for (int k = lo; k <= hi; k++)
            {
                if (i > md)
                {
                    Array.Copy(aux, j, arr, k, hi - j + 1);
                    break;
                }
                else if (j > hi)
                {
                    Array.Copy(aux, i, arr, k, md - i + 1);
                    break;
                }
                else if (aux[i].CompareTo(aux[j]) < 0)
                {
                    arr[k] = aux[i];
                    i++;
                }
                else
                {
                    arr[k] = aux[j];
                    j++;
                }
            }
        }
    }
}
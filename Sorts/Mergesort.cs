using System;

namespace Sorts
{
    public class Mergesort<T> where T : IComparable<T>, IEquatable<T>
    {
        public static void Run(T[] arr, MergesortType type = MergesortType.RECURSIVE)
        {
            var aux = new T[arr.Length];

            if (type == MergesortType.RECURSIVE)
                RecursiveSort(arr, aux, 0, arr.Length - 1);
            else
                BottomUpSort(arr, aux);
        }

        private static void RecursiveSort(T[] arr, T[] aux, int lo, int hi)
        {
            if (lo == hi)
                return;

            int md = ((hi - lo) / 2) + lo;

            RecursiveSort(arr, aux, lo, md);
            RecursiveSort(arr, aux, md + 1, hi);

            Merge(arr, aux, lo, md, hi);
        }

        private static void BottomUpSort(T[] arr, T[] aux)
        {
            for (int size = 1; size < arr.Length; size *= 2)
            {
                for (int lo = 0; lo < arr.Length - size; lo += (size * 2))
                {
                    int md = lo + size - 1;
                    int hi = Math.Min(lo + (size * 2) - 1, arr.Length - 1);
                    Merge(arr, aux, lo, md, hi);
                }
            }
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

        public enum MergesortType
        {
            RECURSIVE,
            BOTTOM_UP
        }
    }
}
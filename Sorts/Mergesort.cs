using System;

namespace Sorts
{
    public class Mergesort<T> where T : IComparable<T>, IEquatable<T>
    {
        public void Run(T[] arr)
        {
            var aux = new T[arr.Length];
            Sort(arr, aux, 0, arr.Length - 1);
        }

        public void Sort(T[] arr, T[] aux, int lo, int hi)
        {
            if (lo == hi)
                return;

            int md = (hi - lo) / 2;

            Sort(arr, aux, lo, md);
            Sort(arr, aux, md + 1, hi);

            Merge(arr, aux, lo, hi);
        }

        private void Merge(T[] arr, T[] aux, int lo, int hi)
        {
            throw new NotImplementedException();
        }
    }
}
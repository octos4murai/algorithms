using System;

namespace Sorts
{
    public class Quicksort<T> where T : IComparable<T>, IEquatable<T>
    {
        public static void Run(T[] arr, QuicksortType type = QuicksortType.STANDARD)
        {
            var r = new Random();
            r.Shuffle(arr);

            if (type == QuicksortType.STANDARD)
                StandardSort(arr, 0, arr.Length - 1);
            else
                ThreeWaySort(arr, 0, arr.Length - 1);
        }

        private static void ThreeWaySort(T[] arr, int lo, int hi)
        {
            if (lo == hi)
                return;
            else if (lo > hi)
                throw new ArgumentException();

            int inv = lo;
            int lt = lo;
            int gt = hi;

            while (inv < gt)
            {
                if (lt == inv || arr[lt].CompareTo(arr[inv]) == 0)
                {
                    inv++;
                    Swap(arr, lt, inv);
                }
                else if (arr[lt].CompareTo(arr[inv]) < 0)
                {
                    lt++;
                }
                else
                {
                    Swap(arr, lt, gt);
                    gt--;
                }
            }

            if (arr[lt].CompareTo(arr[inv]) > 0)
            {
                Swap(arr, lt, inv);
                inv--;
            }

            ThreeWaySort(arr, lo, lt);
            ThreeWaySort(arr, gt, hi);
        }

        private static void StandardSort(T[] arr, int lo, int hi)
        {
            if (lo == hi)
                return;
            else if (lo > hi)
                throw new ArgumentException();

            int inv = lo;
            int lt = lo + 1;
            int gt = hi;

            while (lt < gt)
            {
                if (arr[lt].CompareTo(arr[inv]) <= 0)
                {
                    lt++;
                }
                else
                {
                    Swap(arr, lt, gt);
                    gt--;
                }
            }

            if (arr[lt].CompareTo(arr[inv]) <= 0)
            {
                Swap(arr, lt, inv);
                inv = lt;
            }
            else
            {
                Swap(arr, lt - 1, inv);
                inv = lt - 1;
            }

            StandardSort(arr, lo, Math.Max(inv - 1, lo));
            StandardSort(arr, Math.Min(inv + 1, hi), hi);
        }

        private static void Swap(T[] arr, int a, int b)
        {
            T temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        public enum QuicksortType
        {
            STANDARD,
            THREE_WAY
        }
    }
}
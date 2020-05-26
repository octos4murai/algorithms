using Collections;
using System;

namespace Sorts
{
    public class Heapsort<T> where T : IComparable<T>, IEquatable<T>
    {
        public static void Run(T[] elements)
        {
            var heap = new BinaryMaxHeap<T>(elements);

            for (int i = elements.GetUpperBound(0); i >= 0; i--)
                elements[i] = heap.RemoveMax();
        }
    }
}
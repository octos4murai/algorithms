using System;

namespace Collections
{
    public class BinaryMaxHeap<T> where T : IComparable<T>, IEquatable<T>
    {
        private T[] _elements;
        private int? _last;

        public BinaryMaxHeap(int length) => _elements = new T[length];

        public BinaryMaxHeap(T[] elements) : this(elements.Length)
        {
            BuildHeapArray(_elements, elements);
        }

        public int GetLength() => _last.HasValue ? _last.GetValueOrDefault() + 1 : 0;

        private void BuildHeapArray(T[] heapArray, T[] elements)
        {
            foreach (T e in elements)
            {
                Insert(heapArray, e);
            }
        }

        private void Insert(T[] heapArray, T e)
        {
            if (_last.HasValue && _last.GetValueOrDefault() == heapArray.GetUpperBound(0))
                throw new OverflowException("Allocated heap space exceeded.");

            // Insert element at the end of the array.
            _last = _last.HasValue ? _last.GetValueOrDefault() + 1 : 0;
            heapArray[_last.GetValueOrDefault()] = e;

            // Swim the element up the heap.
            Swim(heapArray, _last.GetValueOrDefault());
        }

        private static void Swim(T[] heapArray, int index)
        {
            int parentIndex = index == 0 ? -1 : index / 2;
            while (parentIndex >= 0 && Compare(heapArray[parentIndex], heapArray[index]) > 0)
            {
                Swap(heapArray, parentIndex, index);

                index = parentIndex;
                parentIndex = parentIndex == 0 ? -1 : parentIndex / 2;
            }
        }

        private static void Swap(T[] heapArray, int parentIndex, int index)
        {
            T temp = heapArray[parentIndex];
            heapArray[parentIndex] = heapArray[index];
            heapArray[index] = temp;
        }

        private static int Compare(T t1, T t2) => t1.CompareTo(t2);
    }
}
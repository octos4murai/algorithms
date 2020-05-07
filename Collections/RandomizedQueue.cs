using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class RandomizedQueue<T> : IQueue<T>, IEnumerable<T>
    {
        private T[] _elements;
        private int? _last;

        public T Dequeue()
        {
            if (GetSize() == 0)
                throw new NotSupportedException("Cannot call dequeue on empty randomized queue.");

            var r = new Random();
            int rIndex = r.Next(GetSize() - 1);

            T outputElement = _elements[rIndex];
            _elements[rIndex] = _elements[_last.GetValueOrDefault()];
            _elements[_last.GetValueOrDefault()] = default(T);

            _last = _last.GetValueOrDefault() == 0 ? null : _last - 1;

            if (GetSize() < _elements.Length / 4)
                ShrinkElementsArray();

            return outputElement;
        }

        private void ShrinkElementsArray()
        {
            int newArrLength = GetSize() == 0 ? 1 : _elements.Length / 2;
            var newArr = new T[newArrLength];
            Array.Copy(_elements, newArr, GetSize());
            _elements = newArr;
        }

        public void Enqueue(T arg)
        {
            if (!_last.HasValue)
            {
                _elements = new T[1];
                _last = -1;
            }

            if (_last == _elements.Length - 1)
                GrowElementsArray();

            _last++;
            _elements[_last.GetValueOrDefault()] = arg;
        }

        private void GrowElementsArray()
        {
            var newArr = new T[_elements.Length * 2];
            Array.Copy(_elements, newArr, GetSize());
            _elements = newArr;
        }

        public int GetSize() =>
            _last.HasValue ? _last.GetValueOrDefault() + 1 : 0;

        public bool IsEmpty() =>
            GetSize() == 0;

        public IEnumerator<T> GetEnumerator()
        {
            var queueArray = new T[GetSize()];
            Array.Copy(_elements, queueArray, GetSize());
            return new RandomizedQueueEnumerator<T>(queueArray);
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            (IEnumerator)GetEnumerator();
    }
}
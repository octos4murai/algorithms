using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class RandomizedQueueEnumerator<T> : IEnumerator<T>
    {
        private T[] _elements;
        private int _currIndex;
        private T _currElement;

        public RandomizedQueueEnumerator(T[] arr)
        {
            _elements = arr;
            _currIndex = -1;
            _currElement = default(T);
        }

        public T Current =>
            _currElement;

        object IEnumerator.Current =>
            Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            _currIndex++;

            if (_currIndex >= _elements.Length)
                return false;

            _currElement = _elements[_currIndex];
            return true;
        }

        public void Reset() =>
            _currIndex = -1;
    }
}
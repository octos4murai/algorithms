using System;

namespace Collections
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private int? _head = null;
        private int? _tail = null;
        private T[] _elements = new T[0];

        public T Dequeue()
        {
            throw new System.NotImplementedException();
        }

        public void Enqueue(T arg)
        {
            if (IsElementArrayGrowthRequired())
                GrowElementArray();

            if (_head.HasValue)
            {
                _tail++;
            }
            else
            {
                _head = 0;
                _tail = 0;
            }

            _elements[_tail.GetValueOrDefault()] = arg;
        }

        private bool IsElementArrayGrowthRequired()
        {
            return !_tail.HasValue || _tail == GetSize() - 1;
        }

        private void GrowElementArray()
        {
            int newArrayLength = GetSize() == 0 ? 1 : GetSize() * 2;
            var newArray = new T[newArrayLength];

            if (GetSize() > 0)
            {
                int copyLength = _tail.GetValueOrDefault() - _head.GetValueOrDefault() + 1;
                Array.Copy(_elements, _head.GetValueOrDefault(), newArray, 0, copyLength);
            }

            _elements = newArray;
        }

        public int GetSize()
        {
            return !_tail.HasValue ? 0 : _tail.GetValueOrDefault() - _head.GetValueOrDefault() + 1;
        }

        public bool IsEmpty()
        {
            return GetSize() == 0;
        }
    }
}
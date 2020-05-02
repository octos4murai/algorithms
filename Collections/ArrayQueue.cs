using System;

namespace Collections
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private int? _exitpoint = null;
        private int? _entrypoint = null;
        private T[] _elements = new T[0];

        public T Dequeue()
        {
            if (GetSize() == 0)
                throw new InvalidOperationException("Cannot dequeue an empty queue.");

            var elemToRemove = _elements[_exitpoint.GetValueOrDefault()];

            if (GetSize() == 1)
            {
                _exitpoint = null;
                _entrypoint = null;
            }
            else
            {
                _exitpoint++;
            }

            if (IsElementArrayShrinkRequired())
                ShrinkElementArray();

            return elemToRemove;
        }

        private void ShrinkElementArray()
        {
            var newArray = new T[GetSize() * 2];
            Array.Copy(_elements, _exitpoint.GetValueOrDefault(), newArray, 0, GetSize());
        }

        private bool IsElementArrayShrinkRequired()
        {
            return _exitpoint.HasValue || _exitpoint >= _elements.Length * 3 / 4;
        }

        public void Enqueue(T arg)
        {
            if (IsElementArrayGrowthRequired())
                GrowElementArray();

            if (_exitpoint.HasValue)
            {
                _entrypoint++;
            }
            else
            {
                _exitpoint = 0;
                _entrypoint = 0;
            }

            _elements[_entrypoint.GetValueOrDefault()] = arg;
        }

        private bool IsElementArrayGrowthRequired()
        {
            return !_entrypoint.HasValue || _entrypoint == GetSize() - 1;
        }

        private void GrowElementArray()
        {
            int newArrayLength = GetSize() == 0 ? 1 : GetSize() * 2;
            var newArray = new T[newArrayLength];

            if (GetSize() > 0)
            {
                int copyLength = _entrypoint.GetValueOrDefault() - _exitpoint.GetValueOrDefault() + 1;
                Array.Copy(_elements, _exitpoint.GetValueOrDefault(), newArray, 0, copyLength);
            }

            _elements = newArray;
        }

        public int GetSize()
        {
            return !_entrypoint.HasValue ? 0 : _entrypoint.GetValueOrDefault() - _exitpoint.GetValueOrDefault() + 1;
        }

        public bool IsEmpty()
        {
            return GetSize() == 0;
        }
    }
}
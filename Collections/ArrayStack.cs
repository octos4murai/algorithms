using System;

namespace Collections
{
    public class ArrayStack<T> : IStack<T>
    {
        private T[] _elements = new T[0];
        private int? _top = null;

        public int GetSize()
        {
            return _top.HasValue ? _top.GetValueOrDefault() + 1 : 0;
        }

        public bool IsEmpty()
        {
            return GetSize() == 0;
        }

        public T Peek()
        {
            if (!_top.HasValue)
                throw new InvalidOperationException("Cannot peek an empty stack.");

            return _elements[_top.GetValueOrDefault()];
        }

        public T Pop()
        {
            if (!_top.HasValue)
                throw new InvalidOperationException("Cannot pop an empty stack.");

            T elementToReturn = _elements[_top.GetValueOrDefault()];
            _top = _top == 0 ? null : _top - 1;

            if (IsElementArrayShrinkageRequired())
                ShrinkElementArray();

            return elementToReturn;
        }

        public void Push(T arg)
        {
            if (IsElementArrayGrowthRequired())
                GrowElementArray();

            _top = _top.HasValue ? _top.GetValueOrDefault() + 1 : 0;
            _elements[_top.GetValueOrDefault()] = arg;
        }

        private bool IsElementArrayGrowthRequired()
        {
            return !_top.HasValue || _top.GetValueOrDefault() == _elements.Length - 1;
        }

        private void GrowElementArray()
        {
            int newArrayLength = _elements.Length == 0 ? 1 : _elements.Length * 2;
            var doubledArray = new T[newArrayLength];
            Array.Copy(_elements, doubledArray, _elements.Length);
            _elements = doubledArray;
        }

        private bool IsElementArrayShrinkageRequired()
        {
            return _top.HasValue && _top.GetValueOrDefault() <= _elements.Length / 4;
        }

        private void ShrinkElementArray()
        {
            var halvedArray = new T[_elements.Length / 2];
            Array.Copy(_elements, halvedArray, halvedArray.Length);
            _elements = halvedArray;
        }
    }
}
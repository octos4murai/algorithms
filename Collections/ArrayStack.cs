using System;

namespace Collections
{
    public class ArrayStack<T> : IStack<T>
    {
        private static T[] _elements = new T[0];
        private static int? _top = null;

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
                throw new InvalidOperationException();

            return _elements[_top.GetValueOrDefault()];
        }

        public T Pop()
        {
            if (!_top.HasValue)
                throw new InvalidOperationException();

            if (IsElementArrayShrinkageRequired())
                ShrinkElementArray();

            int indexToReturn = _top.GetValueOrDefault();
            _top = _top == 0 ? null : _top - 1;

            return _elements[indexToReturn];
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
            return _top.GetValueOrDefault() == 0 || _top.GetValueOrDefault() == _elements.Length - 1;
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
            return _elements.Length != 0 && _top.GetValueOrDefault() <= _elements.Length / 4;
        }

        private void ShrinkElementArray()
        {
            int newArrayLength = _elements.Length / 2;
            var halvedArray = new T[newArrayLength];
            Array.Copy(_elements, halvedArray, halvedArray.Length);
            _elements = halvedArray;
        }
    }
}
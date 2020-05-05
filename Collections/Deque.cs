using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class Deque<T> : IEnumerable<T>
    {
        private T[] _elements;
        private int? _first;
        private int? _last;

        public Deque() =>
            _elements = new T[0];

        public bool IsEmpty() =>
            !_first.HasValue;

        public int GetSize() =>
            IsEmpty() ? 0 : _last.GetValueOrDefault() - _first.GetValueOrDefault() + 1;

        public T PeekFirst() =>
            Peek(DequeEnd.FIRST);

        public T PeekLast() =>
            Peek(DequeEnd.LAST);

        private T Peek(DequeEnd de)
        {
            if (GetSize() == 0)
                throw new InvalidOperationException("Cannot peek an empty deque.");

            int indexToReturn = de == DequeEnd.FIRST ? _first.GetValueOrDefault() : _last.GetValueOrDefault();
            return _elements[indexToReturn];
        }

        public void AddFirst(T item) =>
            Add(item, DequeEnd.FIRST);

        public void AddLast(T item) =>
            Add(item, DequeEnd.LAST);

        private void Add(T item, DequeEnd de)
        {
            bool wasEmpty = IsEmpty();

            if (IsElementArrayGrowRequired())
                GrowElementArray();

            if (!wasEmpty)
            {
                if (de == DequeEnd.FIRST)
                    _first--;
                else
                    _last++;
            }

            int indexToAssign = de == DequeEnd.FIRST ? _first.GetValueOrDefault() : _last.GetValueOrDefault();
            _elements[indexToAssign] = item;
        }

        private void GrowElementArray()
        {
            int beginningSize = GetSize();
            bool wasEmpty = IsEmpty();

            int newLength = _elements.Length < 4 ? 4 : beginningSize * 2;
            var newArray = new T[newLength];
            int newStartingIndex = newLength / 4;

            Array.Copy(_elements, _first.GetValueOrDefault(), newArray, newStartingIndex, beginningSize);
            _elements = newArray;

            _first = wasEmpty ? _elements.Length / 2 : newStartingIndex;
            _last = wasEmpty ? _first : newStartingIndex + beginningSize - 1;
        }

        private bool IsElementArrayGrowRequired() =>
            IsEmpty() || _first == 0 || _last == _elements.Length - 1;

        public T RemoveFirst() =>
            Remove(DequeEnd.FIRST);

        public T RemoveLast() =>
            Remove(DequeEnd.LAST);

        private T Remove(DequeEnd de)
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot remove from empty deque.");

            int indexToRemove = de == DequeEnd.FIRST ? _first.GetValueOrDefault() : _last.GetValueOrDefault();
            T elementToReturn = _elements[indexToRemove];

            if (GetSize() == 1)
            {
                _first = null;
                _last = null;
            }
            else
            {
                if (de == DequeEnd.FIRST)
                    _first++;
                else
                    _last--;
            }

            if (IsElementArrayShrinkRequired())
                ShrinkElementArray();

            return elementToReturn;
        }

        private void ShrinkElementArray()
        {
            int beginningSize = GetSize();
            int newLength = beginningSize * 2;
            var newArray = new T[newLength];
            int newStartingIndex = newArray.Length / 4;

            Array.Copy(_elements, _first.GetValueOrDefault(), newArray, newStartingIndex, beginningSize);
            _elements = newArray;

            _first = newStartingIndex;
            _last = newStartingIndex + beginningSize - 1;
        }

        private bool IsElementArrayShrinkRequired() =>
            _first > _elements.Length * 3 / 4 || _last < _elements.Length / 4;

        public IEnumerator<T> GetEnumerator()
        {
            var dequeElements = new T[GetSize()];
            Array.Copy(_elements, _first.GetValueOrDefault(), dequeElements, 0, GetSize());
            return ((IEnumerable<T>)dequeElements).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var dequeElements = new T[GetSize()];
            Array.Copy(_elements, _first.GetValueOrDefault(), dequeElements, 0, GetSize());
            return dequeElements.GetEnumerator();
        }
    }

    public enum DequeEnd
    {
        FIRST,
        LAST
    }
}
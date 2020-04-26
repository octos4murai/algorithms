using System;

namespace Collections
{
    public class LinkedListStack<T> : IStack<T>
    {
        private Node<T> _top;
        private int _size;

        public void Push(T arg)
        {
            var previousTop = _top;
            _top = new Node<T>()
            {
                Value = arg,
                Next = previousTop
            };

            _size++;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot pop an empty stack.");

            var previousTop = _top;
            _top = _top.Next;
            _size--;

            return previousTop.Value;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public int GetSize()
        {
            return _size;
        }
    }
}
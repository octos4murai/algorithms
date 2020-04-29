using System;

namespace Collections
{
    public class LinkedListStack<T> : IStack<T>
    {
        private int _size;
        private Node<T> _top;

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
            var nextTop = _top.Next;

            // Remove dangling reference
            _top.Next = null;

            _top = nextTop;
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

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot peek an empty stack.");

            return _top.Value;
        }
    }
}
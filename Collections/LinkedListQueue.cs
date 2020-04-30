using System;

namespace Collections
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        private int _size;
        private Node<T> _head;
        private Node<T> _tail;

        public T Dequeue()
        {
            if (GetSize() == 0)
                throw new InvalidOperationException("Cannot dequeue an empty queue.");

            Node<T> previousHead = _head;
            Node<T> nextHead = _head.Next;

            // Remove dangling reference
            _head.Next = null;

            _head = nextHead;
            _size--;

            return previousHead.Value;
        }

        public void Enqueue(T arg)
        {
            var previousTail = _tail;
            _tail = new Node<T>()
            {
                Value = arg
            };

            if (previousTail != null)
                previousTail.Next = _tail;

            if (_head == null)
                _head = _tail;

            _size++;
        }

        public int GetSize()
        {
            return _size;
        }

        public bool IsEmpty()
        {
            return GetSize() == 0;
        }
    }
}
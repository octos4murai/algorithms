using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class RandomizedQueue<T> : IQueue<T>, IEnumerable<T>
    {
        private Node<T> _first = null;
        private Node<T> _last = null;
        private int _size;

        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        public void Enqueue(T arg)
        {
            throw new NotImplementedException();
        }

        public int GetSize() =>
            _size;

        public bool IsEmpty() =>
            GetSize() == 0;

        public IEnumerator<T> GetEnumerator() =>
            new RandomizedQueueEnumerator<T>(_first);

        IEnumerator IEnumerable.GetEnumerator() =>
            (IEnumerator)GetEnumerator();
    }
}
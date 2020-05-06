using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class RandomizedQueueEnumerator<T> : IEnumerator<T>
    {
        private Node<T> _root = null;
        private Node<T> _curr = null;

        public RandomizedQueueEnumerator(Node<T> node) =>
            _root = node;

        public T Current =>
            _curr.Value;

        object IEnumerator.Current =>
            Current;

        public void Dispose() =>
            _root = null;

        public bool MoveNext()
        {
            if (_curr == null)
                _curr = _root;
            else
                _curr = _curr.Next;

            return _curr != null;
        }

        public void Reset() =>
            _curr = null;
    }
}
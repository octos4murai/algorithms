using System;

namespace Collections
{
    public interface IStack<T>
    {
        void Push(T arg);
        T Pop();
        bool IsEmpty();
        int GetSize();
    }
}

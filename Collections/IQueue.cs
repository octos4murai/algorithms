namespace Collections
{
    public interface IQueue<T>
    {
        void Enqueue(T arg);
        T Dequeue();
        bool IsEmpty();
        int GetSize();
    }
}

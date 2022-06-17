namespace MvcFirstProject.Models
{
    public interface IConcurrentList<T>
        where T : class
    {
        void Add(T item);
        void Remove(T item);
        IReadOnlyList<T> GetList();
    }
}

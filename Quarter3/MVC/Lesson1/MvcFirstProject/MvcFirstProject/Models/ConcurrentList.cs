namespace MvcFirstProject.Models
{
    public class ConcurrentList<T> : IConcurrentList<T>
        where T : class
    {
        private readonly object syncObj = new();
        private readonly List<T> list;

        public ConcurrentList()
        {
            list = new List<T>();
        }

        public void Add(T item)
        {
            lock (syncObj) {
                list.Add(item);
            }
        }

        public IReadOnlyList<T> GetList()
        {
            lock (syncObj) {
                return list.AsReadOnly();
            }
        }

        public void Remove(T item)
        {
            lock (syncObj) {
                list.Remove(item);
            }
        }
    }
}

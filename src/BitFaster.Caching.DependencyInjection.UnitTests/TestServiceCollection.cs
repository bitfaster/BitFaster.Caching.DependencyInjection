using Microsoft.Extensions.DependencyInjection;
using System.Collections;

namespace BitFaster.Caching.DependencyInjection.UnitTests
{
    internal class TestServiceCollection : IServiceCollection
    {
        private List<ServiceDescriptor> list = new List<ServiceDescriptor>();

        public ServiceDescriptor this[int index] { get => this.list[index]; set => this.list[index] = value; }

        public int Count => this.list.Count;

        public bool IsReadOnly => false;

        public void Add(ServiceDescriptor item)
        {
            this.list.Add(item);
        }

        public void Clear()
        {
            this.list.Clear();
        }

        public bool Contains(ServiceDescriptor item)
        {
            return this.list.Contains(item);
        }

        public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ServiceDescriptor> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        public int IndexOf(ServiceDescriptor item)
        {
            return this.list.IndexOf(item);
        }

        public void Insert(int index, ServiceDescriptor item)
        {
            this.list.Insert(index, item);
        }

        public bool Remove(ServiceDescriptor item)
        {
            return this.list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            this.list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }
    }
}

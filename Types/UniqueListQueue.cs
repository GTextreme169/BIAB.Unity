using System.Collections.Generic;

namespace BIAB.Unity.Types
{
    public class UniqueListQueue<T> : IEnumerable<T>
    {
        private HashSet<T> hashSet;
        private List<T> list;


        public UniqueListQueue()
        {
            hashSet = new HashSet<T>();
            list = new List<T>();
        }
        public UniqueListQueue(Queue<T> input)
        {
            hashSet = new HashSet<T>();
            list = new List<T>();
            while (input.Count > 0)
                Enqueue(input.Dequeue());
        }


        public int Count
        {
            get
            {
                return hashSet.Count;
            }
        }

        public void Clear()
        {
            hashSet.Clear();
            list.Clear();
        }


        public bool Contains(T item)
        {
            return hashSet.Contains(item);
        }


        public void Enqueue(T item)
        {
            if (hashSet.Add(item))
            {
                list.Add(item);
            }
        }

        public T Dequeue()
        {
            T item = list[0];
            list.RemoveAt(0);
            hashSet.Remove(item);
            return item;
        }

        public void Remove(T item)
        {
            if (Contains(item))
            {
                list.Remove(item);
                hashSet.Remove(item);
            }
        }

        public T Peek()
        {
            return list[0];
        }


        public static implicit operator Queue<T>(UniqueListQueue<T> q)
        {
            Queue<T> queue = new Queue<T>();
            for (int i = 0; i < q.Count; i++)
            {
                queue.Enqueue(q.list[i]);
            }
            return queue;
        }
        public static explicit operator UniqueListQueue<T>(Queue<T> q) => new UniqueListQueue<T>(q);
        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
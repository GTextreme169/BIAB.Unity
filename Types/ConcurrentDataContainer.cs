using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Concurrent;
using System;

namespace BIAB.DataTypes
{
    /// <summary>
    /// Holds Data of Multiple Types in a single Object
    /// </summary>
    public class ConcurrentDataContainer : IEnumerable
    {
        ConcurrentDictionary<Type, object> dict;

        // Start is called before the first frame update
        public ConcurrentDataContainer()
        {
            dict = new ConcurrentDictionary<Type, object>();
        }


        public T Get<T>()
        {
            if (dict.ContainsKey(typeof(T)) == false)
                return default(T);
            return (T)dict[typeof(T)];
        }

        public bool Set<T>(T value)
        {
            if (dict.ContainsKey(typeof(T)))
            {
                try
                {
                    dict[typeof(T)] = value;
                    return true;
                }
                catch (System.Exception e)
                {
                    return false;
                }
            }
            else
            {
                return Add(value);
            }
        }

        public bool Add<T>(T value)
        {
            return dict.TryAdd(typeof(T), value);
        }

        public T Remove<T>(T key)
        {
            dict.TryRemove(typeof(T), out object value);
            return (T)value;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)this.dict).GetEnumerator();
        }

    }

}
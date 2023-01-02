using System.Collections.Generic;
using System.Linq;

namespace BIAB.Unity.Extensions
{
    public static class EnumerableExtensions
    {
        public static T GetRandom<T>(this IEnumerable<T> list) where T : class
        {
            if (list == null)
                return null;
                    
            IEnumerable<T> enumerable = list.ToList();
            if (!enumerable.Any())
                return null;
            
            return enumerable.ElementAt(UnityEngine.Random.Range(0, enumerable.Count()));
        }
        
        public static int GetRandomIndex<T>(this IEnumerable<T> list)
        {
            if (list == null)
                return -1;
                    
            IEnumerable<T> enumerable = list.ToList();
            if (!enumerable.Any())
                return -1;
            
            return UnityEngine.Random.Range(0, enumerable.Count());
        }
    }
}
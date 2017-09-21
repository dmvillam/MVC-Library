using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyWinFormApp
{
    static class AttachExtension
    {
        public static List<T> attach<T>(this List<T> collection, int id)
        {
            dynamic model = Activator.CreateInstance(typeof(T), false);

            model = typeof(T)
                .GetMethod("find", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Invoke(null, new object[] { id });

            if (model == null)
                return collection;

            foreach (dynamic elem in collection)
            {
                if (elem.id == id)
                    return collection;
            }
            
            collection.Add(model);
            return collection;
        }
    }
}

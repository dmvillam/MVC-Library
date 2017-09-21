using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    public class Collection<T> : List<T>
        where T : Model<T>
    {
        public T first()
        {
            return this[0];
        }

        public T last()
        {
            return this[this.Count - 1];
        }

        public void attach(int model_id)
        {
            T model = (T)Activator.CreateInstance(typeof(T), false);
            model = (T)typeof(T)
                .GetMethod("find", BindingFlags.NonPublic |
                    BindingFlags.Public | BindingFlags.Static |
                    BindingFlags.FlattenHierarchy)
                .Invoke(null, new object[] { model_id });

            string cross_table = (string)typeof(T)
                .GetMethod("GetCrossTable",
                    BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(new[] { typeof(T) })
                .Invoke(null, new object[] { });

            this.Add(model);
        }
    }
}

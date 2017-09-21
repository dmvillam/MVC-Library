using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    public class BelongsTo<T> : Model<T> where T : Model<T>
    {
        public BelongsTo(dynamic ext_model, string connector)
        {
            T model = (T)Activator.CreateInstance(typeof(T), false);
            string key = ext_model
                .GetType().GetField("data",
                    BindingFlags.Public | BindingFlags.Instance)
                .GetValue(ext_model)[connector];
            model = (T)typeof(T)
                .GetMethod("find", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Invoke(null, new object[] { Convert.ToInt32(key) });
            this.id = model.id;
            this.data = model.data;
        }

        public static explicit operator T(BelongsTo<T> derived)
        {
            T model = (T)Activator.CreateInstance(typeof(T), false);
            model.id = derived.id;
            model.data = derived.data;
            return model;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    public class BelongsToMany<T> : Collection<T> where T : Model<T>
    {
        public BelongsToMany(string table1, string table2, string[] columns1,
            string[] columns2, string cross_table, string connector1,
            string connector2, string id)
        {
            List<Dictionary<string, string>> list =
                DBQuery.use_table(typeof(T), cross_table)
                .select(new string[] { table2 + ".*" })
                .inner_join(table2, table2 + ".id", "=", cross_table + "." + connector2)
                .inner_join(table1, table1 + ".id", "=", cross_table + "." + connector1)
                .where(table1 + ".id", "=", id)
                .get();

            foreach (Dictionary<string, string> elem in list)
            {
                T model = (T)Activator.CreateInstance(typeof(T), false);
                model.id = Convert.ToInt32(elem["id"]);
                for (int i = 0; i < columns2.Length; i++)
                    model.data.Add(columns2[i], elem[columns2[i]]);
                this.Add(model);
            }
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

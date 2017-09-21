using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    public class HasMany<T> : Collection<T> where T : Model<T>
    {
        public HasMany(string table1, string table2, string[] columns2,
            string connector, string id, string id_label)
        {
            List<Dictionary<string, string>> list =
                DBQuery.use_table(typeof(T))
                .select(new string[] { table2 + ".*" })
                .inner_join(table1, table2 + "." + connector, "=", table1 + ".id")
                .where(table1 + ".id", "=", id)
                .get();

            foreach (Dictionary<string, string> elem in list)
            {
                T model = (T)Activator.CreateInstance(typeof(T), false);
                model.id = Convert.ToInt32(elem[id_label]);
                foreach (string column in columns2)
                    model.data.Add(column, elem[column]);
                this.Add(model);
            }
        }
    }
}

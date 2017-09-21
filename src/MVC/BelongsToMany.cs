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
        private string cross_table;
        private string connector1;
        private string connector2;
        private int id;

        public BelongsToMany(string table1, string table2, string[] columns1,
            string[] columns2, string cross_table, string connector1,
            string connector2, string id, string id_label)
        {
            this.cross_table = cross_table;
            this.connector1 = connector1;
            this.connector2 = connector2;
            this.id = Convert.ToInt32(id);

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
                model.id = Convert.ToInt32(elem[id_label]);
                foreach (string column in columns2)
                    model.data.Add(column, elem[column]);
                this.Add(model);
            }
        }

        public void attach(int model_id)
        {
            T model = (T)typeof(T)
                .GetMethod("find", BindingFlags.NonPublic |
                    BindingFlags.Public | BindingFlags.Static |
                    BindingFlags.FlattenHierarchy)
                .Invoke(null, new object[] { model_id });

            DBQuery.use_table(typeof(T), cross_table)
                .insert(new Dictionary<string, string> {
                    {connector1, id.ToString()},
                    {connector2, model_id.ToString()},
                });

            this.Add(model);
        }

        public void attach(IEnumerable<int> id_list)
        {
            foreach (int model_id in id_list)
                this.attach(model_id);
        }

        public void dettach(int model_id)
        {
            DBQuery.use_table(typeof(T), cross_table)
                .delete(connector1, "=", this.id,
                    connector2, "=", model_id);
        }

        public void dettach()
        {
            DBQuery.use_table(typeof(T), cross_table)
                .delete(connector1, "=", this.id);
        }

        public void dettach(IEnumerable<int> id_list)
        {
            foreach (int model_id in id_list)
                this.dettach(model_id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    public abstract class Model<T> where T : Model<T>
    {
        public int id;
        public Dictionary<string, string> data;

        public Model()
        {
            id = 0;
            data = new Dictionary<string, string>();
        }
        public static T find(int id)
        {
            string table = Model<T>.GetTable();
            string[] columns = Model<T>.GetColumns();
            T model = (T)Activator.CreateInstance(typeof(T), false);

            DBConnect connect = new DBConnect(table, columns);
            List<string> values = connect.Select(id);

            if (values.Count > 0)
            {
                model.id = id;
                for (int i = 0; i < columns.Length; i++)
                    model.data.Add(columns[i], values[i]);
                return model;
            }
            else return null;
        }
        public static T create(Dictionary<string, string> data)
        {
            string table = Model<T>.GetTable();
            string[] columns = Model<T>.GetColumns();
            T model = (T)Activator.CreateInstance(typeof(T), false);

            List<string> values = new List<string>();
            for (int i = 0; i < columns.Length; i++)
                values.Add(data[columns[i]]);

            DBConnect connect = new DBConnect(table, columns);
            connect.Insert(new string[] {
                String.Join(",", columns),
                "'" + String.Join("','", values) + "'"
            });
            List<Dictionary<string, string>> list = connect.Select();
            model.id = Convert.ToInt32(list[list.Count - 1]["id"]);
            model.data = list[list.Count - 1];

            return model;
        }
        public void save()
        {
            string table = Model<T>.GetTable();
            string[] columns = Model<T>.GetColumns();

            DBConnect dbconnect = new DBConnect(table, columns);
            List<string> list = new List<string>();
            for (int i = 0; i < columns.Length; i++)
                list.Add(columns[i] + "='" + this.data[columns[i]] + "'");
            dbconnect.Update(this.id, list);
        }
        public static List<T> all()
        {
            string table = Model<T>.GetTable();
            string[] columns = Model<T>.GetColumns();

            T m = (T)Activator.CreateInstance(typeof(T), false);
            DBConnect connect = new DBConnect(table, columns);
            List<Dictionary<string, string>> list = connect.Select();
            List<T> models = new List<T>();
            foreach (Dictionary<string, string> elem in list)
            {
                T model = (T)Activator.CreateInstance(typeof(T), false);
                model.id = Convert.ToInt32(elem["id"]);
                for (int i = 0; i < columns.Length; i++)
                    model.data.Add(columns[i], elem[columns[i]]);
                models.Add(model);
            }
            return models;
        }
        public static void destroy(int id)
        {
            string table = Model<T>.GetTable();
            string[] columns = Model<T>.GetColumns();

            dynamic model = Activator.CreateInstance(typeof(T), false);
            DBConnect connect = new DBConnect(table, columns);
            connect.Delete(id);
        }
        protected dynamic hasOne<U>()
        {
            string table = Model<T>.GetTable();
            string[] columns = Model<T>.GetColumns();

            DBConnect connect = new DBConnect(table, columns);

            dynamic model = Activator.CreateInstance(typeof(U), false);
            model.id = 0;
            Dictionary<string, string> newdata = new Dictionary<string, string>();
            for (int i = 0; i < model.columns.Length; i++)
                model.data.Add(model.columns[i], "aaa");

            return model;
        }
        protected dynamic belongsTo<U>(string connector)
        {
            dynamic model = Activator.CreateInstance(typeof(U), false);
            int key = Convert.ToInt32(this.data[connector]);
            model = typeof(U)
                .GetMethod("find", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Invoke(null, new object[] { key });
            return model;
        }
        public dynamic hasMany<U>(string connector)
        {
            
            string table1 = (string)typeof(T)
                .GetMethod("GetTable", BindingFlags.NonPublic | 
                    BindingFlags.Public | BindingFlags.Static |
                    BindingFlags.FlattenHierarchy)
                .Invoke(null, new object[] { });
            string table2 = (string)typeof(U)
                .GetMethod("GetTable", BindingFlags.NonPublic |
                    BindingFlags.Public | BindingFlags.Static |
                    BindingFlags.FlattenHierarchy)
                .Invoke(null, new object[] { });
            string[] columns2 = (string[])typeof(U)
                .GetMethod("GetColumns", BindingFlags.NonPublic |
                    BindingFlags.Public | BindingFlags.Static |
                    BindingFlags.FlattenHierarchy)
                .Invoke(null, new object[] { });

            dynamic m1 = Activator.CreateInstance(typeof(T), false);
            dynamic m2 = Activator.CreateInstance(typeof(U), false);
            List<Dictionary<string, string>> list =
                DBQuery.use_table(table2, columns2)
                .select(new string[] { table2 + ".*" })
                .inner_join(table1, table2 + "." + connector, "=", table1 + ".id")
                .where(table1 + ".id", "=", this.id.ToString())
                .get();

            List<U> models = new List<U>();
            foreach (Dictionary<string, string> elem in list)
            {
                dynamic model = Activator.CreateInstance(typeof(U), false);
                model.id = Convert.ToInt32(elem["id"]);
                for (int i = 0; i < columns2.Length; i++)
                    model.data.Add(columns2[i], elem[columns2[i]]);
                models.Add(model);
            }
            return models;
        }
        /*
         * U -> Item
         * T -> Bill
         */
        public dynamic hasMany<U>(Dictionary<string, string> connector, string cross_table)
        {
            dynamic m1 = Activator.CreateInstance(typeof(U), false);
            dynamic m2 = Activator.CreateInstance(typeof(T), false);

            List<Dictionary<string, string>> list =
                DBQuery.use_table(cross_table, m1.columns)
                .select(new string[] { m1.table + ".*" })
                .inner_join(m2.table, m2.table + ".id", "=", cross_table + "." + connector[m2.GetType().Name])
                .inner_join(m1.table, m1.table + ".id", "=", cross_table + "." + connector[m1.GetType().Name])
                .where(m2.table + ".id", "=", this.id.ToString())
                .get();

            List<U> models = new List<U>();
            foreach (Dictionary<string, string> elem in list)
            {
                dynamic model = Activator.CreateInstance(typeof(U), false);
                model.id = Convert.ToInt32(elem["id"]);
                for (int i = 0; i < m1.columns.Length; i++)
                    model.data.Add(m1.columns[i], elem[m1.columns[i]]);
                models.Add(model);
            }
            return models;
        }
        /*
         * U -> Bill
         * T -> Item
         */
        public dynamic belongsToMany<U>(Dictionary<string, string> connector, string cross_table)
        {
            dynamic m1 = Activator.CreateInstance(typeof(T), false);
            dynamic m2 = Activator.CreateInstance(typeof(U), false);

            List<Dictionary<string, string>> list =
                DBQuery.use_table(cross_table, m2.columns)
                .select(new string[] { m2.table + ".*" })
                .inner_join(m2.table, m2.table + ".id", "=", cross_table + "." + connector[m2.GetType().Name])
                .inner_join(m1.table, m1.table + ".id", "=", cross_table + "." + connector[m1.GetType().Name])
                .where(m1.table + ".id", "=", this.id.ToString())
                .get();

            List<U> models = new List<U>();
            foreach (Dictionary<string, string> elem in list)
            {
                dynamic model = Activator.CreateInstance(typeof(U), false);
                model.id = Convert.ToInt32(elem["id"]);
                for (int i = 0; i < m2.columns.Length; i++)
                    model.data.Add(m2.columns[i], elem[m2.columns[i]]);
                models.Add(model);
            }
            return models;
        }

        public static string GetTable()
        {
            return typeof(T)
                .GetField("Table", BindingFlags.NonPublic | BindingFlags.Static)
                .GetValue(null).ToString();
        }
        public static string[] GetColumns()
        {
            return (string[])typeof(T)
                .GetField("Columns", BindingFlags.NonPublic | BindingFlags.Static)
                .GetValue(null);
        }

        public void SetDataValue(string key, string value)
        {
            Dictionary<string, string> dict
                = (Dictionary<string, string>)this.GetType().GetField("data").GetValue(this);
            dict.GetType()
                .GetMethod("Add", new[] { key.GetType(), value.GetType() })
                .Invoke(dict, new object[] { key, value });
        }
    }
}

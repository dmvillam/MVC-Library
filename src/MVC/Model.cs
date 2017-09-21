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

            DBConnect connect = new DBConnect(table, columns, Model<T>.GetIdLabel());
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

            DBConnect connect = new DBConnect(table, columns, Model<T>.GetIdLabel());
            connect.Insert(new string[] {
                String.Join(",", columns),
                "'" + String.Join("','", values) + "'"
            });
            List<Dictionary<string, string>> list = connect.Select();
            model.id = Convert.ToInt32(list[list.Count - 1][connect.id_label]);
            model.data = list[list.Count - 1];

            return model;
        }
        public void save()
        {
            string table = Model<T>.GetTable();
            string[] columns = Model<T>.GetColumns();

            DBConnect dbconnect = new DBConnect(table, columns, Model<T>.GetIdLabel());
            List<string> list = new List<string>();
            for (int i = 0; i < columns.Length; i++)
                list.Add(columns[i] + "='" + this.data[columns[i]] + "'");
            dbconnect.Update(this.id, list);
        }
        public static Collection<T> all()
        {
            string table = Model<T>.GetTable();
            string[] columns = Model<T>.GetColumns();

            T m = (T)Activator.CreateInstance(typeof(T), false);
            DBConnect connect = new DBConnect(table, columns, Model<T>.GetIdLabel());
            List<Dictionary<string, string>> list = connect.Select();
            Collection<T> models = new Collection<T>();
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
            DBConnect connect = new DBConnect(table, columns, Model<T>.GetIdLabel());
            connect.Delete(id);
        }
        protected dynamic hasOne<U>()
        {
            string table = Model<T>.GetTable();
            string[] columns = Model<T>.GetColumns();

            // TODO: fix and test this code!!
            DBConnect connect = new DBConnect(table, columns, Model<T>.GetIdLabel());

            dynamic model = Activator.CreateInstance(typeof(U), false);
            model.id = 0;
            Dictionary<string, string> newdata = new Dictionary<string, string>();
            for (int i = 0; i < model.columns.Length; i++)
                model.data.Add(model.columns[i], "aaa");

            return model;
        }
        protected dynamic belongsTo<U>()
        {
            string connector = Model<T>.GetConnector<U>();

            dynamic model = Activator.CreateInstance(typeof(U), false);
            int key = Convert.ToInt32(this.data[connector]);
            model = typeof(U)
                .GetMethod("find", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Invoke(null, new object[] { key });
            return model;
        }
        public Collection<U> hasMany<U>()
            where U : Model<U>
        {
            string table1 = Model<T>.GetTable();
            string table2 = Model<U>.GetTable();
            string[] columns2 = Model<U>.GetColumns();
            string connector = Model<U>.GetConnector<T>();

            dynamic m1 = Activator.CreateInstance(typeof(T), false);
            dynamic m2 = Activator.CreateInstance(typeof(U), false);
            List<Dictionary<string, string>> list =
                DBQuery.use_table(table2, columns2)
                .select(new string[] { table2 + ".*" })
                .inner_join(table1, table2 + "." + connector, "=", table1 + ".id")
                .where(table1 + ".id", "=", this.id.ToString())
                .get();

            Collection<U> models = new Collection<U>();
            foreach (Dictionary<string, string> elem in list)
            {
                U model = (U)Activator.CreateInstance(typeof(U), false);
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
            where U : Model<U>
        {
            string table1 = Model<U>.GetTable();
            string[] columns1 = Model<U>.GetColumns();
            string table2 = Model<T>.GetTable();

            List<Dictionary<string, string>> list =
                DBQuery.use_table(cross_table, columns1)
                .select(new string[] { table1 + ".*" })
                .inner_join(table2, table2 + ".id", "=", cross_table + "." + connector[typeof(T).Name])
                .inner_join(table1, table1 + ".id", "=", cross_table + "." + connector[typeof(U).Name])
                .where(table2 + ".id", "=", this.id.ToString())
                .get();

            Collection<U> models = new Collection<U>();
            foreach (Dictionary<string, string> elem in list)
            {
                U model = (U)Activator.CreateInstance(typeof(U), false);
                model.id = Convert.ToInt32(elem["id"]);
                for (int i = 0; i < columns1.Length; i++)
                    model.data.Add(columns1[i], elem[columns1[i]]);
                models.Add(model);
            }
            return models;
        }
        /*
         * U -> Bill
         * T -> Item
         */
        public dynamic belongsToMany<U>(Dictionary<string, string> connector, string cross_table)
            where U : Model<U>
        {
            string table1 = Model<T>.GetTable();
            string[] columns1 = Model<T>.GetColumns();
            string table2 = Model<U>.GetTable();
            string[] columns2 = Model<U>.GetColumns();

            List<Dictionary<string, string>> list =
                DBQuery.use_table(cross_table, columns2)
                .select(new string[] { table2 + ".*" })
                .inner_join(table2, table2 + ".id", "=", cross_table + "." + connector[typeof(U).Name])
                .inner_join(table1, table1 + ".id", "=", cross_table + "." + connector[typeof(T).Name])
                .where(table1 + ".id", "=", this.id.ToString())
                .get();

            Collection<U> models = new Collection<U>();
            foreach (Dictionary<string, string> elem in list)
            {
                U model = (U)Activator.CreateInstance(typeof(U), false);
                model.id = Convert.ToInt32(elem["id"]);
                for (int i = 0; i < columns2.Length; i++)
                    model.data.Add(columns2[i], elem[columns2[i]]);
                models.Add(model);
            }
            return models;
        }

        private static string GetTable()
        {
            return typeof(T)
                .GetField("Table", BindingFlags.NonPublic | BindingFlags.Static)
                .GetValue(null).ToString();
        }
        private static string[] GetColumns()
        {
            return (string[])typeof(T)
                .GetField("Columns", BindingFlags.NonPublic | BindingFlags.Static)
                .GetValue(null);
        }
        private static string GetIdLabel()
        {
            if (typeof(T).GetField("IdLabel", BindingFlags.NonPublic | BindingFlags.Static) != null)
                return (string)typeof(T).GetField("IdLabel", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
            else return "id";
        }
        private static string GetConnector<myclass>()
        {
            return ((Dictionary<string, string>)typeof(T)
                .GetField("Connectors", BindingFlags.NonPublic | BindingFlags.Static)
                .GetValue(null))[typeof(myclass).Name];
        }
    }
}

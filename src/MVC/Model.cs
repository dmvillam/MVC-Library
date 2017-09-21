using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    public class Model<T> where T : Model<T>
    {
        public virtual string table { get { return ""; } }
        public virtual string[] columns { get { return new string[] { }; } }

        public int id;
        public Dictionary<string, string> data;

        public Model()
        {
            data = new Dictionary<string, string>();
        }
        public static T find(int id)
        {
            dynamic model = Activator.CreateInstance(typeof(T), false);
            DBConnect connect = new DBConnect(model.table, model.columns);
            List<string> values = connect.Select(id);

            if (values.Count == 1)
            {
                model.id = id;
                for (int i = 0; i < model.columns.Length; i++)
                    model.data.Add(model.columns[i], values[i]);
                return model;
            }
            else return null;
        }
        public static T create(Dictionary<string, string> data)
        {
            dynamic model = Activator.CreateInstance(typeof(T), false);
            List<string> values = new List<string>();
            for (int i = 0; i < model.columns.Length; i++)
                values.Add(data[model.columns[i]]);

            DBConnect connect = new DBConnect(model.table, model.columns);
            connect.Insert(new string[] {
                String.Join(",", model.columns),
                "'" + String.Join("','", values) + "'"
            });
            List<Dictionary<string, string>> list = connect.Select();
            model.id = Convert.ToInt32(list[list.Count - 1]["id"]);
            model.data = list[list.Count - 1];

            return model;
        }
        public void save()
        {
            DBConnect dbconnect = new DBConnect(table, columns);
            List<string> list = new List<string>();
            for (int i = 0; i < columns.Length; i++)
                list.Add(columns[i] + "='" + this.data[columns[i]] + "'");
            dbconnect.Update(this.id, list);
        }
        public static List<T> all()
        {
            Type type = typeof(T);
            dynamic m = Activator.CreateInstance(type, false);
            DBConnect connect = new DBConnect(m.table, m.columns);
            List<Dictionary<string, string>> list = connect.Select();
            List<T> models = new List<T>();
            foreach (Dictionary<string, string> elem in list)
            {
                dynamic model = Activator.CreateInstance(type, false);
                model.id = Convert.ToInt32(elem["id"]);
                for (int i = 0; i < m.columns.Length; i++)
                    model.data.Add(m.columns[i], elem[m.columns[i]]);
                models.Add(model);
            }
            return models;
        }
        public static void destroy(int id)
        {
            dynamic model = Activator.CreateInstance(typeof(T), false);
            DBConnect connect = new DBConnect(model.table, model.columns);
            connect.Delete(id);
        }
        protected dynamic hasOne(Type type)
        {
            DBConnect connect = new DBConnect(table, columns);


            dynamic model = Activator.CreateInstance(type, false);
            string mytable = table;
            string[] mycols = columns;

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
            dynamic m1 = Activator.CreateInstance(typeof(T), false);
            dynamic m2 = Activator.CreateInstance(typeof(U), false);
            List<Dictionary<string, string>> list =
                DBQuery.use_table(m2.table, m2.columns)
                .select(new string[] { m2.table + ".*" })
                .inner_join(m1.table, m2.table + "." + connector, "=", m1.table + ".id")
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
    }
}

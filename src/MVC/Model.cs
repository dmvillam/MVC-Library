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
            data = new Dictionary<string, string>();
        }

        public static T find(int id)
        {
            string table = Model<T>.GetTable();
            string[] columns = Model<T>.GetColumns();
            T model = (T)Activator.CreateInstance(typeof(T), false);

            DBConnect connect = new DBConnect(typeof(T));
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

            DBConnect connect = new DBConnect(typeof(T));
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

            DBConnect dbconnect = new DBConnect(typeof(T));
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
            DBConnect connect = new DBConnect(typeof(T));
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
            DBConnect connect = new DBConnect(typeof(T));
            connect.Delete(id);
        }

        protected dynamic hasOne<U>()
        {
            string table = Model<T>.GetTable();
            string[] columns = Model<T>.GetColumns();

            // TODO: fix and test this code!!
            DBConnect connect = new DBConnect(typeof(T));

            dynamic model = Activator.CreateInstance(typeof(U), false);
            model.id = 0;
            Dictionary<string, string> newdata = new Dictionary<string, string>();
            for (int i = 0; i < model.columns.Length; i++)
                model.data.Add(model.columns[i], "aaa");

            return model;
        }

        protected U belongsTo<U>()
            where U : Model<U>
        {
            return (U)new BelongsTo<U>(this, Model<T>.GetConnector<U>());
        }

        public HasMany<U> hasMany<U>()
            where U : Model<U>
        {
            return new HasMany<U>(Model<T>.GetTable(),
                Model<U>.GetTable(), Model<U>.GetColumns(),
                Model<U>.GetConnector<T>(), this.id.ToString());
        }

        public BelongsToMany<U> belongsToMany<U>()
            where U : Model<U>
        {
            return new BelongsToMany<U>(Model<T>.GetTable(),
                Model<U>.GetTable(), Model<T>.GetColumns(),
                Model<U>.GetColumns(), Model<T>.GetCrossTable<U>(),
                Model<U>.GetConnector<T>(), Model<T>.GetConnector<U>(),
                this.id.ToString());
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

        private static string GetCrossTable<U>() where U : Model<U>
        {
            List<string> list = new List<string> {
                Model<T>.GetTable(),
                Model<U>.GetTable(),
            };
            list.Sort();
            return String.Format("{0}_{1}", list[0], list[1]);
        }
    }
}

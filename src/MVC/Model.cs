using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    // TODO: remove int id field, and add some sort of
    // 'protected string primaryKey = "id"', being the value of "id" the default
    // that you can change into the derived models

    /*
     * TODO: convert Model<T>.data from Dictionary<string, string> to
     * Dictionary<string, object> or even to Hashtable. The idea is being 
     * able to retrieve correct type from DBConnect.dataReader[field]
     */

    /*
     * TODO: Model<T> should be derived from class type that is data,
     * in order to not need anymore data field
     */

    /*
     * TODO:
     * https://stackoverflow.com/questions/26669400/insert-quote-in-mysql-using-c-sharp
     * that page contains info about how to reduce sql injection vulnerability
     * on sql queries, we could modify DBConnect with that info, but i suspect
     * it would imply addding a new Dictionary<string,string> containing
     * data types info for each variable the tables need....
     */

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

            DBConnect connect = new DBConnect(typeof(T));
            model.id = connect.Insert(new string[] {
                String.Join(", ", data.Keys.ToArray<string>()),
                Model<T>.ParseNullAndBoolean(data.Values)
            });
            model.data = data;
            return model;
        }

        public void save()
        {
            string table = Model<T>.GetTable();
            string[] columns = Model<T>.GetColumns();

            DBConnect dbconnect = new DBConnect(typeof(T));
            List<string> list = new List<string>();
            foreach (string column in columns)
                list.Add(ParseNullAndBoolean(column, this.data[column])); // Format: "{0} = '{1}'"
            dbconnect.Update(this.id, list);
        }

        public static Collection<T> all()
        {
            T m = (T)Activator.CreateInstance(typeof(T), false);
            DBConnect connect = new DBConnect(typeof(T));
            List<Dictionary<string, string>> list = connect.Select();

            return Model<T>.ListToCollection(list);
        }

        public static void destroy(int id)
        {
            string table = Model<T>.GetTable();
            string[] columns = Model<T>.GetColumns();

            dynamic model = Activator.CreateInstance(typeof(T), false);
            DBConnect connect = new DBConnect(typeof(T));
            connect.Delete(id);
        }

        public static Collection<T> where(string key, string oper, string value)
        {
            string val = String.Format("'{0}'", value);

            List<Dictionary<string, string>> list
                = DBQuery.use_table(typeof(T))
                .select(new string[] { "*" })
                .where(key, oper, val).get();

            return Model<T>.ListToCollection(list);
        }

        public static Collection<T> where(string[] conditions)
        {
            List<Dictionary<string, string>> list;
            if (conditions.Length > 1)
            {
                DBQuery query = DBQuery.use_table(typeof(T))
                    .select(new string[] { "*" })
                    .where(conditions[0]);

                for (int i = 1; i < conditions.Length; i++ )
                    query = query.and(conditions[i]);

                list = query.get();
            }
            else list = DBQuery.use_table(typeof(T))
                .select(new string[] { "*" })
                .where(conditions[0]).get();

            return Model<T>.ListToCollection(list);
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
                Model<U>.GetConnector<T>(), this.id.ToString(),
                Model<U>.GetIdLabel());
        }

        public BelongsToMany<U> belongsToMany<U>()
            where U : Model<U>
        {
            return new BelongsToMany<U>(Model<T>.GetTable(),
                Model<U>.GetTable(), Model<T>.GetColumns(),
                Model<U>.GetColumns(), Model<T>.GetCrossTable<U>(),
                Model<U>.GetConnector<T>(), Model<T>.GetConnector<U>(),
                this.id.ToString(), Model<U>.GetIdLabel());
        }

        private static string GetTable()
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

        private static Collection<T> ListToCollection(List<Dictionary<string, string>> list)
        {
            string[] columns = Model<T>.GetColumns();
            Collection<T> models = new Collection<T>();
            foreach (Dictionary<string, string> elem in list)
            {
                T model = (T)Activator.CreateInstance(typeof(T), false);
                string id_label = Model<T>.GetIdLabel();
                model.id = Convert.ToInt32(elem[id_label]);
                foreach (string column in columns)
                    model.data.Add(column, elem[column]);
                models.Add(model);
            }
            return models;
        }

        private static string ParseNullAndBoolean(Dictionary<string, string>.ValueCollection values)
        {
            List<string> list = new List<string>();
            foreach (string value in values)
                list.Add(ParseAndEscape(value));
            return String.Join(", ", list);
        }

        private static string ParseNullAndBoolean(string key, string value)
        {
            return String.Format("{0} = {1}", key, ParseAndEscape(value));
        }

        private static string ParseAndEscape(string s)
        {
            string to_add = s;
            if (s != null)
            {
                if (s.Contains("'") && s.Contains("\""))
                    to_add = "'Bad post. Sorry. You better copypaste old post.'";
                else to_add = (s.Contains("'")) ?
                        String.Format("\"{0}\"", to_add) : to_add = String.Format("'{0}'", to_add);
            }
            else to_add = "NULL";
            to_add = (s == "True") ? "True" : to_add;
            to_add = (s == "False") ? "False" : to_add;
            to_add = (s == "NULL") ? "NULL" : to_add;
            return to_add;
        }
    }
}

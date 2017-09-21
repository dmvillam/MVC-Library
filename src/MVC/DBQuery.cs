using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    class DBQuery : DBConnect
    {
        private string q_select, q_join, q_where, q_and;

        public DBQuery(Type type) : base(type)
        {
            q_select = String.Empty;
            q_join = String.Empty;
            q_where = String.Empty;
            q_and = string.Empty;
        }

        public static DBQuery use_table(Type type)
        {
            return new DBQuery(type);
        }

        public static DBQuery use_table(Type type, string table)
        {
            DBQuery query = new DBQuery(type);
            query.table = table;
            return query;
        }

        public DBQuery select(string[] select_vars)
        {
            q_select = String.Format("SELECT {0} FROM {1} ",
                string.Join(",", select_vars), table);
            return this;
        }

        public DBQuery inner_join(string table, string key1, string oper, string key2)
        {
            q_join += String.Format("INNER JOIN {0} ON {1} {2} {3} ",
                table, key1, oper, key2);
            return this;
        }

        public DBQuery where(string key1, string oper, string key2)
        {
            q_where = String.Format("WHERE {0} {1} {2} ", key1, oper, key2);
            return this;
        }

        public DBQuery and(string key1, string oper, string key2)
        {
            q_and += String.Format("AND {0} {1} {2} ", key1, oper, key2);
            return this;
        }

        public DBQuery where(string condition)
        {
            q_where = String.Format("WHERE {0} ", condition);
            return this;
        }

        public DBQuery and(string condition)
        {
            q_and += String.Format("AND {0} ", condition);
            return this;
        }

        public List<Dictionary<string, string>> get()
        {
            string query;
            if ((q_select + q_join + q_where + q_and) != String.Empty)
                query = q_select + q_join + q_where + q_and;
            else throw new Exception("Error: you can't have a query without a query request!");

            List<Dictionary<string, string>> output = new List<Dictionary<string, string>>();
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    // TODO: change "id" by id_label, and prevent the .Add()
                    // execution when columns[i]==id_label
                    Dictionary<string, string> elem = new Dictionary<string, string>();
                    elem.Add(id_label, dataReader[id_label].ToString());
                    for (int i = 0; i < columns.Length; i++)
                        if (columns[i] != id_label)
                            elem.Add(columns[i], dataReader[columns[i]].ToString());
                    output.Add(elem);
                }
                dataReader.Close();
                this.CloseConnection();
                return output;
            }
            else
            {
                return output;
            }
        }

        public int insert(Dictionary<string, string> inserts)
        {
            return this.Insert(new string[] {
                String.Join(",", inserts.Keys.ToArray<string>()),
                String.Join(",", inserts.Values.ToArray<string>())
            });
        }

        public void delete(string key, string oper, int value)
        {
            string query = String.Format("DELETE FROM {0} WHERE {1} {2} {3}",
                this.table, key, oper, value);
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public void delete(string key1, string oper1, int value1,
            string key2, string oper2, int value2)
        {
            string query = String.Format(
                "DELETE FROM {0} WHERE {1} {2} {3} AND {4} {5} {6}",
                this.table, key1, oper1, value1, key2, oper2, value2);
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
    }
}

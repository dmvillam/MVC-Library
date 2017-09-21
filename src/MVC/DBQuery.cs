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
        private string ext_query;
        public DBQuery(string table, string[] columns)
            : base(table, columns)
        {
            ext_query = String.Empty;
        }
        public static DBQuery use_table(string table, string[] columns)
        {
            return new DBQuery(table, columns);
        }
        public DBQuery select(string[] select_vars)
        {
            ext_query += "SELECT " + string.Join(",", select_vars) + " FROM " + table + " ";
            return this;
        }
        public DBQuery inner_join(string table, string key1, string oper, string key2)
        {
            ext_query += "INNER JOIN " + table + " ON " + key1 + oper + key2 + " ";
            return this;
        }
        public DBQuery where(string key1, string oper, string key2)
        {
            ext_query += "WHERE " + key1 + oper + key2 + " ";
            return this;
        }
        public List<Dictionary<string, string>> get()
        {
            List<Dictionary<string, string>> output = new List<Dictionary<string, string>>();
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(ext_query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Dictionary<string, string> elem = new Dictionary<string, string>();
                    elem.Add("id", dataReader["id"].ToString());
                    for (int i = 0; i < columns.Length; i++)
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
    }
}

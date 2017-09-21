using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using Raw;

namespace MVC
{
    public class DBConnect
    {
        public string id_label;

        protected MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        protected string table;
        protected string[] columns;

        // Constructor
        public DBConnect(Type type)
        {
            Initialize(type.GetField("ConfigData",
                BindingFlags.NonPublic | BindingFlags.Static));
            this.table = (string)type
                .GetField("Table", BindingFlags.NonPublic | BindingFlags.Static)
                .GetValue(null);
            this.columns = (string[])type
                .GetField("Columns", BindingFlags.NonPublic | BindingFlags.Static)
                .GetValue(null);
            FieldInfo f = type.GetField("IdLabel",
                BindingFlags.NonPublic | BindingFlags.Static);
            this.id_label = (f != null) ? (string)f.GetValue(null) : "id";
        }
        //Initialize values
        protected void Initialize(FieldInfo cfgFieldInfo)
        {
            // Default values
            Dictionary<string, string> config_data
                = new Dictionary<string, string> {
                {"server", "localhost"},
                {"database", "facturación"},
                {"uid", "root"},
                {"password", "armagedon2"}
            };

            if (cfgFieldInfo != null)
            {
                config_data = (Dictionary<string, string>)cfgFieldInfo
                    .GetValue(null);
            }
            else if (File.Exists("dbconfig.ini"))
                RawParser.Parse1(Raw.Raw.Get("dbconfig.ini"), config_data);

            server = config_data["server"];
            database = config_data["database"];
            uid = config_data["uid"];
            password = config_data["password"];

            string connectionString = string.Format(
                "SERVER={0};DATABASE={1};UID={2};PASSWORD={3};",
                server, database, uid, password);
            connection = new MySqlConnection(connectionString);
        }
        // Open connection to database
        protected bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server. Contact administrator.");
                        break;
                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again.");
                        break;
                }
                return false;
            }
        }
        // Close connection
        protected bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }
        // Insert statement
        public int Insert(string[] parameters)
        {
            int id = -1;
            string query = String.Format("INSERT INTO {0} ({1}) VALUES ({2});",
                table, parameters[0], parameters[1]);
            query += String.Format("SELECT MAX({0}) FROM {1};", id_label, table);

            // Open connection
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    string label = String.Format("MAX({0})", id_label);
                    id = Convert.ToInt32(dataReader[label]);
                }
                dataReader.Close();
                this.CloseConnection();
            }
            return id;
        }
        // Update statement
        public void Update(int id, List<string> values)
        {
            string query = String.Format("UPDATE {0} SET {1} WHERE {2}='{3}'",
                table, String.Join(",", values), id_label, id);
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        // Delete statement
        public void Delete(int id)
        {
            string query = String.Format("DELETE FROM {0} WHERE {1}='{2}'",
                table, id_label, id);
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        public List<string> Select(int id)
        {
            string query = String.Format("SELECT * FROM {0} WHERE {1} = {2};",
                table, id_label, id);

            List<string> list = new List<string>();
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    foreach (string column in columns)
                    {
                        object read = dataReader[column];
                        list.Add((read == DBNull.Value) ? null : read.ToString());
                    }
                }
                dataReader.Close();
                this.CloseConnection();
                return list;
            }
            else
            {
                return list;
            }
        }
        public List<Dictionary<string, string>> Select()
        {
            string query = "SELECT * FROM " + table;

            List<Dictionary<string, string>> output = new List<Dictionary<string, string>>();
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Dictionary<string, string> elem = new Dictionary<string, string>();
                    elem.Add(id_label, dataReader[id_label].ToString());
                    foreach (string column in columns)
                        if (column != id_label)
                        {
                            object read = dataReader[column];
                            elem.Add(column, (read == DBNull.Value) ? null : read.ToString());
                        }
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
        // Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM " + table;
            int Count = -1;
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                Count = Int16.Parse(cmd.ExecuteScalar() + "");
                this.CloseConnection();
                return Count;
            }
            else
            {
                return Count;
            }
        }
        // Backup
        public void Backup()
        {
            try
            {
                DateTime Time = DateTime.Now;
                string path = string.Format(
                    "C:\\MySqlBackup{0}-{1}-{2}-{3}-{4}-{5}-{6}.sql",
                    Time.Year, Time.Month, Time.Day, Time.Hour,
                    Time.Minute, Time.Second, Time.Millisecond);
                StreamWriter file = new StreamWriter(path);

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                //MessageBox.Show("Error, unable to backup!");
            }
        }
        // Restore
        public void Restore()
        {
            try
            {
                string path;
                path = "C:\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                //MessageBox.Show("Error , unable to Restore!");
            }
        }
    }
}

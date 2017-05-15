using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;

namespace Pacman.MySQL
{
    public class Database
    {
        #region Constants
        private const string hostname = "217.160.177.122";
        private const string port = "3306";
        private const string database = "programs";
        private const string username = "pacman";
        private const string password = "9DkNXtfAFCqHp3wF";
        private const string table = "pacmanTable";
        #endregion

        #region Getters
        public MySqlConnection Connection { get; private set; }
        #endregion

        #region Constructors
        public Database()
        {
            Connection = new MySqlConnection("SERVER=" + hostname + ";DATABASE=" + database + ";UID=" + username + ";PASSWORD=" + password + ";");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Connects to the Database
        /// </summary>
        /// <returns>True = Success, False = Failed</returns>
        public bool Connect()
        {
            try
            {
                Connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Disconnects from the Database
        /// </summary>
        /// <returns>True = Success, False = Failed</returns>
        public bool Disconnect()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Updates the Table / Database
        /// </summary>
        /// <param name="row">The Row which should be updated</param>
        /// <param name="newValue">The Value which should be inserted</param>
        /// <param name="where">The WHERE-Statement</param>
        public void Update(string row, string newValue, string where)
        {
            if (Connect())
            {
                string query = "UPDATE " + table +" SET " + row + "='" + newValue + "' WHERE " + where ;
                MySqlCommand cmd = new MySqlCommand(query, Connection);
                cmd.ExecuteNonQuery();

                Disconnect();
            }
        }

        /// <summary>
        /// Selects all Datasets in the Table / Database
        /// </summary>
        /// <param name="row">The Row which should be selected</param>
        /// <param name="where">The WHERE-Statement</param>
        /// <returns>The available Dataset to the WHERE-Statement</returns>
        public string Select(string row, string where)
        {
            string dataset = "";
            if (Connect())
            {
                string query = "SELECT " + row + "='" + "' FROM " + table + " WHERE " + where;
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, Connection);
                    MySqlDataReader Reader = cmd.ExecuteReader();
                    if (Reader.Read())
                    {
                        dataset = Reader.ToString();
                    }
                    Reader.Close();
                }
                catch { }
                Disconnect();
            }
            return dataset;
        }

        /// <summary>
        /// Saves the Table / Database in a BackUp File
        /// </summary>
        /// <param name="filename">Path to the BackUp File</param>
        public void BackUp(string filename)
        {
            try
            { 
                StreamWriter file = new StreamWriter(filename);

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    username, password, hostname, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch{ }
        }

        /// <summary>
        /// Loads a BackUp File
        /// </summary>
        /// <param name="filename">Path to the BackUp File</param>
        public void Restore(string filename)
        {
            try
            {
                StreamReader file = new StreamReader(filename);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    username, password, hostname, database);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch{ }
        }
        #endregion
    }
}

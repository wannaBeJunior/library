using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace library
{
    public partial class signin : Form
    {
        public string login = "";
        public string passwordHash = "";
        public List<string> errors = new List<string>();
        public signin()
        {
            InitializeComponent();
        }

        private void doSignin(object sender, EventArgs e)
        {
            setData();
            startSignin();
        }

        private void setData()
        {
            if(textBox1.Text.ToString() != null)
            {
                login = textBox1.Text.ToString();
            }else
            {
                errors.Add("Вы не ввели логин");
            }
            if (textBox2.Text.ToString() != null)
            {
                passwordHash = GetHash(textBox2.Text.ToString());
            }
            else
            {
                errors.Add("Вы не ввели пароль");
            }
        }

        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        public void startSignin()
        {
            MySqlConnection connecting = GetDBConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM `employees` WHERE `login` = {this.login}", connecting);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                MessageBox.Show(Convert.ToString(row[1]));
            }
        }

        public static MySqlConnection GetDBConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "mydb";
            string username = "root";
            string password = "root";

            return GetDBConnection(host, port, database, username, password);
        }
    }
}

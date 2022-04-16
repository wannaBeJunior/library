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
using library.classes;

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
            CMySql DBConnect = new CMySql();
            List<DataRow> result = DBConnect.execSelect($"SELECT * FROM `employees` WHERE `login` = '{this.login}'");
            if(result.Count > 0)
            {
                if(verifyPassword(Convert.ToString(result[0]["password"])))
                {
                    Form2 f2 = new Form2();
                    this.Close();
                    f2.Show();
                }
            }

        }

        public bool verifyPassword(string dbPassword)
        {
            if(dbPassword == passwordHash)
            {
                return true;
            }
            return false;
        }
    }
}
